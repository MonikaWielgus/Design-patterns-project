using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWzorce
{
    class BarrierCaller
    {
        public static void Do(Barriers barrier)
        {
            barrier.GenerateObstacles();
        }
    }
}
