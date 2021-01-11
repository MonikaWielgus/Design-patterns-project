namespace GraWzorce
{
    public enum Direction { Up, Down, Left, Right };
    class Settings
    {
        public static int Size;
        public static int Speed;
        public static int Score;
        public static int Points;
        public static bool GameOver;
        public static Direction direction;

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
