============================
DATA/ — Persistence
============================

PURPOSE
-------
This folder manages data that must survive between game sessions:
scores and JSON saving/loading.

SCRIPTS
-------
LeaderBoard.cs
  - Stores scores for Player1, Player2, and AI.
  - UpdateScore(): increments the winner's score.
  - ResetLeaderBoard(): resets all scores to 0.
  - Scores are static properties (persist in memory during a session).

SaveGame.cs
  - Save(): serializes scores to JSON and writes them to save.json.
  - Uses ScoreData (DTO) as a temporary non-static container.
  - Called from SaveMenu when the player chooses to save.

ScoreData (DTO — inside Save.cs)
  - Temporary class that bridges LeaderBoard and JSON.
  - Why? JsonSerializer cannot serialize static properties.
  - Solution: copy scores into ScoreData, then serialize ScoreData.

LoadGame.cs
  - Load(): checks if save.json exists, reads the file, deserializes.
  - VerifySaveFile(): returns true if save.json exists.
  - LoadFile(): reads the JSON and reconstructs a ScoreData object.
  - AssignScores(): transfers values from ScoreData to LeaderBoard.
  - Called once at startup in Program.Main().


WHY A DTO (ScoreData)?
-----------------------
LeaderBoard uses static properties — necessary for the game architecture
(accessible everywhere without an instance).
But JsonSerializer cannot see static properties.
ScoreData is a temporary non-static object that bridges both directions:

  Save : LeaderBoard → ScoreData → JSON
  Load : JSON → ScoreData → LeaderBoard


ASCII FLOW
----------

[STARTUP]
Program.Main()
     |
     v
LoadGame.Load()
     |
     +--> VerifySaveFile()
     |         |
     |    [false] → nothing (scores default to 0)
     |    [true]
     |
     +--> LoadFile()
               |
               +--> File.ReadAllText("save.json")           → JSON string
               +--> JsonSerializer.Deserialize<ScoreData>() → ScoreData
               +--> AssignScores() → LeaderBoard updated


[END OF GAME]
GameManager.GameOver()
     |
     v
LeaderBoard.UpdateScore(Winner)
     |
     +--> Player1Score++  /  Player2Score++  /  AIScore++


[MANUAL SAVE]
SaveMenu → SaveGame.Save()
     |
     +--> ScoreData ← LeaderBoard (copy scores)
     +--> JsonSerializer.Serialize(ScoreData) → JSON string
     +--> File.WriteAllText("save.json", JSON)
