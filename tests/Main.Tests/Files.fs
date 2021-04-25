module Main.InfraTests

open System
open NUnit.Framework
open Main

[<TestFixture>]
type TestClass() =

    [<Test>]
    member this.TestFiles() = 
        let folder1 = new Files.Folder("/home/quziel/Repos/files/input")
        for file in folder1.FileArray do
           Assert.That(file.Name, Is.EqualTo("/home/quziel/Repos/files/input/in002.txt"))
           for line in file.Lines do
            printfn "%s" line