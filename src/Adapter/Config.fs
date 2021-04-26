module Config

open System

type AdapterConfig = { inputFolder : string; outputFolder : string }

let private getEnv (name: string) (defaultValue: string): string =
    let value = Environment.GetEnvironmentVariable name
    match value with
        | null -> defaultValue
        | _ -> value

let getConfig: AdapterConfig = 
    {
        inputFolder = getEnv "INPUT_FOLDER" "/home/quziel/Repos/files/input";
        outputFolder = getEnv "OUTPUT_FOLDER" "/home/quziel/Repos/files/output"
    }