using System;
using System.Threading.Channels;

namespace NewCompositionKata
{
    public class Foo : IPrinter
    {
        public void Print()
        {
            Console.Write("foo");
        }
    }
}