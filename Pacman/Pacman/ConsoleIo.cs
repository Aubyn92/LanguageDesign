using System;

namespace Pacman
{
    public class ConsoleIo : IInputOutput
    {
        public string Input()
        {
            return Console.ReadLine();
        }
        public void Output(string text)
        {
            Console.WriteLine(text);
        }
    }
}