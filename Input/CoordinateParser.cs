// Input Folder

// CoordinateParser.cs

// This script takes the user's validated PlayerInput
// And parse the coordination

namespace TicTacToe
{
    public class CoordinateParser
    {
        public static (int row, int col) Parse(string PlayerInput)
        {
            // Dans cette méthode on savoir quel indice l'utilisateur a saisi
            // Puis on l'envoit vers `TranslateIndex` pour remplacer cette indice
            // spécifique par un caractère de type X ou un O

            // On initialise les coordinations ici

            int row;
            int col;

            // Détermine la ligne
            
            switch(PlayerInput[0])
            {
                case 'a':
                    row = 0;
                    break;

                case 'b':
                    row = 1;
                    break;

                default:
                    row = 2;
                    break;
            }

            // Détermine la colonne
            switch(PlayerInput[1])
            {
                case '1':
                    col = 0;
                    break;

                case '2':
                    col = 1;
                    break;

                default:
                    col = 2;
                    break;
            }

            return(row, col);
        }
    }
}