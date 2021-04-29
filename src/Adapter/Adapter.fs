module Adapter

open Config
open Move
open Files

let private explode (s:string) =
        [for c in s -> c]

let toLocation (line: string) : Location =
    run (explode line) {Move.x = {_x = 0}; Move.y = {_y = 0}; Move.dir = North} 

let private toShipper (file: File) : Shipper =
    match file with
    | {File.filename = f; lines = []} -> {id = {id = f}; locations = []}
    | {File.filename = f; lines = lines} -> {id = {id = f}; locations = List.map (fun line -> toLocation line) lines}

let toLine (location: Location): string =
    $"({location.x._x}, {location.y._y}) {location.dir}"

let private toFile (shipper: Shipper) (config: AdapterConfig) : File =
    {filename = shipper.id.id; containingFolder = {path = config.outputFolder}; lines = List.map toLine shipper.locations}

type Repository = 
    abstract member FindAll : Shipper list
    abstract member Save : Shipper -> unit

type MyRepository() =
    member this.FindAll = (this :> Repository).FindAll
    member this.Save s = (this :> Repository).Save(s)

    interface Repository with
        member this.FindAll = 
            let conf = getConfig
            new MyFileRW()
            |> fun fRW -> fRW.Read({path = conf.inputFolder})
            |> List.map (fun file -> toShipper file)
            
        member this.Save s = 
            let conf = getConfig
            new MyFileRW()
            |> fun fRW -> fRW.Write (toFile s conf)
