// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.IO
open StudentScores

[<EntryPoint>]
let main argv =
    if argv.Length > 0 then
        let studentScoresFilePath = argv.[0]
        let schoolCodesFilePath = argv.[1]
        let studentScoresFilePathExist = File.Exists studentScoresFilePath
        let schoolCodesFileExist = File.Exists schoolCodesFilePath

        if studentScoresFilePathExist && schoolCodesFileExist then
            try
                Summary.summarize schoolCodesFilePath studentScoresFilePath
                0
            with
            | :? FormatException as e ->
                printfn "Error: %s %A" e.Message e.StackTrace
                printfn "Please specify a valid format for student"
                1
            | :? IOException as e ->
                printfn "Error: %s %A" e.Message e.StackTrace
                printfn "Can't be opened at this time"
                2
            | e ->
                printfn "Error: %s %A" e.Message e.StackTrace
                3

        else
            printfn "Please specify a correct file"
            4

    else
        printfn "Please specify a file"
        5
