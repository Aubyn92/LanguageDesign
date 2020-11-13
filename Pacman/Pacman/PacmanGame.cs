using System.Collections.Generic;
using System.Linq;

namespace Pacman
{
    public class PacmanGame
    {
        private Dictionary<IPlayer, ICharacter> _playerList;
        private Block[,] _map;
        private GameRules _gameRules;
        private Presenter _presenter;

        public PacmanGame(Dictionary<IPlayer, ICharacter> playerList, Block [,] map, Presenter presenter)
        {
            _playerList = playerList;
            _map = map;
            _gameRules = new GameRules();
            _presenter = presenter;
        }

        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
               
                foreach (var player in _playerList)
                {
                    var characterLocation = player.Value.Location;
                    var availableDirections = _gameRules.GetAvailableDirections(characterLocation, _map);
                    var chosenDirection = player.Key.DecideNextMove(availableDirections);
                    // player currently at 2,2 and player chooses the West direction
                    var row = UpdateRow(characterLocation[0], chosenDirection);
                    var column = UpdateColumn(characterLocation[1], chosenDirection);
                    player.Value.Move(chosenDirection, 2, 2);
                }

                _presenter.PrintMap(_map, _playerList.Values.ToList());
            }
            
        }

        private int UpdateRow(int currentRowNumber, Direction chosenDirection)
        {
            return chosenDirection switch
            {
                Direction.North => currentRowNumber - 1,
                Direction.South => currentRowNumber + 1,
                _ => currentRowNumber
            };
        }
        
        private int UpdateColumn(int currentColumnNumber, Direction chosenDirection)
        {
            return chosenDirection switch
            {
                Direction.West => currentColumnNumber - 1,
                Direction.East => currentColumnNumber + 1,
                _ => currentColumnNumber
            };
        }
    }
}