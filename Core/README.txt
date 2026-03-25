============================
CORE/ — The Brain of the Game
============================

PURPOSE
-------
This folder contains all the pure game logic.
No script here touches the display.
No script here reads user input.
It is the engine — it thinks, decides, and orchestrates.

SCRIPTS
-------
RuleEngine.cs
  - Entry point of the game session.
  - Initializes BoardData and launches GameManager.
  - Contains CheckWin(): checks all 8 win conditions.
  - Manages the turn counter (Turn).

GameManager.cs
  - Orchestrates the main game loop (while loop).
  - Decides who plays (Player1 or AI/Player2).
  - Calls TurnBaseLogic, Board, PlayerBase.CellSet().
  - Handles end of game via GameResult.

GameResult.cs
  - Interprets the GameState returned by CheckWin().
  - Returns the win/loss/draw message.
  - Determines who won (Player1, Player2, AI).

TurnBaseLogic.cs
  - Manages turn alternation.
  - NextTurn(): increments the counter.
  - GetNextPlayer(): returns the next player.

Toss.cs
  - Randomly decides who starts the game.
  - Returns Players.Player1, Players.Player2, or Players.AI.


ASCII FLOW
----------

Launch.Start()
     |
     v
RuleEngine.ruleEngine()
     |
     +--> BoardData (initialize grid)
     +--> Toss.DecideFirstPlayer()
     |
     v
GameManager.GameLoop()
     |
  [LOOP]
     |
     +--> Board.DrawBoard()          (display)
     +--> TurnBaseLogic.NextTurn()   (increment turn)
     +--> PlayerBase.CellSet()       (play the move)
     +--> RuleEngine.CheckWin()      (check victory)
     |         |
     |    [InProgress] --> GetNextPlayer() --> back to loop
     |         |
     |    [XWins / OWins / Draw]
     |         v
        GameManager.GameOver()
             |
             +--> LeaderBoard.UpdateScore()
             +--> ConsoleNotifier.NotifyResult()
             +--> PostGame.HandlePostGameMenu()
