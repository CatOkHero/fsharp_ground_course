// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let sumOfSquareRoots (n: float) =
    let maxN = sqrt n |> int

    [| for i in 1 .. maxN do
           i * i |]
    |> Array.sum


type State = { N: int; Pn2: int; Pn1: int }

let pell =
    { N = 0; Pn2 = 0; Pn1 = 0 }
    |> Seq.unfold
        (fun state ->
            let pn =
                match state.N with
                | 0
                | 1 -> state.N
                | _ -> 2 * state.Pn1 + state.Pn2

            let n' = state.N + 1
            Some(pn, { N = n'; Pn2 = state.Pn1; Pn1 = pn }))

type Position = { X: int; Y: int }

let drunkardsWalk =
    let r = System.Random()
    let step () = r.Next(-1, 2)

    { X = 0; Y = 0 }
    |> Seq.unfold
        (fun position ->
            let xStep = step ()
            let yStep = step ()
            let x = xStep + position.X
            let y = yStep + position.Y
            let position' = { X = x; Y = y }
            Some(position', position'))

[<EntryPoint>]
let main argv =
    printfn "%i" (sumOfSquareRoots 1000.)
    printfn "pell %A" pell
    0 // return an integer exit code
