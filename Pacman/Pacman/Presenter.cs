using System.ComponentModel;
using System.Data.Common;

namespace Pacman
{
    public class Presenter
    {
        private IInputOutput _io;

        private const char dotSymbol = '.';
        
        private const char pacmanSymbol = 'V';
        public Presenter(IInputOutput inputOutput)
        {
            _io = inputOutput;
        }

        public void PrintMap(Square[,] twoDMap, Pacman pacman)
        {
            var numberOfRows = twoDMap.GetLength(0);
            var numberOfColumns = twoDMap.GetLength(1);
            var stringToPassIn = "";
            
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {

                    stringToPassIn += AssignSymbol(pacman, row, column, twoDMap);
                }

                if (row < numberOfRows -1)
                {
                    stringToPassIn += "\n";
                }
            }

            _io.Output(stringToPassIn);
        }

        private char AssignSymbol(Pacman pacman, int row, int column, Square[,] twoDMap)
        {
            if (pacman.Location[0]==row && pacman.Location[1]==column)
            {
                return pacmanSymbol;
            }

            return twoDMap[row, column].HasDot ? dotSymbol : ' ';
        }
    }
}