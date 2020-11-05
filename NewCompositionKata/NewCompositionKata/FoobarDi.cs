namespace NewCompositionKata
{
    public class FoobarDi : IPrinter
    {
        public void Print(Foo incomingFoo, Bar incomingBar)
        {
            incomingFoo.Print();
            incomingBar.Print();
        }

        public void Print()
        {
            throw new System.NotImplementedException();
        }
    }
}