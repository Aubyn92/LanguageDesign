using System.Collections.Generic;

namespace Pacman
{
    public class GameLogic
    {
        public GameLogic()
        {
            
        }

        public List<Direction> GetAvailableDirections(int[] location, Block[,] map)
        {
            var row = location[0];
            var column = location[1];
            var block = map[row, column];

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

        public bool IsCollisionBetweenPacmanAndMonster(List<ICharacter>characters)
        {
            var pacman = characters.Find(character => character is Pacman);
            foreach (var character in characters)
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

        private void HandleCollision(List<ICharacter>characters, GameTracker tracker)
        {
            Pacman pacman = (Pacman)characters.Find(character => character is Pacman);
            tracker.DecreaseLives();
            if (tracker.NumberOfLives != 0) return;
            pacman.IsDead = true;
            tracker.Status = GameStatus.GameOver;
        }

        public void HandleMoveConsequence(List<ICharacter>characters, GameTracker tracker, Block[,]map)
        {
            if (IsCollisionBetweenPacmanAndMonster(characters))
            {
                HandleCollision(characters, tracker);
            }
        }
    }
}