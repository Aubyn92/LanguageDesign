using System;
using Pacman;
using Xunit;

namespace PacmanTests
{
    public class SquareTest
    {
        public SquareTest()
        {
        }

        [Fact]
        public void ShouldReturnTrue_WhenTopOfSquareIsAWall()
        {
            var square = new Square(true, true, false, false);
            var result = square.IsTopBorderAWall();

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnFalse_WhenTopOfSquareIsNotAWall()
        {
            var square = new Square(false, true, false, false);
            var result = square.IsTopBorderAWall();

            Assert.False(result);
        }

        [Fact]
        public void ShouldReturnTrue_WhenRightOfSquareIsAWall()
        {
            var square = new Square(false, true, false, false);
            var result = square.IsRightBorderAWall();

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrue_WhenBottomOfSquareIsAWall()
        {
            var square = new Square(false, true, true, false);
            var result = square.IsBottomBorderAWall();

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrue_WhenLeftOfSquareIsAWall()
        {
            var square = new Square(false, true, true, true);
            var result = square.IsLeftBorderAWall();

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnTrue_IfDotIsRemoved()
        {
            var square = new Square(false, true, true, true);
            var result = square.CanRemoveDot();

            Assert.True(result);
        }
    }
}