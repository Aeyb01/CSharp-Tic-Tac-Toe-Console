// Core Folder

// LeaderBoard.cs

namespace TicTacToe
{

    public class LeaderBoard
    {
        // We declare the scors as getters and setters
        // Thus they would never disappear
        public static int Player1Score { get; set; } = 0;
        public static int Player2Score { get; set; } = 0;
        public static int AIScore { get; set; } = 0;



        public static void UpdateScore(Players Winner)
        {
            // So this method is going to take the winner
            // And based on that it's going to update the 
            // The player's scors
            // We take the winner from GameResult.cs
            switch(Winner)
            {
                case Players.Player1:
                    Player1Score++;
                    break;
                
                case Players.Player2:
                    Player2Score++;
                    break;
                
                default:
                    AIScore++;
                    break;
            }
        }

        public static void ResetLeaderBoard()
        {
            Player1Score = 0;
            Player2Score = 0;
            AIScore = 0;
        }
    }
}