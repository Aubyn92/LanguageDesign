using System.Collections.Generic;
using System.Drawing;
using Pacman;
using Xunit;

namespace PacmanTests
{
    public class GameRulesTest
    {
        private GameRules _gameRules;

        public GameRulesTest()
        {
            _gameRules = new GameRules();
        }
        
        [Fact]

        public void ShouldProvideListOfAvailableDirections_WhenCoOrdinateRecorded()
        {
            var map = Map.CreateASampleMap();
            var location = new int[] {0, 0};
            var result = _gameRules.GetAvailableDirections(location, map);
            var expected = new List<Direction>
            {
                Direction.East
            };
            Assert.Equal(expected, result);
        }
        
        // [Fact]
        // public void ShouldReturnTrue_WhenPacmanIsOnSameSquareAsMonster()
        // {
        //     
        // }
        //
        // [Fact]
        // public void ShouldReturnTrue_WhenPacmanHasEatenAllDots()
        // {
        //     
        // }
    }
}