using System.Collections.Generic;

namespace GraWzorce
{
    class StraightBarriers : Barriers
    {
        public StraightBarriers(int pbWidth, int pbHeight, int size) : base(pbWidth, pbHeight, size) { }
        protected override void PlaceFourPartObstacle()
        {
            PlaceObstacle(4);
        }

        protected override void PlaceThreePartObstacle()
        {
            PlaceObstacle(3);
        }
        protected override void PlaceTwoPartObstacle()
        {
            PlaceObstacle(2);
        }

        private void PlaceObstacle(int numberOfParts)
        {
            int maxXpos = (PbWidth / ElementSize) - 1;
            int maxYpos = (PbHeight / ElementSize) - 1;
            bool done = false;
            int where, x, y;
            Dictionary<int, bool> temp = new Dictionary<int, bool>();
            int v = Rand.Next(0, 2);
            bool horizontally = true;
            switch (v)
            {
                case 0:
                    horizontally = true;
                    break;
                case 1:
                    horizontally = false;
                    break;
            }
            while (!done)
            {
                where = Rand.Next(maxXpos * maxYpos);
                x = GetX(where);
                y = GetY(where);
                temp.Clear();
                foreach (var key in barriers.Keys)
                {
                    barriers.TryGetValue(key, out bool value);
                    temp.Add(key, value);
                }

                if (PlaceNextPart(temp, x, y, numberOfParts, horizontally))
                {
                    done = true;
                    barriers.Clear();
                    foreach (var key in temp.Keys)
                    {
                        temp.TryGetValue(key, out bool value);
                        barriers.Add(key, value);
                    }
                    Block();
                }
            }
        }

        private bool PlaceNextPart(Dictionary<int, bool> temp, int x, int y, int numberOfPartsLeft, bool horizontally)
        {
            if (numberOfPartsLeft == 0)
                return true;
            if (!temp.ContainsKey(RealPlace(x, y)))
            {
                temp.Add(RealPlace(x, y), true);
                int nextPlace = RandomNextPlace(x, y, horizontally);
                if (nextPlace == -1)
                    return false;
                else
                {
                    if (!temp.ContainsKey(nextPlace))
                        return PlaceNextPart(temp, GetX(nextPlace), GetY(nextPlace), numberOfPartsLeft - 1, horizontally);
                    else
                        return false;
                }
            }
            return false;
        }

        private int RandomNextPlace(int x, int y, bool horizontally)
        {
            if (horizontally)
            {
                if (CheckIfNotBeyondTheBoard(x + 1, y))
                    return RealPlace(x + 1, y);
                return -1;
            }
            else
            {
                if (CheckIfNotBeyondTheBoard(x, y + 1))
                    return RealPlace(x, y + 1);
                return -1;

            }
        }
    }
}
