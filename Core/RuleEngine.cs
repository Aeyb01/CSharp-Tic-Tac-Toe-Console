// Core Folder

// RuleEngine.cs

// RuleEngine script takes the return of the Toss script

// And initiates the game based on the winner

// This is the brain of the game that handles the entire logic

// Validates which squares are taken and which ones are still remaining

// Decide which one won

using System;
using System.Formats.Tar;

namespace TicTacToe
{
public enum GameState
{
    InProgress,
    Draw,
    XWins,
    OWins
}
    public class RuleEngine
    {
        // Plus tard demande à l'IA d'expliquer cette partie
        private static int _turn = 0;

        public static int Turn
        {
            get { return _turn; }
            set
            {
                if (value > 10) throw new InvalidOperationException("Max 9 turns.");
                _turn = value;
            }
        }
        public void ruleEngine(GameMode gameMode)
        {
            Turn = 1;
            
            GameManager gameManager = new GameManager();

            BoardData board = new BoardData();

            Players CurrentPlayer = new Players();

            gameManager.GameLoop(gameMode, CurrentPlayer, board);
        }

        public static GameState CheckWin(BoardData board)
        {
            // Cette méthode est censé de vérifier les condition de gagner

            // Il y a huit conditions de gagenr en X / O
            // Donc il faut vérifier les lignes horizontales
            // Les lignes verticales et les lignes diagonales

            // On vérifie les lignes et les colonnes

            Console.WriteLine($"DEBUG Turn dans CheckWin: {Turn}");

            for(int i = 0; i < 3; i++)
            {
                // Lignes
                if (board.board[i, 0] != CellState.Empty &&
                    board.board[i, 0] == board.board[i, 1] &&
                    board.board[i, 1] == board.board[i, 2])
                {
                    return board.board[i, 0] == CellState.X ? GameState.XWins : GameState.OWins;
                }
                // Colonnes
                if (board.board[0, i] != CellState.Empty &&
                    board.board[0, i] == board.board[1, i] &&
                    board.board[1, i] == board.board[2, i])
                {
                    return board.board[i, 0] == CellState.X ? GameState.XWins : GameState.OWins;
                }

                // Diagonale principale
                if (board.board[0, 0] != CellState.Empty 
                    && board.board[0, 0] == board.board[1, 1] &&
                    board.board[1, 1] == board.board[2, 2])
                {                   
                    return board.board[i, 0] == CellState.X ? GameState.XWins : GameState.OWins;
                }    

                // Diagonale secondaire
                if (board.board[0, 2] != CellState.Empty &&
                    board.board[0, 2] == board.board[1, 1] && 
                    board.board[1, 1] == board.board[2, 0])
                {
                    return board.board[i, 0] == CellState.X ? GameState.XWins : GameState.OWins;
                }
            }
            
            if (Turn == 10)
            {
                // Pas besoin d'une boucle for
                // Si on est dans le dixème tour sans avoir
                // aucun gagnant c'est un match nul

                return GameState.Draw;
            }

            return GameState.InProgress;
        }
    }
}