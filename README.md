# Tic Tac Toe — C# Console

A fully functional Tic Tac Toe game built in pure C# console.  

The usage of AI was limited to organise and bettre structure my code and to "speed-up" the debugging process

---

## Features

- Play against AI or a friend (PvP mode)
- Colorful console board (X in red, O in blue)
- Turn-based system with random toss to decide who goes first
- Win detection (rows, columns, diagonals) and draw detection
- Leaderboard with persistent scores saved via JSON
- Full menu navigation (Play, Leaderboard, Rules, Save, Exit)

---

## How to Play

1. Clone the repository and open a terminal in the project folder.
2. Run the game:
   ```
   dotnet run
   ```
3. Choose a game mode:
   - `OfflineMode` — Play against AI
   - `PvPMode` — Play against a friend
4. Enter a coordinate to place your symbol:
   - Letters: `A` (row 1), `B` (row 2), `C` (row 3)
   - Numbers: `1` (col 1), `2` (col 2), `3` (col 3)
   - Example: `A1`, `B2`, `C3`
5. Type `exit` at any time to return to the menu.

---

## Project Structure

```
TicTacToe/
│
├── Core/         → Game logic: RuleEngine, GameManager, Toss, TurnBaseLogic
├── Players/      → Players: HumanPlayer, AI, PlayerBase, IPlayer
├── Board/        → Grid: BoardData (state), Board (display)
├── Input/        → Input pipeline: reading, validation, parsing
├── Menu/         → Navigation: menu, rules, leaderboard, post-game
├── Data/         → Persistence: LeaderBoard, SaveGame, LoadGame, ScoreData
├── Utils/        → Shared utilities: ExitPrompt, ConsoleNotifier, Intro
│
├── Launch.cs           → Starts the game after mode selection
├── GameModeSelector.cs → Prompts player to choose game mode
├── Rules.cs            → Displays game rules
└── Program.cs          → Entry point — kept as thin as possible
```

---

## Architecture Highlights

**Separation of concerns**  
`BoardData` stores the grid state. `Board` only displays it. Neither knows about the other's internals.

**Polymorphism**  
`HumanPlayer` and `AI` both inherit from `PlayerBase`. `GameManager` treats them identically — it doesn't care which one it's calling.

**Single Responsibility**  
Each class does one thing:  
`InputReader` reads → `InputValidator` validates → `CoordinateParser` parses.

**DTO Pattern**  
`JsonSerializer` cannot serialize static properties. `ScoreData` acts as a temporary non-static bridge between `LeaderBoard` and the JSON file.

```
Save : LeaderBoard → ScoreData → JSON file
Load : JSON file → ScoreData → LeaderBoard
```

---

## Requirements

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)

---

## What's Next

- [ ] Some comments are in French of which they'll be updated to English and removed in the future
- [ ] Smarter AI (strategy instead of random)
- [ ] Unit tests for `RuleEngine.CheckWin()`
- [ ] Port logic to Unity (keeping all game logic Unity-independent) / Or perhaps a GUI application

---

## Learning Context

This project is **Project 2** of a personal C# learning path.  
The goal is to master pure C# architecture and OOP before moving forward with advanced concepts
