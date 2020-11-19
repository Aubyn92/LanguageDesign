using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Pacman
{
    public class ConsolePlayer : IPlayer
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
            string stringToOutput = ConstructDirectionInstructionMessage(listOfOptions);

            _io.Output(stringToOutput);
            string errorMessage;
            string userInput;
            do
            {
                errorMessage = "";
                userInput = _io.Input().ToLower();
                errorMessage += GenerateErrorMessage(listOfOptions, userInput);
                Print(errorMessage);

            } while (errorMessage != "");
            result = inputRef[userInput];
            return result;
        }

        private string ConstructDirectionInstructionMessage(List<Direction> listOfAvailableDirections)
        {
            var stringToOutput = "Please input a direction. Choose: ";
            foreach (var direction in listOfAvailableDirections)
            {
                var directionReference = inputRef.FirstOrDefault(directionReferencePair => directionReferencePair.Value == direction);
                stringToOutput += $"\n{directionReference.Key}" +
                                 $" = {directionReference.Value}";
            }

            return stringToOutput;
        }

        private string GenerateErrorMessage(List<Direction> listOfOptions, string userInput)
        {
            string errorMessage = GenerateInvalidInputMessage(userInput);
            if (errorMessage == "")
            {
                errorMessage = GenerateUnavailableMessage(userInput, listOfOptions);
            }

            return errorMessage;
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

        private string GenerateInvalidInputMessage(string userInput)
        {
            if (inputRef.ContainsKey(userInput.ToLower()))
            {
                return "";
            }
            return "Error. Please input valid option.";
        }
    }
}