// Utils Folder

// ExitPrompt.cs

namespace TicTacToe
{
    public class ExitPrompt
    {
        public static void ShowExitPrompt()
        {
            Console.Write("Write Exit to exit: ");
            GetExitInput();
        }
        
        public static void GetExitInput()
        {
            while (true)
            {                
                string? exit = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(exit))
                {
                    Console.WriteLine("Give a valid input.");
                    continue;
                }

                if (exit.ToLower() == "exit")
                {
                    Console.Clear();
                    MenuHandler.MenuController();
                }
                else
                {
                    Console.WriteLine("Give a valid input.");
                    continue;
                }
            }
        }
    }
}