// Utils Folder

// ConsoleWinNotifier.cs

// This script exist in order to separate UI
// From game logic


#nullable enable

namespace TicTacToe
{
    public class ConsoleNotifier
    {
        public static void NotifyResult(string Message) => Console.WriteLine(Message);

        public static void RestartTheGame() => Console.Write("Would you like to restart the game?");

    }
}