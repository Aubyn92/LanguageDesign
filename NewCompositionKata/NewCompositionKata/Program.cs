using System;

namespace NewCompositionKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var foobar = new Foobar();
            foobar.Print();
            
            var foobarDi = new FoobarDi();
            var instanceOfFoo = new Foo();
            var instanceOfBar = new Bar();
            
            foobarDi.Print(instanceOfFoo, instanceOfBar);
        }
    }
}