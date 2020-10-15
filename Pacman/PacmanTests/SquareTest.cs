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
        public void ShouldReturnTrue_WhenTopOfSqaureIsAWall()
        {
            var square = new Square(true, true);
            var result = square.IsWall();

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnFalse_WhenTopOfSquareIsNotAWall()
        {
            var square = new Square(false,true);
            var result = square.IsWall();

            Assert.False(result);
        }

        [Fact]
        public void ShouldReturnTrue_WhenRightOfSquareIsAWall()
        {
            var square = new Square(false,true);
            var result = square.IsRightBorderAWall();

            Assert.True(result);
        }
    }
}