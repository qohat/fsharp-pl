module AdapterConfigTest

open NUnit.Framework
open Config
open System

[<TestFixture>]
type TestClass() =

    [<Test>]
    member this.TestConfig() = 
        let actual = getConfig
        let expected = { 
            Config.inputFolder = "/home/quziel/Repos/files/input";
            Config.outputFolder = "/home/quziel/Repos/files/output"
        }
        Assert.That(actual, Is.EqualTo(expected))

    [<Test>]
    member this.TestConfigWithEnv() =
        Environment.SetEnvironmentVariable("INPUT_FOLDER", "/home/quziel/Repos/files/input")
        Environment.SetEnvironmentVariable("OUTPUT_FOLDER", "/home/quziel/Repos/files/output")
        let actual = getConfig
        let expected = { 
            Config.inputFolder = "/home/quziel/Repos/files/input";
            Config.outputFolder = "/home/quziel/Repos/files/output"
        }
        Assert.That(actual, Is.EqualTo(expected))