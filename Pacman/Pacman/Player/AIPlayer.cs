using System.Collections.Generic;

namespace Pacman
{
    public class AIPlayer : IPlayer
    {
        private IRandom _randomiser;

        public AIPlayer(IRandom randomiser)
        {
            _randomiser = randomiser;
        }

        public Direction DecideNextMove(List<Direction> listOfDirections)
        {
            var chosenDirection = _randomiser.SelectRandomDirection(listOfDirections);
            return chosenDirection;
        }
    }
}