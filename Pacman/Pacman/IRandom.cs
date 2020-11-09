using System.Collections.Generic;

namespace Pacman
{
    public interface IRandom
    {
        Direction SelectRandomDirection(List<Direction> listOfDirections);
    }
}