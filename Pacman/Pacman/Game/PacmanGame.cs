using System;
using System.Collections.Generic;
using System.Linq;

namespace Pacman
{
    public class PacmanGame
    {
        private Dictionary<IPlayer, ICharacter> _playerList;
        private Block[,] _map;
        private GameLogic _gameLogic;
        private Presenter _presenter;
        private GameTracker _tracker;

        public PacmanGame(Dictionary<IPlayer, ICharacter> playerList, Block [,] map, Presenter presenter)
        {
            _playerList = playerList;
            _map = map;
            _gameLogic = new GameLogic();
            _tracker = new GameTracker(3);
            _presenter = presenter;
        }

        public void Run()
        {
            var gameStatus = _tracker.Status;
            while (gameStatus != GameStatus.GameOver)
            {
                foreach (var player in _playerList)
                {
                    PerformCharacterMove(player);
                    Console.Clear();
                }

                MoveConsequence();
                _presenter.PrintMap(_map, _playerList.Values.ToList());
            }
        }

        private void MoveConsequence()
        {
            var characters = _playerList.Values.ToList();
            _gameLogic.HandleMoveConsequence(characters, _tracker, _map);
        }

        private void PerformCharacterMove(KeyValuePair<IPlayer, ICharacter> player)
        {
            var characterLocation = player.Value.Location;
            var availableDirections = _gameLogic.GetAvailableDirections(characterLocation, _map);
            var chosenDirection = player.Key.DecideNextMove(availableDirections);
            var row = UpdateRow(characterLocation[0], chosenDirection);
            var column = UpdateColumn(characterLocation[1], chosenDirection);
            player.Value.Move(chosenDirection, row, column);
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