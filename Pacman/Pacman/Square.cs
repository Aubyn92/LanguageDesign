using System;

namespace Pacman
{
    public class Square
    {
        private bool _wall;
        private bool _wall2;

        public Square(bool isWall, bool isWall2)
        {
            _wall = isWall;
            _wall2 = isWall2;
        }

        public bool IsWall()
        {
            return _wall;
        }

        public bool IsRightBorderAWall()
        {
            return true;
        }
    }
}