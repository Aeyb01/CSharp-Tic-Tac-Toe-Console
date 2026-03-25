============================
BOARD/ — The Grid
============================

PURPOSE
-------
This folder separates the grid DATA from its DISPLAY.
BoardData stores and manages the state.
Board only displays — it never touches the data.

SCRIPTS
-------
BoardData.cs
  - Contains the CellState[3,3] array.
  - Initializes all cells to CellState.Empty.
  - IsEmpty(): checks if a cell is free, throws an exception otherwise.
  - SetCell(): writes X or O into a specific cell.

Board.cs
  - Receives CellState[,] and displays it in the terminal.
  - PrintCell(): colors X in red, O in blue, Empty in gray.
  - NEVER modifies data — read only.


GOLDEN RULE
-----------
Board.cs does not know who is playing.
Board.cs does not know if a cell is free.
Board.cs displays what it receives. That is all.


ENUM CellState
--------------
  X      → cell occupied by player X
  O      → cell occupied by player O
  Empty  → empty cell


ASCII FLOW
----------

BoardData
  [3x3 CellState array]
       |
       | board.board
       v
Board.DrawBoard()
       |
       +--> for each cell --> PrintCell()
                                  |
                                  +--> X     → Red
                                  +--> O     → Blue
                                  +--> Empty → Gray
