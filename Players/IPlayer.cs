// Players Folder

// IPlayer.cs


namespace TicTacToe
{
    public interface IPlayer
    {
        (int row, int col) Play(GameMode gameMod, Players CurrentPlayer, BoardData board);
    }

}