// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let quote symbol s = sprintf "%c%s%c" symbol s symbol

let singleQuote = quote '\''

let doubleQuote = quote '\"'

[<EntryPoint>]
let main argv =
    printfn "%s" (singleQuote "It was the best of times, it was the worst of times.")
    printfn "%s" (doubleQuote "It was the best of times, it was the worst of times.")
    0 // return an integer exit code
