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
        char[] argSymb;
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

            //first cycle counts
            int i = 0;
            int n = 0;
            int j = 0;
            int n2 = 0;

            //second cycle counts
            int x = 0;
            int y = 0;
            int z = 0;
            int m = 0;

            //ParserBufer bufer = new ParserBufer();
            //ICollection<String> Str;
            //List<StringBuilder>bufer = new List<StringBuilder>();
            //List<Char[]> bufer=new List<char[]>();
            //char[new CounBufer][] CounBufer;

            //Разбиваем на обзацы
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
                        Array.Copy(result, n2, argRes, 0, n);
                        //construct the buisness logics
                        foreach (char s in argRes)
                        {
                            if (char.IsLetter(s))
                            {
                                x = ++x;
                                y = ++y;
                                if (char.IsLetter(argRes[x]))
                                {
                                    continue;
                                }
                                else
                                {
                                    z = y - 1;
                                    argSymb = new char[z];
                                    Array.Copy(argRes, x - 1, argSymb, 0, z);
                                    y = 0;
                                }
                            }
                            else
                            {
                                if (char.IsDigit(s))
                                {
                                    x = ++x;
                                    y = ++y;
                                    if (char.IsDigit(argRes[x]))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        z = y - 1;
                                        argSymb = new char[z];
                                        Array.Copy(argRes, x - 1, argSymb, 0, z);
                                        y = 0;
                                    }
                                }
                                else
                                {
                                    if (char.IsWhiteSpace(s))
                                    {
                                        x = ++x;
                                        y = ++y;
                                        if (char.IsWhiteSpace(argRes[x]))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            z = y - 1;
                                            argSymb = new char[z];
                                            Array.Copy(argRes, x - 1, argSymb, 0, z);
                                            y = 0;
                                        }
                                    }
                                    else
                                    {
                                        x = ++x;
                                        y = ++y;
                                        if (char.IsPunctuation(argRes[x]))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            z = y - 1;
                                            argSymb = new char[z];
                                            Array.Copy(argRes, x - 1, argSymb, 0, z);
                                            y = 0;
                                        }
                                    }
                                }
                            }
                        }
                        i = ++i;
                        j = 0;
                        n2 = i;
                        break;
                    default:
                        i = ++i;
                        j = ++j;
                    break;
                }
            }
        }
    }
}
//line = builder.ToString(0, builder.Length);
//Console.WriteLine("Its done!");
//Console.ReadKey();
//reader.Close();

//FileOutput.Text = builder.ToString();

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
  
