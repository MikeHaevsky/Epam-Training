using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation;
using TextHandler.Implementation.TextItems.SentenceItems;

namespace TextHandler.Parser
{
    public class FirstParser
    {
        //static string filename="D:\\Text.txt";
        char[] result;
        //ICollection<String> Str;
        char[] argRes;
        //char[] result1;
        //string str;
        public FirstParser(string path)
        {
            //WordFactory wf = new WordFactory();
            StringBuilder builder = new StringBuilder();
            StreamReader reader = File.OpenText(path);
            string line;
            //while ((line = reader.ReadLine()) != null)
            //{
            //    str = reader.ReadLine();
            //    result = line.ToCharArray(0, str.Length);
            //}

            result = new char[reader.BaseStream.Length];
            reader.Read(result, 0, (int)reader.BaseStream.Length);
            Text text = new Text();
            int i=0;
            int n;
            int n2=0;
            //ParserBufer bufer = new ParserBufer();
            //ICollection<String> Str;
            //List<StringBuilder>bufer = new List<StringBuilder>();
            //List<Char[]> bufer=new List<char[]>();
            //char[new CounBufer][] CounBufer;
            foreach (char c in result)
            {
                switch (c)
                {
                    case '\r':
                        break;
                    case '\n':
                        n = i;
                        argRes = new char[n];
                        Array.Copy(result, n2, argRes, 0, n);
                        i = ++i;
                        n2 = i;
                        break;
                    default:
                        i = ++i;
                        break;
                }
                //if (c == '\r' || c == '\n')
                //{
                //    //Bufer.Add(builder.AppendLine());
                //    //(builder.ToString);
                //    //builder.CopyTo(i,argRes,i,+i);
                //    //i = +i;
                //    //bufer.Add(builder.());
                //    //builder.GetType();
                //    line = builder.ToString(0, builder.Length);
                //    n = i;
                //    argRes = new char[n];
                //    Array.Copy(result, n2, argRes, 0, n);
                //    i = ++i;
                //    n2 = i;
                //    //Str.Add(builder.ToString(0, builder.Length));

                //    builder.Clear();
                //}
                //else
                //{
                //    //if (c == '\t')
                //    //    builder.Append(" ");
                //    //else
                //    //    if (char.IsWhiteSpace(c))
                //    i = ++i;

                //    builder.Append(c);
                //}
                //if (char.IsWhiteSpace(c) || char.IsPunctuation(c))
                //{
                //    builder.ToString();
                //    builder.Clear();
                //}
                //else
                //{
                //    builder.Append(c);
                //}
                
            }
            line = builder.ToString(0, builder.Length);
            Console.WriteLine("Its done!");
            Console.ReadKey();
            reader.Close();

            //FileOutput.Text = builder.ToString();
        }
        public int CounBufer
        {
            get
            {
                int i = 0;
                foreach (char c in result)
                {
                    if (c == '\r' || c == '\n')
                    {
                        i = +i;
                    }
                    else
                    {
                        continue;
                    }
                }
                return i;
            }
        }
    }
}
