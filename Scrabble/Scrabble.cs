using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble
{
    class Scrabble
    {
        Dictionary<char, double> dict;
        FileReader fr;
        ListBox lb;
        char[] notInclude = new char[]
            {
                            ' '
            };
        public Dictionary<char, double> Dictionary
        {
            get { return dict; }
            set { dict = value; }
        }
        bool Contains(char c)
        {
            for (int i = 0; i < notInclude.Length; i++)
            {
                if (notInclude[i] == c)
                {
                    return true;
                }
            }
            return false;
        }
        public Scrabble(ListBox lb, Dictionary<char, double> dict)
        {
            this.lb = lb;
            this.fr = null;
            this.dict = dict;
            SortByValues();
            UpdateListBox();
        }
        public Scrabble(FileReader fr, ListBox lb)
        {
            this.lb = lb;
            this.fr = fr;
            string content = fr.Content;
            dict = new Dictionary<char, double>();

            foreach (char c in content)
            {
                if (!Contains(c))
                {
                    if (dict.ContainsKey(char.ToUpper(c)))
                    {
                        double value = 100;
                        dict.TryGetValue(char.ToUpper(c), out value);
                        dict[char.ToUpper(c)] = value + 1;
                    }
                    else
                    {
                        dict.Add(char.ToUpper(c), 1);
                    }
                }
            }
                CalcAtlag(dict);
            SortByValues();
            UpdateListBox();
        }
        void CalcAtlag(Dictionary<char, double> dict)
        {
            List<char> l = dict.Keys.ToList();
            foreach (char item in l)
            {
                double value;
                dict.TryGetValue(item, out value);
            }
        }
        public void SortByKeys()
        {
            dict = Rendezes.SortByKeys(dict);
            UpdateListBox();
        }
        public void SortByValues()
        {
            dict = Rendezes.SortByValues(dict);
            UpdateListBox();
        }
        public int SumOfValues()
        {
            double sum = 0;
            foreach (KeyValuePair<char, double> item in dict)
            {
                sum+=item.Value;
            }
            return (int)sum;
        }
        public void UpdateListBox()
        {
            lb.Items.Clear();
            foreach (var item in dict)
            {
                lb.Items.Add(item.Key + " \t " + Math.Round((item.Value/SumOfValues()*100),4) + "%");
                //lb.Items.Add(item.Key + " \t " +item.Value + "\t" + SumOfValues());
            }
        }
    }
}




