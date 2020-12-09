using System.Collections.Generic;
using System.Linq;

namespace Pacman
{
    public class GameLogic
    {
        private Dictionary<IPlayer, ICharacter> _playerList;
        private Block[,] _map;
        private GameTracker _tracker;
        private List<ICharacter> _characters;

        public GameLogic(Dictionary<IPlayer, ICharacter> playerList, Block [,] map, GameTracker tracker)
        {
            _playerList = playerList;
            _map = map;
            _tracker = tracker;
            _characters = _playerList.Values.ToList();
        }

        public List<Direction> GetAvailableDirections(int[] location)
        {
            var row = location[0];
            var column = location[1];
            var block = _map[row, column];

            var listOfDirections = new List<Direction>();
            if (!block.IsTopBorderAWall())
            {
                listOfDirections.Add(Direction.North);
            }
            if (!block.IsBottomBorderAWall())
            {
                listOfDirections.Add(Direction.South);
            }
            if (!block.IsLeftBorderAWall())
            {
                listOfDirections.Add(Direction.West);
            }
            if (!block.IsRightBorderAWall())
            {
                listOfDirections.Add(Direction.East);
            }

            return listOfDirections;
        }

        public bool IsCollisionBetweenPacmanAndMonster()
        {
            var pacman = _characters.Find(character => character is Pacman);
            foreach (var character in _characters)
            {
                if (!(character is Pacman))
                {
                    if (character.Location[0] == pacman.Location[0] && character.Location[1] == pacman.Location[1])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void HandleCollision()
        {
            Pacman pacman = (Pacman)_characters.Find(character => character is Pacman);
            _tracker.DecreaseLives();
            if (_tracker.NumberOfLives != 0) return;
            pacman.IsDead = true;
            _tracker.Status = GameStatus.GameOver;
        }

        public void HandleMoveConsequence()
        {
            if (IsCollisionBetweenPacmanAndMonster())
            {
                HandleCollision();
            }
        }
        
        public void PerformCharacterMove(KeyValuePair<IPlayer, ICharacter> player)
        {
            var characterLocation = player.Value.Location;
            var availableDirections = GetAvailableDirections(characterLocation);
            var chosenDirection = player.Key.DecideNextMove(availableDirections);
            var row = UpdateRow(characterLocation[0], chosenDirection);
            var column = UpdateColumn(characterLocation[1], chosenDirection);
            player.Value.Move(chosenDirection, row, column);
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