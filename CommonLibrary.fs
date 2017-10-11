namespace Example

[<AutoOpen>]
module CommonLibrary =
    type Direction =
        | N | NE | E | SE | S | SW | W | NW

    type Move = {x:int; y:int} 
    type Tile = {x:int; y:int} 
    type Path = Tile list

    [<AbstractClass>]
    type BaseAlgo(dim : int) =
        let mag = (dim * dim)
        member this.Mag = mag
        abstract member FindPath : Tile -> Path
    
    
    
    let Moves:List<Direction*Move> = [(N, {x= 0;y= -3}); (NE, {x= 2;y= -2}); (E, {x= 3;y=0}); (SE, {x=2;y=2});
        (S, {x=0;y=3}); (SW, {x= -2;y= 2}); (W, {x= -3;y=0}); (NW, {x= -2;y= -2})]

    let titleIsOnBoard (dim, tile) =
        tile.x >= 0 && tile.x < dim && tile.y >= 0 && tile.y < dim

    let nextTile (curentTile:Tile, move:Move): Tile =
        {x= curentTile.x + move.x; y = curentTile.y + move.y}

    let tileVisited path tile =
        Seq.contains tile path

    let moveIsValid (path:Path, move:Move):bool = 
        let lastTile = Seq.last path
        let tile = nextTile(lastTile, move)
        titleIsOnBoard (10, tile) && not (tileVisited path tile)
     
    let validMoves (path:Path, moves:seq<Move>): seq<Move> =
        Seq.filter (fun m -> moveIsValid (path, m) ) moves
