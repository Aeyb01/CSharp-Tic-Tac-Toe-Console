// Menu Folder

// PostGame.cs

namespace TicTacToe
{
    public class PostGame
    {
        public static void HandlePostGameMenu()
        {
            Console.WriteLine("Write Replay to restart the game.");
            Console.WriteLine("Write Return to return to menu.");
            Console.WriteLine("Write Exit to close the program.");

            while (true)
            {
                Console.Write("Choose: ");
                string UserSelection = (Console.ReadLine() ?? "").ToLower();

                switch (UserSelection)
                {
                    case "replay":
                        Launch.Start();
                        break;
                    
                    case "return":
                    MenuHandler.MenuController();
                        break;
                    
                    case "exit":
                        ExitPrompt.GetExitInput();
                        break;
                    
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }          
            }
        }
    }
}