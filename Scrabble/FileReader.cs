using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scrabble
{
    class FileReader
    {
        public string Content { get; }
        public FileReader(string filename)
        {
            try
            {
                using (StreamReader file = new StreamReader(filename))
                {
                    while (!file.EndOfStream)
                    {
                        string content = file.ReadToEnd();
                        Content = content;
                    }
                }
            }catch
            {
                Content = "";
            }
        }
    }
}
