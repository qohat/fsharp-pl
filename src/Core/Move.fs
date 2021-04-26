module Move

    type Id = Id of string

    type X = { _x : int }

    type Y = { _y : int }

    type Direction = 
           | North
           | South
           | East
           | West

    type Location = { x : X; y : Y; dir: Direction}

    type Shipper = Shipper of id: Id * locations: List<Location>

    let private turnRight (l: Location) : Location =
        match l with
        | { Location.x = _; Location.y = _; Location.dir = dir } when dir = North -> { l with dir = East}
        | { Location.x = _; Location.y = _; Location.dir = dir } when dir = East -> { l with dir = South}
        | { Location.x = _; Location.y = _; Location.dir = dir } when dir = South -> { l with dir = West}
        | { Location.x = _; Location.y = _; Location.dir = dir } when dir = West -> { l with dir = North}
        | _ -> l

    let private turnLeft (l: Location) : Location =
        match l with
        | { Location.x = _; Location.y = _; Location.dir = dir } when dir = North -> { l with dir = West}
        | { Location.x = _; Location.y = _; Location.dir = dir } when dir = West -> { l with dir = South}
        | { Location.x = _; Location.y = _; Location.dir = dir } when dir = South -> { l with dir = East}
        | { Location.x = _; Location.y = _; Location.dir = dir } when dir = East -> { l with dir = North}
        | _ -> l

    let private forward (l: Location) : Location =
        match l with
        | { Location.x = _; Location.y = y; Location.dir = dir } when dir = North -> {l with y = {_y = l.y._y + 1}}
        | { Location.x = _; Location.y = y; Location.dir = dir } when dir = South -> {l with y = {_y = l.y._y - 1}}
        | { Location.x = x; Location.y = _; Location.dir = dir } when dir = East -> {l with x = {_x = l.x._x + 1}}
        | { Location.x = x; Location.y = _; Location.dir = dir } when dir = West -> {l with x = {_x = l.x._x - 1}}
        | _ -> l

    let private move (c: char) (l: Location) : Location =
        match c with
        | 'A' -> forward l
        | 'D' -> turnRight l
        | 'I' -> turnLeft l
        | _ -> l

    let rec run (commands: List<char>) (l: Location) : Location =
        match commands with
        | []    -> l
        | h :: t  -> run t (move h l)
