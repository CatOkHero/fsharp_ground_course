// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.IO
open StudentScores

[<EntryPoint>]
let main argv =
    if argv.Length > 0 then
        let filePath = argv.[0]
        let fileExist = File.Exists filePath

        if fileExist then
            try
                Summary.summarize filePath
                0
            with
            | :? FormatException as e ->
                printfn "Error: %s" e.Message
                printfn "Please specify a valid format for student"
                1
            | :? IOException as e ->
                printfn "Error: %s" e.Message
                printfn "Can't be opened at this time"
                2
            | e ->
                printfn "Error: %s" e.Message
                3

        else
            printfn "Please specify a correct file"
            4

    else
        printfn "Please specify a file"
        5
