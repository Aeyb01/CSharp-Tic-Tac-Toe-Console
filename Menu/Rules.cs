// Menu Folder

// Rules.cs

namespace TicTacToe
{
    class Rules
    {
        public static void ShowRules()
        {
            Console.WriteLine("There are three rows in this game");
            Console.WriteLine("Each row is called (from up to bottom) A, B, and C");
            Console.WriteLine("For example if you want to put an X on the left upper corner");
            Console.WriteLine("You simple write A1!");
            Console.WriteLine("And the same for the right lower corner!");
            Console.WriteLine("You simply write C3!");
            ExitPrompt.ShowExitPrompt();
        }
    }
}