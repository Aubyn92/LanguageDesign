namespace Pacman
{
    public class Map
    {
        public Map()
        {
            
        }

        public static Block[,] CreateASampleMap()
        {
            var list = new Block[,]
            {
                {
                    new Block(true, false, true, true), new Block(true, false, false, false),
                    new Block(true, true, true, false)
                },
                {
                    new Block(true, false, true, true), new Block(false, false, false, false),
                    new Block(true, true, true, false)
                },
                {
                    new Block(true, false, true, true), new Block(false, false, true, false),
                    new Block(true, true, true, false)
                }
            };
            return list;
        }
    }
}
