// Menu Folder

// Menu.cs

using System;

namespace TicTacToe
{
    /*
        public enum Options
    {
        Play,
        Leaderboard,
        Exit
    };
    */
    class Menu
    {
        public static void DisplayMenu()
        {
            // Set console background colour
            Console.BackgroundColor = ConsoleColor.Black;

            // Set text / foreground colour;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine("Menu: ");

            // When the internet comes back as the AI for help on
            // How to convert an enum into an array and Understand
            // how it happens

            Console.WriteLine("Play");
            Console.WriteLine("Leaderboard");
            Console.WriteLine("Rules");
            Console.WriteLine("Save");
            Console.WriteLine("Exit");

            // A good practice to always reset the colour 
            // In order not to mess with the next bloc of code
            Console.ResetColor();
        }
    }
}