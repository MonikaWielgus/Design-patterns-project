using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWzorce
{
    public class DetailsFactory
    {
        private static Dictionary<string, Details> Types = new Dictionary<string,Details>();

        public static Details getFigureDetails(string type)
        {
            if(!Types.TryGetValue(type, out Details item))
            {
                item = new Details(type);
                Types.Add(type, item);
            }
            return item;
        }
    }
}
