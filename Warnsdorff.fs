namespace Example

module public Warnsdorff =
    open Example.CommonLibrary

    type WMove = int * Move

    type Warnsdorff(dim : int)=
        inherit BaseAlgo(dim)

        let selectMove (wmoves : WMove list):Move = 
            snd (List.minBy (fst) wmoves)

        let availableMoves = (List.map (snd) CommonLibrary.Moves)

        let nextMoves (path:Path):WMove list = 
            let moves = validMoves(path, availableMoves)
            let mvs =
                seq {for move in moves do
                            let nextPath:Path = path @ [nextTile((Seq.last path), move)]
                            let pathMoves = validMoves(nextPath, availableMoves)
                            yield (Seq.length pathMoves, move)
                            }
            Seq.toList mvs

        let mag = base.Mag

        let rec findPathRec(prevPath:Path, moves:Path->WMove list):Path = 
            let nextMoves =moves prevPath
            if nextMoves.IsEmpty then prevPath
            else
                let lastTile = Seq.last prevPath
                let move = selectMove nextMoves
                let path = prevPath @ [nextTile(lastTile, move)]

                let nextPath = findPathRec(path, moves)

                if (nextPath.Length = mag ||nextPath.Length > prevPath.Length) then nextPath
                else prevPath

        override this.FindPath (startTile:Tile):Path = 
            let path:Path = [startTile]
            findPathRec(path, nextMoves)