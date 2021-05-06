module Main.InfraTests

open NUnit.Framework
open Files
open AsyncTest

[<TestFixture>]
type TestClass() =

    [<Test>]
    member this.TestFilesRead() = 
        let rw = new MyFileRW()
        let files = rw.Read({path = "/home/quziel/Repos/files/input/"})
        Assert.That(files.Length, Is.EqualTo(2))