using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble
{

    class Osszegzo
    {
        Scrabble s;

        public Scrabble S
        {
            get { return s; }
        }

        Dictionary<char, double> dict;
        public Osszegzo(ListBox lb)
        {
            dict = new Dictionary<char, double>();
            s = new Scrabble(lb, dict);
        }
        public void AddTo(Dictionary<char, double> kisD)
        {
            foreach (KeyValuePair<char, double> item in kisD)
            {
                if(dict.ContainsKey(item.Key))
                {
                    double value;
                    dict.TryGetValue(item.Key, out value);
                    dict[item.Key] = value + item.Value;
                }
                else
                {
                    dict.Add(item.Key, item.Value);
                }
            }
            s.Dictionary = dict;
            s.UpdateListBox();
        }
    }
}
