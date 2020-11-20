using System;
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
        private GameTracker _tracker;

        public PacmanGame(Dictionary<IPlayer, ICharacter> playerList, Block [,] map, Presenter presenter)
        {
            _playerList = playerList;
            _map = map;
            _gameRules = new GameRules();
            _tracker = new GameTracker(3);
            _presenter = presenter;
        }

        public void Run()
        {
            var gameStatus = GameStatus.Continue;
            while (gameStatus != GameStatus.GameOver)
            {
               
                foreach (var player in _playerList)
                {
                    var characterLocation = player.Value.Location;
                    var availableDirections = _gameRules.GetAvailableDirections(characterLocation, _map);
                    var chosenDirection = player.Key.DecideNextMove(availableDirections);
                    var row = UpdateRow(characterLocation[0], chosenDirection);
                    var column = UpdateColumn(characterLocation[1], chosenDirection);
                    player.Value.Move(chosenDirection, row, column);
                    Console.Clear();
                }

                if (_gameRules.IsCollisionBetweenPacmanAndMonster(_playerList.Values.ToList()))
                {
                    gameStatus = GameStatus.GameOver;
                    _gameRules.HandleCollision(_playerList.Values.ToList(), _tracker);
                    Console.WriteLine(gameStatus);
                }

                _presenter.PrintMap(_map, _playerList.Values.ToList());
            }
            
        }
        
        // Implement EatDot functionality == when all dots eaten he wins!! Another emoji for winning!!
        // Track game to see Pacmans life levels
        // Refactor game because it's messy code:
        // Separate logic into handling move consequence and updating game status

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