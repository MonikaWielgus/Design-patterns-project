using System;
using System.Collections;
using System.Collections.Generic;

namespace GraWzorce
{
    abstract class Barriers
    {
        public Dictionary<int, bool> barriers;
        protected int PbWidth;
        protected int PbHeight;
        protected int ElementSize;
        protected readonly Random Rand = new Random();
        public Barriers(int pbWidth, int pbHeight, int size)
        {
            this.barriers = new Dictionary<int, bool>();
            this.PbWidth = pbWidth;
            this.PbHeight = pbHeight;
            this.ElementSize = size;
        }
        public void GenerateObstacles()
        {
            for (int i = 0; i < 7; i++)
                this.PlaceFourPartObstacle();
            for (int i = 0; i < 4; i++)
                this.PlaceThreePartObstacle();
            for (int i = 0; i < 3; i++)
                this.PlaceTwoPartObstacle();
            for (int i = 0; i < 10; i++)
                this.PlaceOnePartObstacle();
        }
        protected abstract void PlaceFourPartObstacle();
        protected abstract void PlaceThreePartObstacle();
        protected abstract void PlaceTwoPartObstacle();
        protected void PlaceOnePartObstacle()
        {
            PlaceSingleObstacle();
        }
        private void PlaceSingleObstacle()
        {
            int maxXpos = (PbWidth / ElementSize) - 1;
            int maxYpos = (PbHeight / ElementSize) - 1;
            bool done = false;
            int where;
            while (!done)
            {
                where = Rand.Next(maxXpos * maxYpos);
                if (!barriers.ContainsKey(where))
                {
                    barriers.Add(where, true);
                    done = true;
                }
            }
            Block();
        }

        protected void Block()
        {
            BlockerContext context = new BlockerContext();
            for (int i = 0; i < PbWidth / ElementSize; i++)
            {
                for (int j = 0; j < PbHeight / ElementSize; j++)
                {
                    if (barriers.ContainsKey(RealPlace(i, j)) && barriers.TryGetValue(RealPlace(i, j), out bool value))
                    {
                        if (value == true)
                        {
                            context.Set(new UpBlocker());
                            context.Do(i, j, this);

                            context.Set(new UpRightBlocker());
                            context.Do(i, j, this);

                            context.Set(new RightBlocker());
                            context.Do(i, j, this);

                            context.Set(new DownRightBlocker());
                            context.Do(i, j, this);

                            context.Set(new DownBlocker());
                            context.Do(i, j, this);

                            context.Set(new DownLeftBlocker());
                            context.Do(i, j, this);

                            context.Set(new LeftBlocker());
                            context.Do(i, j, this);

                            context.Set(new UpLeftBlocker());
                            context.Do(i, j, this);
                        }
                    }
                }
            }
        }


        public bool CheckIfNotBeyondTheBoard(int v, int y)
        {
            return v >= 0 && v <= PbWidth / ElementSize && y >= 0 && y <= PbHeight / ElementSize;
        }

        public int GetX(int number)
        {
            return number % (PbWidth / ElementSize);
        }
        public int GetY(int number)
        {
            return number / (PbWidth / ElementSize);
        }
        public int RealPlace(int x, int y)
        {
            return y * (PbWidth / ElementSize) + x;
        }
        public IEnumerator GetEnumerator()
        {
            return new TrueBarrierIterator(this);
        }
    }
}
