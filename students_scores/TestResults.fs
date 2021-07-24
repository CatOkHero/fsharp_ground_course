namespace StudentScores

open System

type TestResults =
    | Absent
    | Excused
    | Voided
    | Scored of float

module TestResults =
    let fromString (s: String) =
        if s = "A" then Absent
        elif s = "E" then Excused
        elif s = "V" then Voided
        else Scored(float s)

    let filterScores (testResults: TestResults) =
        match testResults with
        | Absent -> true
        | Excused -> false
        | Voided -> true
        | Scored x -> true

    let effectiveScore (testResults: TestResults) =
        match testResults with
        | Absent -> 0.0
        | Excused -> 50.0
        | Voided -> 50.
        | Scored x -> x
