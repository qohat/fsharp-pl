module Main.CoreTests

open NUnit.Framework
open Move

[<TestFixture>]
type TestClass() =

    // Tests just work if in Core/Move.fs the access is not private.
    (* [<Test>]
    member this.TestTurnRight() =
        let expected = {Move.x = {_x = 0}; Move.y = {_y = 0}; Move.dir = Move.Direction.East}
        let actual = Move.turnRight {Move.x = {_x = 0}; Move.y = {_y = 0}; Move.dir = Move.Direction.North}
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.TestTurnLeft() =
        let expected = {Move.x = {_x = 0}; Move.y = {_y = 0}; Move.dir = Move.Direction.West}
        let actual = Move.turnLeft {Move.x = {_x = 0}; Move.y = {_y = 0}; Move.dir = Move.Direction.North}
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.TestForward() =
        let expected = {Move.x = {_x = 0}; Move.y = {_y = 1}; Move.dir = Move.Direction.North}
        let actual = Move.forward {Move.x = {_x = 0}; Move.y = {_y = 0}; Move.dir = Move.Direction.North}
        Assert.That(actual, Is.EqualTo(expected)) *)

    [<Test>]
    member this.TestRun() =
        let expected = {Move.x = {_x = -2}; Move.y = {_y = 1}; Move.dir = West}
        let actual = run ['A'; 'D'; 'A'; 'A'; 'I'; 'I'; 'A'; 'A'; 'A'; 'A'] 
                        {Move.x = {_x = 0}; Move.y = {_y = 0}; Move.dir = North}
        Assert.That(actual, Is.EqualTo(expected))