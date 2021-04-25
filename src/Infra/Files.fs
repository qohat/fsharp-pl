namespace Main

open System.IO

module Files =

    type Folder(path: string) = 
        let filenameArray : string array = Directory.GetFiles(path)
        member this.path = path
        member this.FileArray = Array.map (fun elem -> new File(elem, this)) filenameArray

    and File(filename: string, containingFolder: Folder) =
        member this.Name = filename
        member this.ContainingFolder = containingFolder
        member this.Lines =  File.ReadAllLines(this.Name)