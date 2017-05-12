using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation.TextItems.SentenceItems;
using TextHandler.Parser.Factories;

namespace TextHandler.Parser
{
    public class FirstParser
    {
        //static string filename="D:\\Text.txt";
        char[] result;
        public FirstParser(string path)
        {
            WordFactory wf = new WordFactory();
            StringBuilder builder=new StringBuilder();
            StreamReader reader = File.OpenText(path);
            result = new char[reader.BaseStream.Length];
            reader.ReadAsync(result, 0, (int)reader.BaseStream.Length);
            //string symbol;
            foreach (char c in result)
            {
                //builder.Append(c);
                //if (char.IsLetterOrDigit(c))
                //{
                //    //Symbol symbol = new Symbol(c);
                //    symbol = char.ToString(c);
                //    Word word = new Word(symbol);
                //}
                if (char.IsWhiteSpace(c)||char.IsPunctuation(c))
                {
                    //string s1=builder.ToString();
                    wf.Create(builder.ToString());
                    //string S1=
                    //Console.WriteLine()
                    //return Word.Select(item=>item.Where())
                    builder.Clear();
                    
                }
                else
                {
                    builder.Append(c);
                }
                
                //if (char.IsLetterOrDigit(c))
                //{
                //    builder.Append(c);

                //    //if (char.IsWhiteSpace(c) || char.IsPunctuation(c))
                //    //{
                //    //    //Word word = new Word(builder.ToString(c));
                //    //}
                //}

                //if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                //{
                //    builder.Append(c);
                //}
            }
            Console.WriteLine("Its done!");
            Console.ReadKey();
            reader.Close();
            
            //FileOutput.Text = builder.ToString();
        }
    }
}
