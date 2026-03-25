============================
INPUT/ — Player Input
============================

PURPOSE
-------
This folder handles everything related to user input during the game.
Each script has a single responsibility.
Together they form an input processing pipeline.

SCRIPTS
-------
InputReader.cs
  - Reads the raw player input from the console.
  - Displays the correct prompt based on game mode (OfflineMode / PvPMode).
  - Returns a raw string — no validation.

InputValidator.cs
  - Validates the string received from InputReader.
  - Checks that input is not empty.
  - Checks that input is a valid coordinate (a1-c3) or "exit".
  - Throws an ArgumentException if invalid.

CoordinateParser.cs
  - Converts the validated string into (int row, int col).
  - "a1" → (0,0), "b2" → (1,1), "c3" → (2,2), etc.
  - Does not validate — only receives already validated input.

PlayerInputHandler.cs
  - Assembler of the full pipeline.
  - Contains the while loop that repeats until valid input is received.
  - Calls in order: InputReader → InputValidator → CoordinateParser.
  - Also checks if the cell is empty via board.IsEmpty().
  - Returns (int row, int col) ready to use.


ASCII FLOW
----------

PlayerInputHandler.GetCoordination()
     |
     v
  [LOOP while(true)]
     |
     +--> InputReader.ReadingInput()          → raw string
     |
     +--> InputValidator.ValidatePlayerInput()
     |         |
     |    [invalid] → Console.WriteLine + continue
     |         |
     |    [valid]
     |
     +--> CoordinateParser.Parse()            → (row, col)
     |
     +--> board.IsEmpty(row, col)
     |         |
     |    [occupied] → Console.WriteLine + continue
     |         |
     |    [empty]
     |
     v
  break → return (row, col)
