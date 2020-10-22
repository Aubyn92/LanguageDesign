using System.Data;

namespace Pacman
{
    public class Pacman : IMove
    {
        public int[] Location { get; private set; }
        public Mouth MouthStatus { get; private set; }

        public Direction FacingDirection;

        public Pacman(int row, int column)
        {
            FacingDirection = Direction.North;
            Location = new int[] { row, column };
            MouthStatus = Mouth.Open;
        }

        private void UpdateDirection(Direction direction)
        {
            FacingDirection = direction;
        }

        public void Move(Direction direction, int row, int column)
        {
            UpdateLocation(row, column);
            UpdateDirection(direction);
            UpdateMouthStatus();
        }

        private void UpdateLocation(int row, int column)
        {
            Location[0] = row;
            Location[1] = column;
        }
        
        private void UpdateMouthStatus()
        {
            if (MouthStatus == Mouth.Closed)
            {
                MouthStatus = Mouth.Open;
                return;
            }

            MouthStatus = Mouth.Closed;
        }
    }
}

// ATTRIBUTES:
// lives
// points
// level
// dot count
// ghost count
// state

// METHODS:
// tick: updates pacman state in each step
// eat dot: regular or super type of dot as argument, +1 to point attr when dot eaten
// eat ghost: takes a ghost name as argument
// ghost count: stores statistics for each ghost as well as the total number of eaten ghosts
