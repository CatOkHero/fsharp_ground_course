namespace ColorHistory

open System.Drawing

type ColorHistory(initialColors: seq<Color>, maxElements: int) =
    let mutable colors =
        initialColors
        |> Seq.truncate maxElements
        |> Seq.distinct
        |> List.ofSeq

    member this.Colors() = colors |> Seq.ofList

    member this.TryLatestColor() =
        match colors with
        | head :: _ -> head |> Some
        | [] -> None

    member this.RemoveLatest() =
        match colors with
        | _ :: tail -> colors <- tail
        | [] -> ()

    member this.Add(color: Color) =
        let colors' =
            color :: colors
            |> List.truncate maxElements
            |> List.distinct

        colors <- colors'
