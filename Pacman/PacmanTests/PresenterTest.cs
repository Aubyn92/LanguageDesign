using System.Collections.Generic;
using Moq;
using Pacman;
using Xunit;
using Moq;

namespace PacmanTests
{
    public class PresenterTest
    {
        public Square[,] map;
        public Mock<IInputOutput> mockio;
        public Presenter presenter;
        
        public PresenterTest()
        {
            map = Map.CreateASampleMap();
            mockio = new Mock<IInputOutput>();
            presenter = new Presenter(mockio.Object);
        }
        
        [Fact]
        public void ShouldPrintMapWithDot_WhenSquareHasDot()
        {
            var pacman = new Pacman.Pacman(Direction.North, 10,10);
            var characters = new List<ICharacter> {pacman};
            presenter.PrintMap(map, characters);
            mockio.Verify(x => x.Output("🍬🍬🍬\n🍬🍬🍬\n🍬🍬🍬"), Times.Exactly(1));
        }
        
        [Fact]
        public void ShouldPrintMapWithEmptySpace_WhenSquareHasNoDot()
        {
            var mapToBeAltered = Map.CreateASampleMap();
            mapToBeAltered[0, 0].CanRemoveDot();
            mapToBeAltered[0, 1].CanRemoveDot();
            mapToBeAltered[0, 2].CanRemoveDot();
            var pacman = new Pacman.Pacman(Direction.North,10,10);
            var characters = new List<ICharacter> {pacman};
            presenter.PrintMap(mapToBeAltered, characters);
            mockio.Verify(x => x.Output("   \n🍬🍬🍬\n🍬🍬🍬"), Times.Exactly(1));
        }
        
        [Fact]
        public void ShouldPrintMapWithPacman_WhenSquareHasPacman()
        {
            var pacman = new Pacman.Pacman(Direction.North, 0,0);
            var characters = new List<ICharacter> {pacman};
            presenter.PrintMap(map, characters);
            mockio.Verify(x => x.Output("V🍬🍬\n🍬🍬🍬\n🍬🍬🍬"), Times.Exactly(1));
        }
        
        [Theory]
        [InlineData(Direction.North, 1, 2, "🍬🍬🍬\n🍬🍬V\n🍬🍬🍬")]
        [InlineData(Direction.South, 2, 2, "🍬🍬🍬\n🍬🍬🍬\n🍬🍬∧")]
        [InlineData(Direction.East, 0, 2, "🍬🍬<\n🍬🍬🍬\n🍬🍬🍬")]
        [InlineData(Direction.West, 1, 1, "🍬🍬🍬\n🍬>🍬\n🍬🍬🍬")]
        public void ShouldPrintMapWithPacman_WithCorrectFacingDirection(Direction direction, int row, int column, string expected)
        {
            var pacman = new Pacman.Pacman(direction,row, column);
            var characters = new List<ICharacter> {pacman};
            presenter.PrintMap(map, characters);
            mockio.Verify(x => x.Output(expected), Times.Exactly(1));
        }
        
        [Fact]
        public void ShouldPrintMapWithMonster_WhenSquareHasMonster()
        {
            var monster = new Pacman.Monster(1,1);
            var pacman = new Pacman.Pacman(Direction.North,0,0);
            var characters = new List<ICharacter> {monster, pacman};
            presenter.PrintMap(map, characters);
            mockio.Verify(x => x.Output("V🍬🍬\n🍬👻🍬\n🍬🍬🍬"), Times.Exactly(1));
        }
        
        [Fact]
        public void ShouldPrintPacmanWithMouthClosed_WhenPacmanMouthStatusClosed()
        {
            var pacman = new Pacman.Pacman(Direction.North,0,0);
            pacman.Move(Direction.South, 1, 0);
            var characters = new List<ICharacter> {pacman};
            presenter.PrintMap(map, characters);
            mockio.Verify(x => x.Output("🍬🍬🍬\n|🍬🍬\n🍬🍬🍬"), Times.Exactly(1));
        }
    }
    // decide next move logic player.decideNextMove() 
    // game and game logic classes
}
