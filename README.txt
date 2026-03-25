====================================================
TIC TAC TOE — C# Console
====================================================

DESCRIPTION
-----------
Tic Tac Toe game built in pure C# console.
Two modes: player vs AI or player vs player.
Object-oriented architecture with strict separation
between logic, display, and input.
Scores are saved between sessions via JSON.

HOW TO PLAY
-----------
1. Launch the program.
2. Choose "Play" from the menu.
3. Choose a mode: OfflineMode (vs AI) or PvPMode (vs player).
4. Enter a coordinate to play: A1, B2, C3, etc.
   - Letters: A (row 1), B (row 2), C (row 3)
   - Numbers: 1 (col 1), 2 (col 2), 3 (col 3)
5. Type "exit" during the game to return to the menu.
6. Scores are saved via the "Save" menu option.

FOLDER STRUCTURE
----------------
TicTacToe/
│
├── Core/         → Pure logic: RuleEngine, GameManager, Toss, TurnBaseLogic
├── Players/      → Players: HumanPlayer, AI, PlayerBase, IPlayer
├── Board/        → Grid: BoardData (state), Board (display)
├── Input/        → Input pipeline: reading, validation, parsing
├── Menu/         → Navigation: menu, rules, leaderboard, post-game
├── Data/         → Persistence: LeaderBoard, SaveGame, LoadGame, ScoreData
├── Utils/        → Shared utilities: ExitPrompt, Notifier, Intro
│
├── Launch.cs           → Starts the game after mode selection
├── GameModeSelector.cs → Prompts player to choose game mode
├── Rules.cs            → Displays game rules
└── Program.cs          → Entry point — kept as thin as possible


GLOBAL FLOW ASCII
-----------------

Program.Main()
     |
     +--> LoadGame.Load()          ← loads save.json if it exists
     +--> Intro.ShowIntro()
     |
     v
MenuHandler.MenuController()
     |
     v
EnterChoice.Entering()
     |
     v
Launch.Start()
     |
     +--> GameModeSelector  → GameMode
     +--> RuleEngine.ruleEngine()
               |
               +--> BoardData (empty grid)
               +--> Toss (who goes first?)
               |
               v
         GameManager.GameLoop()
               |
            [LOOP]
               |
               +--> Board.DrawBoard()
               +--> TurnBaseLogic.NextTurn()
               +--> PlayerBase.CellSet()
               |         |
               |    [HumanPlayer] → InputReader → Validator → Parser
               |    [AI]          → Random (empty cell)
               |
               +--> RuleEngine.CheckWin()
               |         |
               |    [InProgress] → GetNextPlayer() → loop
               |    [XWins / OWins / Draw]
               |
               v
         GameManager.GameOver()
               |
               +--> LeaderBoard.UpdateScore()
               +--> ConsoleNotifier.NotifyResult()
               +--> PostGame (Replay / Return / Exit)


JSON SAVING
-----------
  Save : LeaderBoard → ScoreData (DTO) → JsonSerializer → save.json
  Load : save.json → JsonSerializer → ScoreData (DTO) → LeaderBoard

  Why a DTO?
  JsonSerializer cannot read static properties from LeaderBoard.
  ScoreData is a temporary non-static container that bridges the two.


ARCHITECTURE — APPLIED PRINCIPLES
-----------------------------------
- Separation of concerns:
    Board.cs never modifies data.
    BoardData does not know how to display itself.

- Polymorphism (PlayerBase):
    HumanPlayer and AI are interchangeable.
    GameManager does not know which one it is calling.

- Single Responsibility:
    Each class does one thing.
    InputReader reads. InputValidator validates. CoordinateParser parses.
    SaveGame saves. LoadGame loads.

- DTO Pattern:
    ScoreData bridges static data and JSON serialization.

- Enums for state:
    CellState (X, O, Empty)
    GameState (InProgress, XWins, OWins, Draw)
    Players (Player1, Player2, AI)
    GameMode (OfflineMode, PvPMode)


WHAT'S LEFT TO DO
-----------------
[ ] Smarter AI (strategy instead of random)
[ ] Unit tests for RuleEngine.CheckWin()
