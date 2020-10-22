using System.ComponentModel;
using Pacman;
using Xunit;

namespace MonsterTests

{
    public class MonsterTest
    {
        [Fact]
        public void ShouldChangeDirection_WhenDirectionIsGiven()
        {
            var monster = new Pacman.Monster(12, 15);
            monster.Move(Direction.South, 12, 15);
            Assert.Equal(Direction.South, monster.FacingDirection);
        }

        [Fact]
        public void ShouldUpdateLocation_WhenRowAndColumnAreGiven()
        {
            var monster = new Pacman.Monster(12, 15);
            monster.Move(Direction.North,10,20);
            Assert.Equal(new int[]{10, 20}, monster.Location);
        }
    }
}