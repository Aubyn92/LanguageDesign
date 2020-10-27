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
            presenter.PrintMap(map, pacman);
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
            presenter.PrintMap(map, pacman);
            mockio.Verify(x => x.Output("   \n...\n..."), Times.Exactly(1));
        }
        
        [Fact]
        public void ShouldPrintMapWithPacman_WhenSquareHasPacman()
        {
            var map = Map.CreateASampleMap();
            var mockio = new Mock<IInputOutput>();
            var presenter = new Presenter(mockio.Object);
            var pacman = new Pacman.Pacman(0,0);
            presenter.PrintMap(map, pacman);
            mockio.Verify(x => x.Output("V..\n...\n..."), Times.Exactly(1));
        }
    }
}

// TO DO:
// CreateSampleMap should be static or not?
// print monster
// print pacman direction
// print pacman mouth: open and close