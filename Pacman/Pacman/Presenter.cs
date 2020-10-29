using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;

namespace Pacman
{
    public class Presenter
    {
        private IInputOutput _io;

        private const string dotSymbol = ".";
        private const string monsterSymbol = "👻";

        private static readonly Dictionary<Direction, string> pacmanSymbol = new Dictionary<Direction, string>
        {
            {Direction.North, "V"},
            {Direction.South, "∧"},
            {Direction.East, "<"},
            {Direction.West, ">"}
        };

        public Presenter(IInputOutput inputOutput)
        {
            _io = inputOutput;
        }

        public void PrintMap(Square[,] twoDMap, List<ICharacter> characters)
        {
            var numberOfRows = twoDMap.GetLength(0);
            var numberOfColumns = twoDMap.GetLength(1);
            var stringToPassIn = "";
            
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {

                    stringToPassIn += AssignSymbol(characters, row, column, twoDMap);
                }

                if (row < numberOfRows -1)
                {
                    stringToPassIn += "\n";
                }
            }

            _io.Output(stringToPassIn);
        }

        private string AssignSymbol(List<ICharacter> characters, int row, int column, Square[,] twoDMap)
        {
            foreach (var character in characters)
            {
                if (character.Location[0]==row && character.Location[1]==column)
                {
                    return AssignCharacterSymbol(character);
                }
            }

            return twoDMap[row, column].HasDot ? dotSymbol : " ";
        }

        private string AssignCharacterSymbol(ICharacter character)
        {
            if (character is Pacman)
            {
                return pacmanSymbol[character.FacingDirection];
            }

            return monsterSymbol;
        }
    }
}