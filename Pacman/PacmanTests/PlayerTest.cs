using System.Collections.Generic;
using Moq;
using Pacman;
using Xunit;

namespace PacmanTests
{
    public class PlayerTest
    {
        
        [Theory]
        [InlineData("w", Direction.North)]
        [InlineData("s", Direction.South)]
        [InlineData("a", Direction.West)]
        [InlineData("d", Direction.East)]
        [InlineData("W", Direction.North)]
        [InlineData("S", Direction.South)]
        [InlineData("A", Direction.West)]
        [InlineData("D", Direction.East)]
        
        public void ShouldReturnDirection_WhenValidUserInputReceived(string userInput, Direction direction)
        {
            var io = new Mock<IInputOutput>();
            io.Setup(x => x.Input())
                .Returns(userInput);
            var player = new ConsolePlayer(io.Object);
            var listOfOptions = new List<Direction>
            {
                Direction.North, Direction.South, Direction.East, Direction.West
            };
            var result = player.DecideNextMove(listOfOptions);
            Assert.Equal(direction, result);
        }

        [Fact]
        public void ShouldReturnAvailableDirection()
        {
            var io = new Mock<IInputOutput>();
            io.SetupSequence(x => x.Input())
                .Returns("a")
                .Returns("s");
            var player = new ConsolePlayer(io.Object);
            var listOfOptions = new List<Direction>
            {
                Direction.North, Direction.South, Direction.East
            };
            var result = player.DecideNextMove(listOfOptions);
            Assert.Equal(Direction.South, result);
            io.Verify(x => x.Input(), Times.Exactly(2));
            io.Verify(x => x.Output("Option not available; choose again."), Times.Exactly(1));
        }

        [Theory]
        [InlineData("gidday", "Error. Please input valid option.")]
        [InlineData("3", "Error. Please input valid option.")]

        public void ShouldAdviseUser_WhenInvalidInputReceived(string userInput, string errorMessage)
        {
            var io = new Mock<IInputOutput>();
            io.SetupSequence(x => x.Input())
                .Returns(userInput)
                .Returns("s");
            var player = new ConsolePlayer(io.Object);
            var listOfOptions = new List<Direction>
             {
                 Direction.North, Direction.South, Direction.East
             };
            var result = player.DecideNextMove(listOfOptions);
            Assert.Equal(Direction.South, result);
            io.Verify(x => x.Output(errorMessage), Times.Exactly(1));
        }
    }
}