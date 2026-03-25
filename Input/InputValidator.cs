// Input Folder

// InputValidator.cs

// This script valdiates the PlayerInput that the player has given
// During the game
// We take the input from InputReader in order to validate it

namespace TicTacToe
{
    public class InputValidator
    {
        public static void ValidatePlayerInput(string PlayerInput)
        {
            if (string.IsNullOrWhiteSpace(PlayerInput))
            {
                throw new ArgumentException("Invalid PlayerInput.");
            }

            PlayerInput = PlayerInput.ToLower();

            if (PlayerInput == "exit")
            {
                // This will be filled up later
                // Now returning to this at the end of my project XD
                Console.WriteLine("Exiting...");
                Thread.Sleep(2000);
                //Console.Clear();
                MenuHandler.MenuController();
                return;
            }

            char Letter = PlayerInput[0];
            char Number = PlayerInput[1];

            if (Letter < 'a' || Letter > 'c' || Number < '1' || Number > '3')
            {
                throw new ArgumentException("Invalid Player Input");
            }
        }
    }
}