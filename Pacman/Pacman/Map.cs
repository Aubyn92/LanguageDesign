namespace Pacman
{
    public class Map
    {
        public Map()
        {
            
        }

        public Square[,] CreateASampleMap()
        {
            var list = new Square[,]
            {
                {
                    new Square(true, false, true, true), new Square(true, false, false, false),
                    new Square(true, true, true, false)
                },
                {
                    new Square(true, false, true, true), new Square(false, false, false, false),
                    new Square(true, true, true, false)
                },
                {
                    new Square(true, false, true, true), new Square(false, false, true, false),
                    new Square(true, true, true, false)
                }
            };
            return list;
        }
    }
}
