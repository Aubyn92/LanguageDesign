using System.Collections.Generic;

namespace Pacman
{
    public interface IPlayer
    {
        Direction DecideNextMove(List<Direction> listOfOptions);
    }
}