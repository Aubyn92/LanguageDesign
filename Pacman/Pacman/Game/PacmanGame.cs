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
            _gameLogic= new GameLogic(playerList, map, new GameTracker((3)));
            _presenter = presenter;
        }

        public void Run()
        {
            var gameStatus = _tracker.Status;
            while (gameStatus != GameStatus.GameOver)
            {
                foreach (var player in _playerList)
                {
                    _gameLogic.PerformCharacterMove(player);
                    Console.Clear();
                }

                _gameLogic.MoveConsequence();
                _presenter.PrintMap(_map, _playerList.Values.ToList());
            }
        }
    }
}