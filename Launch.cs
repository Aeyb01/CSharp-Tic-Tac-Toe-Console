// Launch.cs

// Launches the game when the player chooses Play

namespace TicTacToe
{
    public class Launch
    {
        public static void Start()
        {
            GameModeSelector Selector = new GameModeSelector();
            GameMode gameMode = Selector.SelectGameMode();
            RuleEngine Engine = new RuleEngine();
            Engine.ruleEngine(gameMode);
        }
    }
}