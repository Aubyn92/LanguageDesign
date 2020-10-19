using System;

namespace Pacman
{
    public class Square
    {
        private bool _topBorder;
        private bool _rightBorder;
        private bool _bottomBorder;
        private bool _leftBorder;
        private bool _dot;

        public Square(bool topBorder, bool rightBorder, bool bottomBorder, bool leftBorder)
        {
            _topBorder = topBorder;
            _rightBorder = rightBorder;
            _bottomBorder = bottomBorder;
            _leftBorder = leftBorder;
            _dot = true;
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

        public bool CanRemoveDot()
        {
            if (_dot == true)
            {
                _dot = false;
                return true;
            }
            return false;
        }
    }
}