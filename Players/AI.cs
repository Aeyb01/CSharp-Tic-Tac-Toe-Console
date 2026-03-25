// Players Folder

// AI.cs

// This script is called whenever the player chooses P1 option
// Player will be playing against AI
// It ONLY generates ONE random coordination
// It ONLY returns the AI's coordination

using System;

namespace TicTacToe
{
    public class AI : PlayerBase
    {
        static Random random = new Random();
        public override (int row, int col) Play(GameMode gameMod, Players CurrentPlayer, BoardData board)
        {

            Console.WriteLine("Playing against AI.");
            Thread.Sleep(2000);

            int row;
            int col;

            do
            {
                row = random.Next(0, 3);
                col = random.Next(0, 3);
                
            } while (board.board[row, col] != CellState.Empty);

            return (row, col);
        }
    }
}