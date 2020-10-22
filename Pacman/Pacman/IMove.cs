namespace Pacman
{
    public interface IMove
    {
        void Move(Direction direction, int row, int column);
    }
}