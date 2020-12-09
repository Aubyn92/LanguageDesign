using System.Collections.Generic;
using System.Drawing;
using System.IO;
using NuGet.Frameworks;
using Pacman;
using Xunit;

namespace PacmanTests
{
    public class GameRulesTest
    {
        private GameLogic _gameLogic;

        [Fact]

        public void ShouldProvideListOfAvailableDirections_WhenCoOrdinateRecorded()
        {
            var map = Map.CreateASampleMap();
            var location = new int[] {0, 0};
            var dummyPlayerList = new Dictionary<IPlayer, ICharacter>();
            _gameLogic = new GameLogic(dummyPlayerList, map, new GameTracker(3));
            var result = _gameLogic.GetAvailableDirections(location);
            var expected = new List<Direction>
            {
                Direction.East
            };
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void ShouldReturnTrue_WhenPacmanIsOnSameBlockAsMonster()
        {
            var pacman = new Pacman.Pacman(Direction.North, 0,0);
            var monster1 = new Monster(1,1);
            var monster2 = new Monster(0,0);
            var characters = new List<ICharacter>{pacman, monster1, monster2};
            var result = _gameLogic.IsCollisionBetweenPacmanAndMonster();
            Assert.True(result);
        }
        
        [Fact]
        public void ShouldReturnFalse_WhenPacmanIsNotOnSameBlockAsMonster()
        {
            var pacman = new Pacman.Pacman(Direction.North, 0,0);
            var monster1 = new Monster(1,1);
            var monster2 = new Monster(3,2);
            var characters = new List<ICharacter>{pacman, monster1, monster2};
            var result = _gameLogic.IsCollisionBetweenPacmanAndMonster();
            Assert.False(result);
        }
    }
}