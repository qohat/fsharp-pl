module FilesAsync

open System.IO
open System.Text

    type Folder = { path : string } 
    and File = { filename: string; containingFolder: Folder; lines : string list }
    and FilePath = { path : string }

    let private toFile(filePath: FilePath) (folder: Folder): File =
        {filename = Path.GetFileName(filePath.path); containingFolder = folder; lines = File.ReadAllLines(filePath.path) |> List.ofArray}

    type FileRW =
        abstract member Read : FilePath -> File list
        abstract member Write : File -> unit
        abstract member Create : Folder -> FilePath

    type MyFileRW() =
        member this.Read fp = (this :> FileRW).Read(fp)
        member this.Write file = (this :> FileRW).Write(file)
        member this.Create folder = (this :> FileRW).Create(folder)

        interface FileRW with
            member this.Read fp = 
                    Array.map (fun elem -> toFile {path = elem} {path = fp.path}) (Directory.GetFiles(fp.path))
                    |> List.ofArray

            member this.Create folder = 
                if Directory.Exists(folder.path) then { path = folder.path } 
                else
                    Directory.CreateDirectory(folder.path)
                    |> fun _ -> { path = folder.path }

            member this.Write file = 
                this.Create(file.containingFolder)
                |> fun _ -> File.WriteAllLines($"{file.containingFolder.path}/{file.filename}", file.lines, Encoding.UTF8)

           
                

