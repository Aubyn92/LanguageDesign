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
        
        [Fact]
        public void ShouldReturnTrue_WhenPacmanIsOnSameBlockAsMonster()
        {
            var pacman = new Pacman.Pacman(Direction.North, 0,0);
            var monster1 = new Monster(1,1);
            var monster2 = new Monster(0,0);
            var characters = new List<ICharacter>{pacman, monster1, monster2};
            var result = _gameRules.IsGameOver(characters);
            Assert.True(result);
        }
        
        [Fact]
        public void ShouldReturnFalse_WhenPacmanIsNotOnSameBlockAsMonster()
        {
            var pacman = new Pacman.Pacman(Direction.North, 0,0);
            var monster1 = new Monster(1,1);
            var monster2 = new Monster(3,2);
            var characters = new List<ICharacter>{pacman, monster1, monster2};
            var result = _gameRules.IsGameOver(characters);
            Assert.False(result);
        }
        
        // [Fact]
        // public void ShouldReturnTrue_WhenPacmanHasEatenAllDots()
        // {
        //     
        // }
    }
}