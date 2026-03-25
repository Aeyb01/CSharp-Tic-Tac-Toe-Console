// Core Folder

// TurnBaseLogic.cs

// This script validates the turn base system

// Decide which one's turn it is and passes from one player to anohter

// Here we take the return of Toss.cs script and alternate

// Between the two players

// It's the turn management brain

using System;

namespace TicTacToe
{
    public class TurnBaseLogic
    {
        public static Players GetNextPlayer(Players CurrentPlayer)
        {
            if (CurrentPlayer == Players.Player1)
            {
                return Players.Player2;
            }
            else
            {
                return Players.Player1;
            }
        }


        public static void NextTurn()
        {
            Console.WriteLine($"Turn: {RuleEngine.Turn}");
       
            RuleEngine.Turn++;
        }
    }
}