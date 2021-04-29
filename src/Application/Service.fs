module Service

open Adapter

    type Service = 
        abstract member Execute : unit list

    type MyService() =
        member this.Execute = (this :> Service).Execute
        interface Service with
            member this.Execute = 
                let repo = new MyRepository()
                repo.FindAll
                |> List.map (fun s -> repo.Save s)