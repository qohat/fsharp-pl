module Main.CoreTests

open NUnit.Framework
open Move

[<TestFixture>]
type TestClass() =

    [<Test>]
    member this.TestRun() =
        let expected = {Move.x = {_x = -2}; Move.y = {_y = 1}; Move.dir = West}
        let actual = run ['A'; 'D'; 'A'; 'A'; 'I'; 'I'; 'A'; 'A'; 'A'; 'A'] 
                        {Move.x = {_x = 0}; Move.y = {_y = 0}; Move.dir = North}
        Assert.That(actual, Is.EqualTo(expected))