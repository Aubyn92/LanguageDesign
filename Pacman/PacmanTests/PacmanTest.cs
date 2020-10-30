using System.ComponentModel;
using Pacman;
using Xunit;

namespace PacmanTests

{
    public class PacmanTest
    {
        [Fact]
        public void ShouldChangeDirection_WhenDirectionIsGiven()
        {
            var pacman = new Pacman.Pacman(Direction.North,12, 15);
            pacman.Move(Direction.South, 12, 15);
            Assert.Equal(Direction.South, pacman.FacingDirection);
        }

        [Fact]
        public void ShouldUpdateLocation_WhenRowAndColumnAreGiven()
        {
            var pacman = new Pacman.Pacman(Direction.North,12, 15);
            pacman.Move(Direction.North,10,20);
            Assert.Equal(new int[]{10, 20}, pacman.Location);
        }
        
        [Fact]
        public void ShouldChangeOpenOrClosedMouthState_WhenRotate()
        {
            var pacman = new Pacman.Pacman(Direction.North,12, 15);
            pacman.Move(Direction.South, 12, 15);
            Assert.Equal(Mouth.Closed, pacman.MouthStatus);
        }

        [Fact]
        public void ShouldChangeOpenOrClosedMouthState_WhenMove()
        {
            var pacman = new Pacman.Pacman(Direction.North, 12, 15);
            pacman.Move(Direction.North, 14, 18);
            Assert.Equal(Mouth.Closed, pacman.MouthStatus);
        }
    }
}