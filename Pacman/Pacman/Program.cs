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
            var pacman = new Pacman(Direction.North, 1, 2);
            var monster1 = new Monster(2,2);
            var monster2 = new Monster(0,0);
            var characters = new List<ICharacter>{pacman, monster1, monster2};
            var presenter = new Presenter(new ConsoleIo());
            presenter.PrintMap(map, characters);
            Thread.Sleep(2000);
            Console.Clear();
            pacman.Move(Direction.North, 0, 2);
            monster1.Move(Direction.West,2, 1);
            monster2.Move(Direction.East,0, 1);
            presenter.PrintMap(map, characters);
            Thread.Sleep(2000);
            Console.Clear();
            pacman.Move(Direction.West, 0, 1);
            monster1.Move(Direction.West,2, 0);
            monster2.Move(Direction.South,1, 1);
            presenter.PrintMap(map, characters);
        }
    }
}