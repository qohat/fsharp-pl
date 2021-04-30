open System
open Service

[<EntryPoint>]
let main args =
    printfn "Running program..."
    new MyService() |> fun serv -> serv.Execute |> fun _ -> printfn "Program executed successfully !!"
    0