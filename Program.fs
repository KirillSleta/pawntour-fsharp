
open Example.CommonLibrary
open Example.Backtrack
open Example.Warnsdorff
open System

let printGrid (grid:int [,]) =
    let maxY = (Array2D.length1 grid) - 1
    let maxX = (Array2D.length2 grid) - 1
    
    for row in 0 .. maxY do
        for col in 0 .. maxX do
            Console.Write(String.Format("{0,3:###}",grid.[row, col]))
        Console.WriteLine()

let printPath(path:Example.CommonLibrary.Path, dim:int) = 
    let arr = Array2D.zeroCreate<int> dim dim
    let mutable index = 0
    for tile in path do
        index <- index + 1
        arr.[tile.y,tile.x] <- index
    printGrid arr
  

[<EntryPoint>]
let main argv =
    let dim = 10
    let algo = Example.Warnsdorff.Warnsdorff(dim)
    let path = algo.FindPath {x= 0;y= 0}
    printPath(path, dim)
    0 // return an integer exit code

