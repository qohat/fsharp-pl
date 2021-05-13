module Main.InfraTests1

open NUnit.Framework
open FilesAsync
open System.Text

[<TestFixture>]
type TestClass() =

    [<Test>]
    member this.TestFilesAsyncRead() = 
        getFilesAsync<string> "/home/quziel/Repos/files/input/" (fun b -> Encoding.ASCII.GetString b)
        |> Async.Sequential
        |> Async.Ignore
        |> Async.RunSynchronously
        |> ignore


        