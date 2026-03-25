// Menu Folder

// MenuChoice.cs

// This file prompts the user to select an option

// From the provided ones and validates it

using System;

namespace TicTacToe
{
        public enum Options
    {
        Play,
        Leaderboard,
        Rules,
        Save,
        Exit
    };

    public class MenuChoice
    {
        public Options Choice()
        {
            Options UserSelection;

            while (true)
            {
                Console.Write("Choose: ");
                string? Input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Input))
                {
                    continue;
                }

                try
                {
                    UserSelection = ParseInput(Input);
                    break;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return UserSelection;
        }

        private Options ParseInput(string Input)
        {
            string lower = Input.ToLower();

            return lower switch
            {
                "play" => Options.Play,
                "leaderboard" => Options.Leaderboard,
                "rules" => Options.Rules,
                "save" => Options.Save,
                "exit" => Options.Exit,
                _=> throw new ArgumentException("Give a valid choice.")
            };
        }
    }
}