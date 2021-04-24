module MathService.Tests

open System
open NUnit.Framework
open MathService

[<TestFixture>]
type TestClass() =

    [<Test>]
    member this.TestMethodPassing() =
        let expected = "Hello Qohat"
        let actual = Say.hello "Qohat"
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.TestEvenSequence() =
        let expected = Seq.empty<int>
        let actual = MyMath.squaresOfOdds [2; 4; 6; 8; 10]
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.TestOnesAndEvens() =
        let expected = [1; 1; 1; 1]
        let actual = MyMath.squaresOfOdds [2; 1; 4; 1; 6; 1; 8; 1; 10]
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member public this.TestSquaresOfOdds() =
        let expected = [1; 9; 25; 49; 81]
        let actual = MyMath.squaresOfOdds [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
        Assert.That(actual, Is.EqualTo(expected))

//[<SetUp>]
//let Setup () =
//    ()

//[<Test>]
//let Test1 () =
//    Assert.Pass()
