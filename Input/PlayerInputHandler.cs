// Input Folder

// PlayerInputHandler.cs

// This script is the assembler of all the game user prompt files
// It's single responsability is returning the validated coordination

namespace TicTacToe
{
    public class PlayerInputHandler
    {
        public static (int row, int col) GetCoordination(GameMode gameMode, Players CurrentPlayer, BoardData board)
        {
            string PlayerInput;

            (int row, int col) = (0, 0);

            while (true)
            {
                // Here we prompt the user for the input
                PlayerInput = InputReader.ReadingInput(gameMode, CurrentPlayer);

                // Now we validate it
                try
                {
                    InputValidator.ValidatePlayerInput(PlayerInput);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                    continue;
                }
                
                // now we pass the validated input to CoordinateParser in order
                // To parse the coordination

                (row, col) = CoordinateParser.Parse(PlayerInput);
                
                // Now we validate whether the cell is empty or not
                try
                {
                    board.IsEmpty(row, col);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                    continue;
                }

                // After everything has succeeded we break out of the loop
                break;
            }
            return (row, col);
        }
    }
}