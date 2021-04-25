namespace Main

open System.IO

module Files =

    type Folder = { path : string } 
        //let filenameArray : string array = Directory.GetFiles(path)
        //member this.FileArray = Array.map (fun elem -> new File(elem, this)) filenameArray
    and File = {filename: string; containingFolder: Folder; lines : List<string>}
        //member this.Lines =  File.ReadAllLines(this.Name)
    and FilePath = { path : string}    

    type FileRW =
        abstract member Read : FilePath -> File
        abstract member Write : File -> unit
        abstract member Create : Folder -> FilePath

    type MyFileRW() =
        interface FileRW with
            member this.Read fp = 
                let filenameArray = 
                    Directory.GetFiles(path)
                    |> Array.map (fun elem -> new File(elem, Folder path))
                

