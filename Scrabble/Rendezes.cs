using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    static class Rendezes
    {
        public static Dictionary<char, double> SortByKeys(Dictionary<char, double> dict)
        {
            List<char> l = dict.Keys.ToList();
            l.Sort();
            Dictionary<char, double> newDict = new Dictionary<char, double>();

            foreach (char item in l)
            {
                newDict.Add(item, dict[item]);
            }
            return newDict;
        }
        public static Dictionary<char, double> SortByValues(Dictionary<char, double> dict)
        {
            List<double> l = dict.Values.ToList();
            l.Sort();
            Dictionary<char, double> newDict = new Dictionary<char, double>();

            foreach (KeyValuePair<char, double> value in dict.OrderBy(k => k.Value))
            {
                newDict.Add(value.Key, value.Value);
            }
            return newDict;
        }
    }
}
