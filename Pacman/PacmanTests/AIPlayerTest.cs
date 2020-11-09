using System.Collections.Generic;
using Moq;
using Pacman;
using Xunit;

namespace PacmanTests
{
    public class AIPlayerTest
    {
        [Theory]
        [InlineData(Direction.South)]
        [InlineData(Direction.North)]
        [InlineData(Direction.East)]
        [InlineData(Direction.West)]

        public void ShouldReturnDirection(Direction direction)
        {
            var randomiser = new Mock<IRandom>();
            var listOfOptions = new List<Direction>
            {
                Direction.North, Direction.South, Direction.East, Direction.West
            };
            randomiser.Setup(x => x.SelectRandomDirection(listOfOptions))
                .Returns(direction);
            var player = new AIPlayer(randomiser.Object);
            var result = player.DecideNextMove(listOfOptions);
            Assert.Equal(direction, result);
        }
    }
}