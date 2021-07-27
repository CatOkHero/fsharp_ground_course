namespace StudentScores

module SchoolCodes =
    open System.IO
    open System.Collections.Generic

    let loadFile (filePath: string) =
        let pairs =
            File.ReadAllLines filePath
            |> Seq.skip 1
            |> Seq.map
                (fun row ->
                    let elements = row.Split("\t")
                    let id = elements.[0] |> int
                    let name = elements.[1]
                    id, name)
        //KeyValuePair.Create(id, name))

        pairs |> Map.ofSeq |> Map.add 0 "(External)"
//new Dictionary<int, string>(pairs)
