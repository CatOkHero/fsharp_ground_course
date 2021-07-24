// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

let sayHello person =
    from person |> printfn "Hello %s from my F# program!" 

let isValid person =
    not(String.IsNullOrWhiteSpace person)

[<EntryPoint>]
let main argv =
    argv |> Array.filter isValid |> Array.iter sayHello
    printf "Nice to meet you"
    0 // return an integer exit code