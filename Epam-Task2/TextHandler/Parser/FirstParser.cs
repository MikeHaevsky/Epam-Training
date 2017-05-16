using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation;
using TextHandler.Implementation.TextItems;
using TextHandler.Implementation.TextItems.SentenceItems;

namespace TextHandler.Parser
{
    public class FirstParser
    {
        char[] result;
        char[] argRes;
        public Text Parse(string path)
        {
            StringBuilder builder = new StringBuilder();
            StreamReader reader = File.OpenText(path);
            result = new char[reader.BaseStream.Length];
            reader.Read(result, 0, (int)reader.BaseStream.Length);
            Text text = new Text();
            SecondParser secondParser=new SecondParser();
            int pn=0;
            int i = 0;
            int n = 0;
            int j = 0;
            int n2 = 0;
            foreach (char c in result)
            {
                switch (c)
                {
                    case '\r':
                        n = j;
                        i = ++i;
                        j = ++j;
                        break;
                    case '\n':
                        argRes = new char[n];
                        pn = ++pn;
                        Array.Copy(result, n2, argRes, 0, n);
                        text = secondParser.Parse(argRes, pn);
                        i = ++i;
                        j = 0;
                        n2 = i;
                        break;
                    default:
                        if (i >= result.Length)
                        {
                            i = i++;
                            j = j++;
                            argRes = new char[n];
                            pn = ++pn;
                            Array.Copy(result, n2, argRes, 0, n);
                            text = secondParser.Parse(argRes, pn);
                        }
                        else 
                        {
                            i = ++i;
                            j = ++j;
                        }
                        
                    break;
                }
            }
            return text;
        }
    }
}