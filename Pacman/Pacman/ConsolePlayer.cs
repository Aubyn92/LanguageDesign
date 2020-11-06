using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Pacman
{
    public class ConsolePlayer
    {
        private IInputOutput _io;

        private Dictionary<string, Direction> inputRef = new Dictionary<string, Direction>
        {
            {"a", Direction.West},
            {"w", Direction.North},
            {"s", Direction.South},
            {"d", Direction.East}
        };

        public ConsolePlayer(IInputOutput io)
        {
            _io = io;
        }

        public Direction DecideNextMove(List<Direction>listOfOptions)
        {
            Direction result;
            _io.Output("Please input a direction. Choose: \nw = North \ns = South \na = West \nd = East");
            var errorMessage = "";
            string userInput;
            do
            { 
                userInput = _io.Input().ToLower();
                errorMessage += GenerateUnavailableMessage(userInput, listOfOptions);
                Print(errorMessage);

            } while (errorMessage!="");
            result = inputRef[userInput];
            return result;
        }

        private void Print(string errorMessage)
        {
            _io.Output(errorMessage);
        }

        private string GenerateUnavailableMessage(string userInput, List<Direction> listOfOptions)
        {
            foreach (var direction in listOfOptions)
            {
                if (direction == inputRef[userInput])
                {
                    return "";
                }
            }

            return "Option not available; choose again.";
        }
    }
}