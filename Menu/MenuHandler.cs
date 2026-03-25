// Menu Folder

// MenuHandler.cs

namespace TicTacToe
{
    public class MenuHandler
    {
        public static void MenuController()
        {
            Menu.DisplayMenu();
            MenuChoice GameChoice = new MenuChoice();
            Options PlayerChoice = GameChoice.Choice();
            
            EnterChoice.Entering(PlayerChoice);
        }
    }
}