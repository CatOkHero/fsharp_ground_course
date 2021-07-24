namespace StudentScores

type Optional<'T> =
    | Something of 'T
    | Nothing

module Optional =
    let defaultValue (d: 'T) (optional: Optional<'T>) =
        match optional with
        | Something v -> v
        | Nothing -> d


type Point<'T> = { X: 'T; Y: 'T }

module Point =
    let inline moveBy (pointX: 'T) (pointY: 'T) (mover: Point<'T>) =
        { X = mover.X + pointX
          Y = mover.Y + pointY }
