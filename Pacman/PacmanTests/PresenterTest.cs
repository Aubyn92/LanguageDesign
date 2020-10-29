using System.Collections.Generic;
using Moq;
using Pacman;
using Xunit;
using Moq;

namespace PacmanTests
{
    public class PresenterTest
    {
        [Fact]
        public void ShouldPrintMapWithDot_WhenSquareHasDot()
        {
            var map = Map.CreateASampleMap();
            var mockio = new Mock<IInputOutput>();
            var presenter = new Presenter(mockio.Object);
            var pacman = new Pacman.Pacman(10,10);
            var characters = new List<ICharacter> {pacman};
            presenter.PrintMap(map, characters);
            mockio.Verify(x => x.Output("...\n...\n..."), Times.Exactly(1));
        }
        
        [Fact]
        public void ShouldPrintMapWithEmptySpace_WhenSquareHasNoDot()
        {
            var map = Map.CreateASampleMap();
            map[0, 0].CanRemoveDot();
            map[0, 1].CanRemoveDot();
            map[0, 2].CanRemoveDot();
            var mockio = new Mock<IInputOutput>();
            var presenter = new Presenter(mockio.Object);
            var pacman = new Pacman.Pacman(10,10);
            var characters = new List<ICharacter> {pacman};
            presenter.PrintMap(map, characters);
            mockio.Verify(x => x.Output("   \n...\n..."), Times.Exactly(1));
        }
        
        [Fact]
        public void ShouldPrintMapWithPacman_WhenSquareHasPacman()
        {
            var map = Map.CreateASampleMap();
            var mockio = new Mock<IInputOutput>();
            var presenter = new Presenter(mockio.Object);
            var pacman = new Pacman.Pacman(0,0);
            var characters = new List<ICharacter> {pacman};
            presenter.PrintMap(map, characters);
            mockio.Verify(x => x.Output("V..\n...\n..."), Times.Exactly(1));
        }
        
        [Theory]
        [InlineData(Direction.North, 1, 2, "...\n..V\n...")]
        [InlineData(Direction.South, 2, 2, "...\n...\n..∧")]
        [InlineData(Direction.East, 0, 2, "..<\n...\n...")]
        [InlineData(Direction.West, 1, 1, "...\n.>.\n...")]
        public void ShouldPrintMapWithPacman_WithCorrectFacingDirection(Direction direction, int row, int column, string expected)
        {
            var map = Map.CreateASampleMap();
            var mockio = new Mock<IInputOutput>();
            var presenter = new Presenter(mockio.Object);
            var pacman = new Pacman.Pacman(0,0);
            pacman.Move(direction, row, column);
            var characters = new List<ICharacter> {pacman};
            presenter.PrintMap(map, characters);
            mockio.Verify(x => x.Output(expected), Times.Exactly(1));
        }
        
        [Fact]
        public void ShouldPrintMapWithMonster_WhenSquareHasMonster()
        {
            var map = Map.CreateASampleMap();
            var mockio = new Mock<IInputOutput>();
            var presenter = new Presenter(mockio.Object);
            var monster = new Pacman.Monster(1,1);
            var pacman = new Pacman.Pacman(0,0);
            var characters = new List<ICharacter> {monster, pacman};
            presenter.PrintMap(map, characters);
            mockio.Verify(x => x.Output("V..\n.👻.\n..."), Times.Exactly(1));
        }
    }
}

// TO DO:


// print pacman mouth: open and close