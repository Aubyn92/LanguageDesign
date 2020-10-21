using System.Data;

namespace Pacman
{
    public class Pacman
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

        public void Rotate(Direction direction)
        {
            UpdateDirection(direction);
            UpdateMouthStatus();
        }

        private void UpdateDirection(Direction direction)
        {
            FacingDirection = direction;
        }

        public void Move(int row, int column)
        {
            UpdateLocation(row, column);
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