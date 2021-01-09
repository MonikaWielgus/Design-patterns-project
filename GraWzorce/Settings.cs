namespace GraWzorce
{
    public enum Direction { Up, Down, Left, Right };
    class Settings
    {
        public static int Size { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Direction direction { get; set; }

        public Settings()
        {
            Size = 16;
            Speed = 5;
            Score = 0;
            Points = 1;
            GameOver = false;
            direction = Direction.Down;
        }
    }
}
