open System
open Service

[<EntryPoint>]
let main args =
    printfn "Running program"
    new MyService() |> fun serv -> serv.Execute
    // Return 0. This indicates success.
    0