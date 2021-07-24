namespace StudentScores

open System
open StudentScores

type Student =
    { SurName: String
      GivenName: String
      Id: String
      MeanScore: float
      MaxScore: float
      MinScore: float }

module Student =
    let getName (s: String) =
        let elements = s.Trim().Split(',')

        match elements with
        | [| surname; givenname |] ->
            {| Surname = surname
               GivenName = givenname |}
        | [| surname |] ->
            {| Surname = surname
               GivenName = "(None)" |}
        | _ -> raise (System.FormatException("Format is not allowed"))


    let fromOption defaultValue x =
        Float.tryFromString x
        |> Option.defaultValue defaultValue

    let fromString (s: String) =
        let elements = s.Split('\t')
        let name = getName (elements.[0])
        let studentId = elements.[1]

        let scores =
            elements
            |> Array.skip 2
            |> Array.map TestResults.fromString
            |> Array.filter TestResults.filterScores
            |> Array.map TestResults.effectiveScore

        let mean = scores |> Array.average

        let lowest = scores |> Array.min

        let highest = scores |> Array.max

        { SurName = name.Surname
          GivenName = name.GivenName
          Id = studentId
          MeanScore = mean
          MaxScore = highest
          MinScore = lowest }


    let printSummary (student: Student) =
        printfn
            "%s\t %s\t %s\t %0.1f\t min - %0.1f\t max - %0.1f\t"
            student.SurName
            student.GivenName
            student.Id
            student.MeanScore
            student.MinScore
            student.MaxScore
