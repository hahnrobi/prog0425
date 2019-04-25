using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Scrabble
{
    public partial class Form1 : Form
    {
        List<Scrabble> s;
        Osszegzo ossz;
        public Form1()
        {
            InitializeComponent();
            s = new List<Scrabble>();

            ListBox l = new ListBox();
            l.Location = new Point(20, 62);
            l.Size = new Size(150, 394);
            l.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            this.Controls.Add(l);
            ossz = new Osszegzo(l);
            s.Add(ossz.S);
        }
        private int getIncrementLocation()
        {
            int current = 0;
            foreach (Control item in this.Controls)
            {
                if (item is ListBox)
                {
                    current++;
                }
            }
            int increment = 20 + current * (150 + 20);
            if (this.Size.Width < (increment + 150 + 20))
            {
                this.Size = new Size(this.Size.Width + 150 + 20, this.Size.Height);
            }
            return increment;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Szöveg | *.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ListBox l = new ListBox();
                l.Location = new Point(getIncrementLocation(), 62);
                l.Size = new Size(150, 394);
                this.Controls.Add(l);
                FileReader fr = new FileReader(ofd.FileName);
                Scrabble newS = new Scrabble(fr, l);
                s.Add(newS);
                ossz.AddTo(newS.Dictionary);
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (s != null)
            {
                if (radioButton1.Checked)
                {
                    foreach (Scrabble scrabble in s)
                    {
                        scrabble.SortByKeys();
                    }
                }
                if (radioButton2.Checked)
                {
                    foreach (Scrabble scrabble in s)
                    {
                        scrabble.SortByValues();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

