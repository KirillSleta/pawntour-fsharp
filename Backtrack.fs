namespace Example

module public Backtrack =
    open Example.CommonLibrary
    let defaultDirection = Direction.N

    type Rotation = | Right | Left

    type Backtrack(dim : int)=
        inherit BaseAlgo(dim)

        let movesInDirection (moves, direction) =
            match direction with
                | defaultDirection -> List.map (fun (d, m) -> m) moves
                | _ -> 
                    let index = Seq.findIndex (fun (d:Direction, m:Move) -> d.Equals(direction)) moves
                    List.map (fun (d, m) -> m) moves

        let rotateMoves = 
            match CommonLibrary.Moves with
                | head :: tail -> List.map (fun (d, m) -> m) tail @ [snd head]
                | [] -> []

        let nextMoves (path:Path) :seq<Move> =
            validMoves(path, rotateMoves)

        let mag = base.Mag

        let rec findPathRec(prevPath:Path, moves:Path->seq<Move>):Path = 
            let nextMoves = Seq.toList (moves prevPath)
            if nextMoves.IsEmpty then prevPath
            else
                let lastTile = Seq.last prevPath
                let nextPathes :Path list = 
                    List.map (fun move-> findPathRec(prevPath @ [nextTile(lastTile, move)], moves)) nextMoves
                let result:Path list = List.filter (fun nPath -> nPath.Length = mag) nextPathes
                match result with
                | []    ->  List.maxBy (fun i-> i.Length) nextPathes
                | l     ->  l.Head

        override this.FindPath (startTile:Tile):Path = 
            let moves = movesInDirection(CommonLibrary.Moves, defaultDirection)
            let path:Path = [startTile]
            findPathRec(path, nextMoves)

        