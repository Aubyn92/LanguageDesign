using System;

namespace Pacman
{
    public class Block
    {
        private bool _topBorder;
        private bool _rightBorder;
        private bool _bottomBorder;
        private bool _leftBorder;
        public bool HasDot { get; private set; }

        public Block(bool topBorder, bool rightBorder, bool bottomBorder, bool leftBorder)
        {
            _topBorder = topBorder;
            _rightBorder = rightBorder;
            _bottomBorder = bottomBorder;
            _leftBorder = leftBorder;
            HasDot = true;
        }

        public bool IsTopBorderAWall()
        {
            return _topBorder;
        }

        public bool IsRightBorderAWall()
        {
            return _rightBorder;
        }

        public bool IsBottomBorderAWall()
        {
            return _bottomBorder;
        }

        public bool IsLeftBorderAWall()
        {
            return _leftBorder;
        }

        public void RemoveDot()
        {
            HasDot = false;
        }
    }
}