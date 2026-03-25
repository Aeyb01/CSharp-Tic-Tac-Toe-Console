// Menu Folder

// EnterChoice.cs

// This script is meant to navigate through the menu
// Based on the player's choice

using System;

namespace TicTacToe
{
    public class EnterChoice
    {
        public static void Entering(Options Option)
        {
            switch(Option)
            {
                case Options.Play:
                    Launch.Start();
                    break;
                
                case Options.Leaderboard:
                    LeaderBoardMenu.ShowLeaderBoard();
                    break;
                
                case Options.Rules:
                    Rules.ShowRules();
                    break;

                case Options.Save:
                    SaveMenu.ShowSaveMenu();
                    break;
                
                case Options.Exit:
                    Console.WriteLine("Exiting The Game...");
                    break;

                default:
                    return;
            }
        }
    }
}