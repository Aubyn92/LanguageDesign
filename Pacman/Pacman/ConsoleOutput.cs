using System;

namespace Pacman
{
    public class ConsoleOutput : IInputOutput
    {
        public void Output(string text)
        {
            Console.WriteLine(text);
        }
    }
}