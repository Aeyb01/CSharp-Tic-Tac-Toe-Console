// Core Folder

// Toss.cs

// Toss script takes the return of the Player.cs script

// To determin which one's turn is whether it's AI or player

// And the same for PVP

// It gives a return of the turn winner of which we pass it to

// TurnBaseLogic.cs to alternate between Player1 and Player2

using System;

namespace TicTacToe
{
    public enum Players
    {
        // Repreasent who won the toss
        Player1,
        Player2,
        AI
    }


    class Toss
    {
        private static readonly Random random = new Random();

        // By creating this random instance outside of any method

        // we ensure that the sequence is always randomized

        // When the internet comes back ask AI for help with understanding
        
        // These exact keywords in the code line above `readonly`
        public static Players DecideFirstPlayer(GameMode UserSelection)
        {
            int roll = Randomize();

            if (UserSelection == GameMode.OfflineMode)
            {
                if (roll == 0)
                {
                    Console.WriteLine("You go first!");
                    return Players.Player1;
                }
                else
                {
                    Console.WriteLine("Opponent goes first!");
                    return Players.AI;
                }
            }

            else
            {
                if (roll == 0)
                {
                    Console.WriteLine("Player 1 go first!");
                    return Players.Player1;
                }
                else
                {
                    Console.WriteLine("Player 2 goes first!");
                    return Players.Player2;
                }
            }
        }

        private static int Randomize()
        {
            int roll = random.Next(2);
            return roll;
        }
    }
        
}