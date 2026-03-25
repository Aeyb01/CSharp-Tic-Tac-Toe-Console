// Core Folder

// GameManager.cs

// The Orchestror of the game flow

using System;

namespace TicTacToe
{
    public class GameManager
    {
        public void GameLoop(GameMode gameMode, Players CurrentPlayer, BoardData board)
        {
            // On déclare ces deux variable comme des `IPlayer` pour gagner du Polymorphisme
            // Si le joueur choisissait le mode hors ligne le deuxième joueur serait automatiquement
            // IA sinon un autre joueur !
            PlayerBase player1 = new HumanPlayer();
            PlayerBase player2 = gameMode == GameMode.PvPMode ? new HumanPlayer() : new AI();
            
            // On met la condition du gagnant
            GameState Condition;

            // Which player starts first? We need to initiate the toss
            CurrentPlayer = Toss.DecideFirstPlayer(gameMode);

            bool IsOver;

            while (true)
            {
                // Now after we know which player starts we need to 
                // Initiate the game as like prompt him for which coordination
                // However before we do anything we'll have to show the board to the player
                Board.DrawBoard(board.board);
                
                // Now we start the turn logic
                TurnBaseLogic.NextTurn();

                // Ici on crée une instance de type `PlayerBase` dans le but de faciliter 
                // L'accés de ses composants, en particuler `CellSet`
                // C'est parce qu'on crée un objet hérité d'une classe
                // Il serait capable d'accéder toutes ces composants
                // Sans être très précis !

                PlayerBase currentPlayerObj = CurrentPlayer == Players.Player1 ? player1 : player2;

                currentPlayerObj.CellSet(gameMode, CurrentPlayer, board);

                // Avant d'alterner entre les tours il faut vérifier le gagnant
                Condition = RuleEngine.CheckWin(board);
                                
                IsOver = GameResult.IsGameOver(Condition);

                if (IsOver == true)
                {
                    GameOver(gameMode, Condition, board, player1, player2);
                    break;
                }

                // Now we alternate between the turns and the players
                CurrentPlayer = TurnBaseLogic.GetNextPlayer(CurrentPlayer);

            }                                 
        }





        void GameOver(GameMode gameMode, GameState Condition, BoardData board, PlayerBase player1, PlayerBase player2)
        {
            // This method manages the GAME OVER logic
            // It's the brain of that logic

            // First of all we update the leaderboard
            // but to do that first we'll need to call retourn winner
            // from game result script
            Players? Winner = GameResult.GetWinner(gameMode, Condition);

            if (Winner != null)
            {
                // When's the value is potantially null we nee to
                // use the forst variable.Value
                LeaderBoard.UpdateScore(Winner.Value);
            }

            Board.DrawBoard(board.board);

            ConsoleNotifier.NotifyResult(GameResult.GetWinMessage(gameMode, Condition)!);

            // Now we show the players' their scors
            Console.WriteLine($"Player 1 score's: {LeaderBoard.Player1Score}");

            if(player2 is HumanPlayer)
            {
                Console.WriteLine($"Player 2 score's: {LeaderBoard.Player2Score}");
            }
            else
            {
                Console.WriteLine($"AI score's: {LeaderBoard.AIScore}");
            }

            PostGame.HandlePostGameMenu();

        }
    }
}