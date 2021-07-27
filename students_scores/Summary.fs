namespace StudentScores

open System.IO
open StudentScores

module Summary =
    let getScoreKey (student: Student) = student.MeanScore
    let getNameKey (student: Student) = student.GivenName

    let summarize (schoolCodesFilePath: string) filePath =
        printfn "Processing %s" filePath
        let rows = File.ReadAllLines filePath
        let studentsCount = (rows |> Array.length) - 1
        printfn "Students count %i" studentsCount
        let schoolCodes = SchoolCodes.loadFile schoolCodesFilePath

        rows
        |> Array.skip 1 // header
        |> Array.map (Student.fromString schoolCodes)
        |> Array.sortBy getNameKey
        |> Array.iter Student.printSummary

    let grouppedSummarize (schoolCodesFilePath: string) filePath =
        printfn "Processing %s" filePath
        let rows = File.ReadLines filePath |> Seq.cache
        let studentsCount = (rows |> Seq.length) - 1
        printfn "Students count %i" studentsCount
        let schoolCodes = SchoolCodes.loadFile schoolCodesFilePath

        rows
        |> Seq.skip 1
        |> Seq.map (Student.fromString schoolCodes)
        |> Seq.groupBy (fun x -> x.SurName)
        |> Seq.sortBy (fun (key, _) -> key)
        |> Seq.iter
            (fun (key, students) ->
                let sortedStudents =
                    students
                    |> Array.ofSeq
                    |> Array.sortBy (fun x -> x.GivenName)

                Student.printGrupped key sortedStudents)
