// Board Folder

// Board.cs

using System;

namespace TicTacToe
{
    public class Board
    {
        public static void DrawBoard(CellState[,] Board)
        {
            Console.Clear();
            Console.ResetColor();

            // Pour montrer quelque chose fixé sur le console
            // Il faut pas utiliser des boucle ou des méthodes
            // C'est de Over-Engineering
            // Il suffit d'utiliser de print!

            // Dessiner le tableau

            // Affichage
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.Write("║   ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("T I C        T A C        T O E");
            Console.ResetColor();
            Console.WriteLine("    ║");
            Console.WriteLine("╠════════════╦════════════╦════════════╣");


            for (int row = 0; row < 3; row++)
            {
                
                Console.Write("║   ");
                PrintCell(Board[row, 0]);
                Console.Write(" ║   ");
                PrintCell(Board[row, 1]);
                Console.Write(" ║   ");
                PrintCell(Board[row, 2]);
                Console.WriteLine(" ║");

                if (row < 2)
                {
                    Console.WriteLine("╠════════════╬════════════╬════════════╣");
                }
            }

            Console.WriteLine("╚════════════╩════════════╩════════════╝");
        }

        static void PrintCell(CellState cell)
        {
            switch(cell)
            {
                case CellState.X:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                
                case CellState.O:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            Console.Write($"{cell,-8}");
            Console.ResetColor();
        }
    }
}
/*

    OVER ENGINEERING

            for (int rows = 0; rows < 3; rows++)
            {
                // I need to make this line right below runs ONLY once
                // but how?!?!?!?!?!?
                Console.Write("╔");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(" . ");
                }
                Console.Write("║");
                Console.WriteLine("");

            }
            */