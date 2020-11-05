using System;

namespace NewCompositionKata
{
    public class Bar : IPrinter
    {
        public void Print()
        {
            Console.Write("bar");
        }
    }
}