module ServiceTest

open NUnit.Framework
open Service

[<TestFixture>]
type TestClass() =

    [<Test>]
    member this.TestExecute() = 
        new MyService()
        |> fun serv -> serv.Execute
        |> List.fold (fun _ _ -> ()) ()