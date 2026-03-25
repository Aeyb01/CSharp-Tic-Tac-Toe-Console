// Menu Folder

// SaveMenu.cs


namespace TicTacToe
{
    public class SaveMenu
    {
        public static void ShowSaveMenu()
        {
            Console.WriteLine("Would you like to save the game?");
            Console.Write("Enter Yes or No: ");
            string UserChoice = Console.ReadLine() ?? "";
            
            switch (UserChoice.ToLower())
            {
                case "yes":
                    Console.WriteLine("Saving...");
                    SaveGame.Save();
                    Thread.Sleep(2000);
                    Console.Clear();
                    MenuHandler.MenuController();
                    break;

                default:
                    Console.Clear();
                    MenuHandler.MenuController();
                    break;
            }
        }
    }
}