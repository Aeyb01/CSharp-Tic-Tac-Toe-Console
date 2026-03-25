// Core Folder

// Save.cs

using System.Text.Json;

namespace TicTacToe
{
    public class SaveGame
    {
        public static void Save()
        {
            // So in order to save the game scors we need to creat
            // A DTO "Data Transfere File" as it would be easier to
            // To save the scors in a dedicated file instead of removing
            // The static word from `LeaderBoard` class properties and change
            // The architecture of the code entirely
            
            ScoreData SavedScore = new ScoreData();

            SavedScore.Player1Score = LeaderBoard.Player1Score;
            SavedScore.Player2Score = LeaderBoard.Player2Score;
            SavedScore.AIScore = LeaderBoard.AIScore;

            // Here we convert the scors into JSON
            string JSON = JsonSerializer.Serialize(SavedScore);

            // Now we save the scors
            File.WriteAllText("save.json", JSON);
        }
    }

    public class ScoreData
    {
        // DTO class, its only objectif is to hold the properties of saving 
        // The scores
        // It's a temporary container that plays the role of
        // A bridge between the json file and the leaderboard score
        // why can't we connect the json file directly to the leaderboard?
        // It's because that the json deserializer needs a NON-STATIC variable
        // and leaderboard NEEDS to be static for a better achitecture
        // this this temprary container exists! 
        public int Player1Score {get; set;}
        public int Player2Score {get; set;}
        public int AIScore {get; set;}
    }
}