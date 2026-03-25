// Players Folder

// HumanPlayer.cs

namespace TicTacToe
{
    public class HumanPlayer : PlayerBase
    {
        public override (int row, int col) Play(GameMode gameMode, Players CurrentPlayer, BoardData board)
        {
            // Here we prompt the player for their input and parse it
            return PlayerInputHandler.GetCoordination(gameMode, CurrentPlayer, board);
        }
    }
}