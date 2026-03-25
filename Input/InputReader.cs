// Input Folder

// InputReader.cs

// This script takes the player's input
// During the game and then it returns it
// We then pass it to InputValidator.cs to validate it
// After that we use CoordinateParser.cs in order to
// To parse the player's input

namespace TicTacToe
{
    public class InputReader
    {
        public static string ReadingInput(GameMode gameMode, Players CurrentPlayer)
        {
            string PlayerInput;

            if (gameMode == GameMode.OfflineMode)
            {
                Console.Write("Your Turn: ");
                PlayerInput = Console.ReadLine() ?? "";
            }
            else
            {
                if (CurrentPlayer == Players.Player1)
                {
                    Console.Write("Player 1 turn: ");
                    PlayerInput = Console.ReadLine() ?? "";
                }
                else
                {
                    Console.Write("Player 2' turn: ");
                    PlayerInput = Console.ReadLine() ?? "";
                }
            }
            return PlayerInput;
        }
    }
}