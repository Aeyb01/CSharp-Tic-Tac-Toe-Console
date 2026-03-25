// Players Folder

// PlayerBase.cs

// Quand on a une interface comme `IPlayer.cs et dont ses
// Sous-classes utilise une ou plusieurs méthode commune 
// Mais avec une fonction qui a une implémentation unique
// Pour chacune d'eux. Ainsi, il faut créer une classe abstraire
// Et les sous-classes de `IPLayer` hériterait ce celle-ci !

namespace TicTacToe
{
    public abstract class PlayerBase : IPlayer
    {
        // Cette méthode est abstraite parce que l'Humain et l'IA
        // A sa propre manière de l'implémenter
        // Chaque joueur doit définir comment jouer
        public abstract (int row, int col) Play(GameMode gameMode, Players CurrentPlayer, BoardData board);

        // Toutefois, la logique pour poser le symbole sur la grille est commune
        public void CellSet(GameMode gameMode, Players CurrentPlayer, BoardData board)
        {
            (int row, int col) = Play(gameMode, CurrentPlayer, board);
            
            // Here we decide the cell choice
            CellState state = CurrentPlayer == Players.Player1 ? CellState.X : CellState.O;

            // call board.SetCell to fill up the cell with the right input
            board.SetCell(row, col, state);
        }
    }
}