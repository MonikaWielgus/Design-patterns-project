using System.Collections.Generic;

namespace GraWzorce
{
    class BentBarriers : Barriers
    {
        public BentBarriers(int pbWidth, int pbHeight, int settingsWidth, int settingHeight) : base(pbWidth, pbHeight, settingsWidth, settingHeight) { }

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
            int maxXpos = (PbWidth / SettingsWidth) - 1;
            int maxYpos = (PbHeight / SettingsHeight) - 1;
            bool done = false;
            int where, x, y;
            Dictionary<int, bool> temp = new Dictionary<int, bool>();
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
                if (PlaceNextPart(temp, x, y, numberOfParts))
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
        private bool PlaceNextPart(Dictionary<int, bool> temp, int x, int y, int numberOfPartsLeft)
        {
            if (numberOfPartsLeft == 0)
                return true;
            if (!temp.ContainsKey(RealPlace(x, y)))
            {
                temp.Add(RealPlace(x, y), true);
                int nextPlace = RandomNextPlace(x, y);
                if (nextPlace == -1)
                    return false;
                else
                {
                    if (!temp.ContainsKey(nextPlace))
                        return PlaceNextPart(temp, GetX(nextPlace), GetY(nextPlace), numberOfPartsLeft - 1);
                    else
                        return false;
                }
            }
            return false;
        }

        private int RandomNextPlace(int x, int y)
        {

            int next = Rand.Next(0, 4);
            switch (next)
            {
                case 0:
                    if (CheckIfNotBeyondTheBoard(x + 1, y))
                        return RealPlace(x + 1, y);
                    else
                        return -1;
                case 1:
                    if (CheckIfNotBeyondTheBoard(x - 1, y))
                        return RealPlace(x - 1, y);
                    else
                        return -1;
                case 2:
                    if (CheckIfNotBeyondTheBoard(x, y + 1))
                        return RealPlace(x, y + 1);
                    else
                        return -1;
                case 3:
                    if (CheckIfNotBeyondTheBoard(x, y - 1))
                        return RealPlace(x, y - 1);
                    else
                        return -1;
            }
            return -1;
        }
    }
}
