using System;
using System.Collections.Generic;

namespace Pacman
{
    public class Randomiser : IRandom
    {
        public Direction SelectRandomDirection(List<Direction> listOfDirections)
        {
            var random = new Random();
            var index = random.Next(listOfDirections.Count);
            return listOfDirections[index];
        }
    }
}