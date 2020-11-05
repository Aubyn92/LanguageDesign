using System;

namespace NewCompositionKata
{
    public class Foobar : IPrinter
    {
        public void Print()
        {
            var instanceOfFoo = new Foo();
            var instanceOfBar = new Bar();
            
            instanceOfFoo.Print();
            instanceOfBar.Print();        
        }
    }
}