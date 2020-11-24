namespace Pacman
{
    public class GameTracker
    {
        public int NumberOfDotsLeft { get; private set; }
        public int NumberOfLives { get; private set; }
        public int NumberOfDotsEaten { get; private set; }

        public GameStatus Status { get; set; }
        
        public GameTracker(int numberOfDotsLeft, int numberOfLives = 1)
        {
            NumberOfDotsLeft = numberOfDotsLeft;
            NumberOfLives = numberOfLives;
            NumberOfDotsEaten = 0;
            Status = GameStatus.Continue;
        }

        public void DecreaseLives()
        {
            NumberOfLives--;
        }

        public void AdjustNumOfDotsByOne()
        {
            NumberOfDotsLeft--;
            NumberOfDotsEaten++;
        }
    }
}