namespace Main

open System.IO

module Files =

    type Folder = { path : string } 
    and File = {filename: string; containingFolder: Folder; lines : string array}
    and FilePath = { path : string }

    let private toFile(fileName: string, folder: Folder): File =
        {filename = fileName; containingFolder = folder; lines = File.ReadAllLines(fileName)}

    type FileRW =
        abstract member Read : FilePath -> File array
        abstract member Write : File -> unit
        abstract member Create : Folder -> FilePath

    type MyFileRW() =
        member this.Read(fp) = (this :> FileRW).Read(fp)
        member this.Write(file) = (this :> FileRW).Write(file)
        member this.Create(folder) = (this :> FileRW).Create(folder)
        interface FileRW with
            member this.Read fp = 
                    Array.map (fun elem -> toFile(elem, {path = fp.path})) (Directory.GetFiles(fp.path))
            member this.Create folder = 
                if Directory.Exists(folder.path) then { path = folder.path } 
                else
                    Directory.CreateDirectory(folder.path)
                    |> fun _ -> { path = folder.path }
            member this.Write file = 
                this.Create(file.containingFolder)
                |> fun _ -> File.WriteAllLines(file.filename, file.lines)

           
                

