// Program.cs

// Took me five 5 days to finis this project
// from 19/03/2026 => 24/03/2026

using System;

namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            // Main() needs to be always as thin as possible
            // Let's load the game first!
            LoadGame.Load();
            
            Console.ResetColor();
            Console.WriteLine("Hello world!");

            Intro.ShowIntro();

            MenuHandler.MenuController();
        }
    }
}