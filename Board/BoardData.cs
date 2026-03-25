// Board Folder

// BoardData.cs

// This script manages the data of the board
// Initialise cells, reads and updates 

namespace TicTacToe
{
    public enum CellState
    {
        X,
        O,
        Empty
    }
    public class BoardData
    {
        public CellState[,] board {get; private set;}



        public BoardData()
        {
            board = new CellState[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = CellState.Empty;
                }
            }
        }

        public void IsEmpty(int row, int col) // Check if the cell is Empty
        {
            if (board[row, col] == CellState.Empty)
            {
                return;
            }
            else
            {
                throw new ArgumentException("Cell is taken.");
            }
        }

        public void SetCell(int row, int col, CellState state)
        {
            // C'est la méthode qui écrit la cellule 
            // RuleEngine est juste le cerveau du jeu
            // C'est l'un qui dit à cette méthode d'écire un X ou un O

            board[row, col] = state;
        }
    }
}