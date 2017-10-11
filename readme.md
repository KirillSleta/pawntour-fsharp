# Pawn's Path

A pawn can move on 10x10 chequerboard horizontally, vertically and diagonally by these rules:  

1) 3 tiles moving North (N), West (W), South (S) and East (E) 
2) 2 tiles moving NE, SE, SW and NW 
3) Moves are only allowed if the ending tile exists on the board 
4) Starting from initial position, the pawn can visit each cell only once 

Write a program that finds at least one path for the pawn to visit all tiles on the board following the above rules, starting from any tile. 

In fact, a given task is a variation of the Knight's Tour problem (https://en.wikipedia.org/wiki/Knight%27s_tour) and it is an instance of the more general Hamiltonian path problem in graph theory. The problem of finding a closed knight's tour is similarly an instance of the Hamiltonian cycle problem.
https://en.wikipedia.org/wiki/Hamiltonian_path_problem

In the mathematical field of graph theory, the Hamiltonian path problem and the Hamiltonian cycle problem are problems of determining whether a Hamiltonian path (a path in an undirected or directed graph that visits each vertex exactly once) or a Hamiltonian cycle exists in a given graph (whether directed or undirected). Both problems are NP-complete.[1]

So, let's apply the following algorithm from Knight's Tour problem:

### Backtracking
Backtracking works in an incremental way to attack problems. Typically, we start from an empty solution vector and one by one add items (Meaning of item varies from problem to problem. In the context of current task problem, an item is a paw's move). When we add an item, we check if adding the current item violates the problem constraint, if it does then we remove the item and try other alternatives. If none of the alternatives work out then we go to the previous stage and remove the item added in the previous stage. If we reach the initial stage back then we say that no solution exists. If adding an item doesn’t violate constraints then we recursively add items one by one. If the solution vector becomes complete then we print the solution.

There is a pseudocode for backtracking solution:
```
If all squares are visited 
    return the solution
Else
   a) Add one of the next moves to solution vector and recursively 
   check if this move leads to a solution. (A Paw can make maximum eight moves. We choose one of the 8 moves in this step using rotation of the moves if necessary).
   b) If the move chosen in the above step doesn't lead to a solution
   then remove this move from the solution vector and try other 
   alternative moves.
   c) If none of the alternatives work then remove the previously added item in recursion and if false is 
   returned by the initial call of recursion then "no solution exists" 
   ```


### Warnsdorf's rule
Warnsdorf's rule is a heuristic for finding a knight's tour. The knight is moved so that it always proceeds to the square from which the knight will have the fewest onward moves. When calculating the number of onward moves for each candidate square, we do not count moves that revisit any square already visited. It is, of course, possible to have two or more choices for which the number of onward moves is equal; there are various methods for breaking such ties.
This rule may also more generally be applied to any graph. In graph-theoretic terms, each move is made to the adjacent vertex with the least degree. Although the Hamiltonian path problem is NP-hard in general, on many graphs that occur in practice this heuristic is able to successfully locate a solution in linear time.
