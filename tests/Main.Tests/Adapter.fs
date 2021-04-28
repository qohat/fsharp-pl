module AdapterTest

open NUnit.Framework
open Adapter
open Move

[<TestFixture>]
type TestClass() =

    [<Test>]
    member this.TestFindAll() = 
        let repo = new MyRepository()
        let files = repo.FindAll
        Assert.That(files.Length, Is.EqualTo(3))

    [<Test>]
    member this.TestSave() = 
        let repo = new MyRepository()
        let shipper = {
            id = {id = "/home/quziel/Repos/files/output/in010.txt"}; 
            locations = List.map (fun line -> toLocation line) ["AAIDDDA"; "AAIDDDA"; "AAIDDAA"]
          }
        repo.Save shipper