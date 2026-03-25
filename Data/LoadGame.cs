// LoadGame.cs

using System.Text.Json;

namespace TicTacToe
{
    public class LoadGame
    {
        public static void Load()
        {
            // Now in order to lead the game we need to read the save file
            // HOWEVRE  we need to implement a verifying method on whether the 
            // file exists or not
            
            bool IsExisting = VerifySaveFile();

            if (IsExisting)
            {
                LoadFile();
            }
        }

        static bool VerifySaveFile()
        {
            return File.Exists("save.json");
        }

        static void LoadFile()
        {
            string JSON;
            ScoreData SavedScore;

            JSON = File.ReadAllText("save.json");

            // Now after we read the file we need to assign
            // Its values to the leaderboard to read them
            // But LeaderBoard values are static and the
            // Json deserializer needs a NON-STATIC variable
            // thus we'll use the container to store the 
            // read json file
            SavedScore = JsonSerializer.Deserialize<ScoreData>(JSON) ?? new ScoreData();
            // Celle-ci là-haut est une méthode de vérification SI toutes les varaibles
            // sont nulles OU ne sont pas existantes alors le programme
            // Assignerait les même valeur de `ScoreData` à `SaveScore`

            // Now we assign `SaveScore` to LeaderBoard.cs

            AssignScores(SavedScore);
        }

        static void AssignScores(ScoreData SavedScore)
        {
            LeaderBoard.Player1Score = SavedScore.Player1Score;
            
            LeaderBoard.Player2Score = SavedScore.Player2Score;

            LeaderBoard.AIScore = SavedScore.AIScore;
        }
    }
}