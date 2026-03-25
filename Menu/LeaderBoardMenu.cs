// Menu Folder

// LeaderBoardMenu.cs

namespace TicTacToe
{
    public class LeaderBoardMenu
    {
        public static void ShowLeaderBoard()
        {
            Console.WriteLine("=== LeaderBoard ===");
            Console.WriteLine($"Player 1: {LeaderBoard.Player1Score}");
            Console.WriteLine($"Player 2: {LeaderBoard.Player2Score}");
            Console.WriteLine($"AI      : {LeaderBoard.AIScore}");
            Console.WriteLine("==================");

            ResetPrompt();
            
        }

        static void ResetPrompt()
        {
            Console.WriteLine("Would you like to rest the Leaderboard?");
            
            Console.Write("Enter Yes or Return to return to the Menu: ");
            string Prompt = Console.ReadLine() ?? "";
            
            switch(Prompt.ToLower())
            {
                case "yes":
                    Confirmation();
                    break;
                
                default:
                    MenuHandler.MenuController();
                    break;
            }
        }
        
        static void Confirmation()
        {
            Console.WriteLine("Confirm your choice by write Yes.");

            Console.Write("Confirm: ");

            string Confirming = Console.ReadLine() ?? "";

            switch(Confirming.ToLower())
            {
                case "yes":
                    Console.WriteLine("Reseting...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    LeaderBoard.ResetLeaderBoard();
                    ShowLeaderBoard();
                    break;
                    
                default:
                    ResetPrompt();
                    break;
                    
            }
        }
    }
}