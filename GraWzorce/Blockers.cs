
namespace GraWzorce
{
    class UpBlocker : IBlockStrategy
    {
        public void BlockHere(int i, int j, Barriers b)
        {
            if (b.CheckIfNotBeyondTheBoard(i, j - 1))
                if (!b.barriers.ContainsKey(b.RealPlace(i, j - 1)))
                    b.barriers.Add(b.RealPlace(i, j - 1), false);
        }
    }
    class UpRightBlocker : IBlockStrategy
    {
        public void BlockHere(int i, int j, Barriers b)
        {
            if (b.CheckIfNotBeyondTheBoard(i + 1, j - 1))
                if (!b.barriers.ContainsKey(b.RealPlace(i + 1, j - 1)))
                    b.barriers.Add(b.RealPlace(i + 1, j - 1), false); ;
        }
    }
    class RightBlocker : IBlockStrategy
    {
        public void BlockHere(int i, int j, Barriers b)
        {
            if (b.CheckIfNotBeyondTheBoard(i + 1, j))
                if (!b.barriers.ContainsKey(b.RealPlace(i + 1, j)))
                    b.barriers.Add(b.RealPlace(i + 1, j), false); ;
        }
    }
    class DownRightBlocker : IBlockStrategy
    {
        public void BlockHere(int i, int j, Barriers b)
        {
            if (b.CheckIfNotBeyondTheBoard(i + 1, j + 1))
                if (!b.barriers.ContainsKey(b.RealPlace(i + 1, j + 1)))
                    b.barriers.Add(b.RealPlace(i + 1, j + 1), false); ;
        }
    }
    class DownBlocker : IBlockStrategy
    {
        public void BlockHere(int i, int j, Barriers b)
        {
            if (b.CheckIfNotBeyondTheBoard(i, j + 1))
                if (!b.barriers.ContainsKey(b.RealPlace(i, j + 1)))
                    b.barriers.Add(b.RealPlace(i, j + 1), false); ;
        }
    }
    class DownLeftBlocker : IBlockStrategy
    {
        public void BlockHere(int i, int j, Barriers b)
        {
            if (b.CheckIfNotBeyondTheBoard(i - 1, j + 1))
                if (!b.barriers.ContainsKey(b.RealPlace(i - 1, j + 1)))
                    b.barriers.Add(b.RealPlace(i - 1, j + 1), false); ;
        }
    }
    class LeftBlocker : IBlockStrategy
    {
        public void BlockHere(int i, int j, Barriers b)
        {
            if (b.CheckIfNotBeyondTheBoard(i - 1, j))
                if (!b.barriers.ContainsKey(b.RealPlace(i - 1, j)))
                    b.barriers.Add(b.RealPlace(i - 1, j), false); ;
        }
    }
    class UpLeftBlocker : IBlockStrategy
    {
        public void BlockHere(int i, int j, Barriers b)
        {
            if (b.CheckIfNotBeyondTheBoard(i - 1, j - 1))
                if (!b.barriers.ContainsKey(b.RealPlace(i - 1, j - 1)))
                    b.barriers.Add(b.RealPlace(i - 1, j - 1), false); ;
        }
    }
}
