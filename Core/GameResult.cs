// Core Folder

// GameResult.cs

// So here we take the return of the CheckWin from RuleEngine
// In order to check for win condition
// If there's no winner yet the game would continue
// This is the brain of Win Logic

namespace TicTacToe
{
    public class GameResult
    {
        public static string? GetWinMessage(GameMode gameMode, GameState Condition)
        {
            return Condition switch
            {
                GameState.XWins => gameMode == GameMode.PvPMode ? "Player 1 Wins!" : "You won!",
                GameState.OWins => gameMode == GameMode.OfflineMode ? "You lost!" : "Player 2 wins!",
                GameState.Draw => "Draw.",
                _=> null
            };
        }
    
        // If game is still in progress we'll return FALSE
        public static bool IsGameOver(GameState Condition) => Condition != GameState.InProgress;

        public static Players? GetWinner(GameMode gameMode, GameState Condition)
        {
            // So first of all in order to know who actually won
            // We need to know the game mode in order to decide whether
            // It's going to be between an AI or a Player

            
            // Now we know that if the winner is X
            // that means it's Player1 else it's AI
            // Great I'll impliment it now
            // HOWEVER I should not forget about the draw situation !

            if (Condition == GameState.Draw)
            {
                return null;
            }
            else if(Condition == GameState.XWins)
            {
                return Players.Player1;
            }
            
            return gameMode == GameMode.OfflineMode ?
                    Players.AI : Players.Player2;
        }
    }
}