namespace StudentScores

open System

module Float =
    let tryFromString (s: String) =
        if s = "N/A" then
            None
        else
            float s |> Some
