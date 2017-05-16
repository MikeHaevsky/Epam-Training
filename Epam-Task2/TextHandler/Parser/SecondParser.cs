using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation;
using TextHandler.Implementation.TextItems;

namespace TextHandler.Parser
{
    public class SecondParser
    {
        Text text = new Text();
        public Text Parse(char[] argRes, int pn)
        {
            ThirdParse thirdParse = new ThirdParse();
            //Text text = new Text();
            char[] argSen;
            int sen1 = 0;
            int sen2 = 0;
            foreach (char s in argRes)
            {
                sen1 = ++sen1;
                sen2 = ++sen2;
                if (s == '.')
                {
                    if (sen1 >= argRes.Length)
                    {
                        Sentence sentence = new Sentence();
                        sentence.paragraphNumber = pn;
                        argSen = new char[sen2];
                        Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2);
                        sentence = thirdParse.Parse(argSen, pn);
                        text.TextItems.Add(sentence);
                        sen1 = 0;
                        sen2 = 0;
                    }
                    else
                    {
                        if (char.IsWhiteSpace(argRes[sen1]) && char.IsUpper(argRes[sen1 + 1]) || char.IsUpper(argRes[sen1]))
                        {
                            Sentence sentence = new Sentence();
                            sentence.paragraphNumber = pn;
                            argSen = new char[sen2];
                            Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2);
                            sentence = thirdParse.Parse(argSen, pn);
                            text.TextItems.Add(sentence);
                            sen2 = 0;
                        }
                    }
                }
                else
                {
                    if (sen1 >= argRes.Length)
                    {
                        Sentence sentence = new Sentence();
                        sentence.paragraphNumber = pn;
                        argSen = new char[sen2];
                        Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2);
                        sentence = thirdParse.Parse(argSen, pn);
                        text.TextItems.Add(sentence);
                        sen1 = 0;
                        sen2 = 0;
                    }
                }

            }
            return text;
        }
    }
}
