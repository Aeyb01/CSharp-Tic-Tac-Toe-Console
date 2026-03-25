// GameModeSelector.cs

// We use this script in order to give the player

// An option to whether play PvPMode or OfflineMode

// This class returns an Enum GameMode variable

// We pass it to the Toss script

// To decide which one's turn is

// This script is meant to ONLY let the player choose

// The Game Mode

using System;

namespace TicTacToe
{
    public enum GameMode
    {
        OfflineMode,
        PvPMode
    };

    public class GameModeSelector
    {
        // We need a reference to the Toss class
        // Ask: why do we even need it in the first place?
        // Why outside of a methond and not within it?
        //private static readonly Toss toss = new Toss();
        public GameMode SelectGameMode()
        {
            Console.WriteLine("Would you Like to play against AI or with a friend: ");
            
            GameMode Option;

            while (true)
            {        
                Console.Write("Choose between OfflineMode and PvPMode: ");
                string? Input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Input))
                {
                    continue;
                }

                try
                {
                    Option = GetGameMode(Input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                
                // The Toss happens right after the player selects a GameMode
                // And right before the starting of the game
                // Which means the Toss start RIGHT HERE
                break;
            }

            return Option;
        }

        GameMode GetGameMode(string Input)
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                throw new Exception("Invalid Input.");
            }
            string lower = Input.ToLower();

            return lower switch
            {
                "offlinemode" => GameMode.OfflineMode,
                "pvpmode" => GameMode.PvPMode,
                _=> throw new Exception("Error. Give a valid input.")
            };
        }
    }
}