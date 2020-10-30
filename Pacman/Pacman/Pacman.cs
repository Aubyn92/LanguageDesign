using System.Data;

namespace Pacman
{
    public class Pacman : ICharacter
    {
        public int[] Location { get; private set; }
        public Mouth MouthStatus { get; private set; }

        public Direction FacingDirection { get; private set;}

        public Pacman(Direction direction, int row, int column)
        {
            FacingDirection = direction;
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

