using System.Collections.Generic;

namespace GraWzorce
{
    public class DetailsFactory
    {
        private static Dictionary<string, Details> Types = new Dictionary<string, Details>();

        public static Details getFigureDetails(string type)
        {
            if (!Types.TryGetValue(type, out Details item))
            {
                item = new Details(type);
                Types.Add(type, item);
            }
            return item;
        }
    }
}
