using System.Collections.Generic;

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
            var userInput = _io.Input();
            result = inputRef[userInput];
            return result;
        }
    }
}