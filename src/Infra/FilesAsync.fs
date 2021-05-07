module FilesAsync

open System.IO
open System.Text
open System.Threading.Tasks

    type Folder = { path : string } 
    and File = { filename: string; containingFolder: Folder; lines : string list }
    and FilePath = { path : string }

    let private toFile(filePath: FilePath) (folder: Folder): File =
        {filename = Path.GetFileName(filePath.path); containingFolder = folder; lines = File.ReadAllLines(filePath.path) |> List.ofArray}

    let private readLinesAsync (path: string) (f: byte[] -> 'a) =
        async {
            use stream = File.OpenRead(path)

            let! content = stream.AsyncRead(int stream.Length)

            return f content
        } |> Async.StartAsTask

    let rec readFolderRecursively (path: string) (f: byte[] -> 'a) =
        seq {
            for file in Directory.GetFiles(path) do
                yield readLinesAsync file f
            
            for path in Directory.GetDirectories(path) do
                yield! readFolderRecursively path f
        }

    let getFilesAsync<'a> (path: string) (f: byte[] -> 'a) =
    

    type FileRW =
        abstract member Read : FilePath -> Async<File list>
        abstract member Write : File -> Async<unit>
        abstract member Create : Folder -> Async<FilePath>

    type MyFileRW() =
        member this.Read fp = (this :> FileRW).Read(fp)
        member this.Write file = (this :> FileRW).Write(file)
        member this.Create folder = (this :> FileRW).Create(folder)

        interface FileRW with
            member this.Read fp = 
                async {
                    let! files = Directory.GetFiles(fp.path)
                    return Array.map (fun elem -> toFile {path = elem} {path = fp.path}) (Directory.GetFiles(fp.path))
                    |> List.ofArray
                }
                    

            member this.Create folder = 
                if Directory.Exists(folder.path) then { path = folder.path } 
                else
                    Directory.CreateDirectory(folder.path)
                    |> fun _ -> { path = folder.path }

            member this.Write file = 
                this.Create(file.containingFolder)
                |> fun _ -> File.WriteAllLines($"{file.containingFolder.path}/{file.filename}", file.lines, Encoding.UTF8)

           
                

