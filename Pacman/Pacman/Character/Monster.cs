namespace Pacman
{
    public class Monster : ICharacter
    {
        public int[] Location { get; private set; }

        public Direction FacingDirection { get; private set; }

        public Monster(int row, int column)
        {
            FacingDirection = Direction.North;
            Location = new int[] { row, column };
        }

        private void UpdateDirection(Direction direction)
        {
            FacingDirection = direction;
        }

        public void Move(Direction direction, int row, int column)
        {
            UpdateLocation(row, column);
            UpdateDirection(direction);
        }

        private void UpdateLocation(int row, int column)
        {
            Location[0] = row;
            Location[1] = column;
        }
    }
}
