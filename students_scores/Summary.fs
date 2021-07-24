namespace StudentScores

open System.IO
open StudentScores

module Summary =
    let getScoreKey (student: Student) = student.MeanScore
    let getNameKey (student: Student) = student.GivenName

    let summarize filePath =
        printfn "Processing %s" filePath
        let rows = File.ReadAllLines filePath
        let studentsCount = (rows |> Array.length) - 1
        printfn "Students count %i" studentsCount

        rows
        |> Array.skip 1 // header
        |> Array.map Student.fromString
        |> Array.sortBy getNameKey
        |> Array.iter Student.printSummary
