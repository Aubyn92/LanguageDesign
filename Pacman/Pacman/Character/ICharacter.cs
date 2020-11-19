namespace Pacman
{
    public interface ICharacter
    {
        public int[] Location { get; }
        public Direction FacingDirection { get; }
        void Move(Direction direction, int row, int column);
    }
}