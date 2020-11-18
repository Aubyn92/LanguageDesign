using System;
using System.Collections.Generic;
using System.Threading;

namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = Map.CreateASampleMap();
            var pacman = new Pacman(Direction.North, 1, 0);
            var monster1 = new Monster(2,2);
            var monster2 = new Monster(1,2);
            var presenter = new Presenter(new ConsoleIo());
            var randomiser = new Randomiser();
            var io = new ConsoleIo();
            IPlayer player = new ConsolePlayer(io);
            IPlayer aiPlayer = new AIPlayer(randomiser);
            IPlayer aiPlayer1 = new AIPlayer(randomiser);
            var playerList = new Dictionary<IPlayer, ICharacter>
            {
                {player, pacman},
                {aiPlayer, monster1},
                {aiPlayer1, monster2}
            };
                
            var game = new PacmanGame(playerList, map, presenter);
            game.Run();
        }
    }
}