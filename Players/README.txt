============================
PLAYERS/ — The Players
============================

PURPOSE
-------
This folder contains everything related to players.
It defines what a player is, how they play,
and differentiates a human from an AI.

SCRIPTS
-------
IPlayer.cs
  - Base interface.
  - Forces every player to implement Play().
  - Guarantees that HumanPlayer and AI are interchangeable.

PlayerBase.cs
  - Abstract class that inherits from IPlayer.
  - Contains CellSet(): shared logic for placing X or O.
  - Play() is abstract — each subclass implements it differently.

HumanPlayer.cs
  - Inherits from PlayerBase.
  - Play() calls PlayerInputHandler to read human input.

AI.cs
  - Inherits from PlayerBase.
  - Play() randomly picks an empty cell.
  - Uses Random to generate (row, col).


WHY AN ABSTRACT CLASS?
-----------------------
HumanPlayer and AI share CellSet() — the logic for placing the symbol.
But Play() is different for each one.
PlayerBase avoids duplication while forcing each player
to define their own way of playing.


ASCII FLOW
----------

GameManager
     |
     v
PlayerBase.CellSet()
     |
     +--> Play()  <-- abstract
           |
           +--> [HumanPlayer] --> PlayerInputHandler.GetCoordination()
           |
           +--> [AI] --> random.Next() until empty cell found
     |
     v
board.SetCell(row, col, state)
