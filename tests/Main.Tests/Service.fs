module ServiceTest

open NUnit.Framework
open Files

[<TestFixture>]
type TestClass() =

    [<Test>]
    member this.TestFilesRead() = 
        let rw = new Files.MyFileRW()
        let files = rw.Read({path = "/home/quziel/Repos/files/input/"})
        Assert.That(files.Length, Is.EqualTo(3))
    
    [<Test>]
    member this.TestFilesWrite() = 
        let rw = new Files.MyFileRW()
        let file = { 
            Files.filename = "/home/quziel/Repos/files/input/out001.txt";
            Files.containingFolder = { path = "/home/quziel/Repos/files/input"};
            Files.lines = [|"AADDIIA"; "AAAAADI"; "DDAAADA"|]
        }
        rw.Write(file)
    
    [<Test>]
    member this.TestFilesWriteNew() = 
        let rw = new Files.MyFileRW()
        let file = { 
            Files.filename = "/home/quziel/Repos/files/output/out001.txt";
            Files.containingFolder = { path = "/home/quziel/Repos/files/output"};
            Files.lines = [|"AADDIIA"; "AAAAADI"; "DDAAADA"|]
        }
        rw.Write(file)