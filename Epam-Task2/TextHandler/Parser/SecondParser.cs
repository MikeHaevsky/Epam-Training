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
        public Text Parse(char[] argRes, int pn)
        {
            ThirdParse thirdParse = new ThirdParse();
            Text text = new Text();
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
                        //sen3 = sen1;
                        //Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2+1);
                        Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2);
                        //sen3 = sen1+1;
                        //ThirdParse thirdParse = new ThirdParse(argSen,pn);
                        sentence = thirdParse.Parse(argSen, pn);
                        text.TextItems.Add(sentence);
                        sen1 = 0;
                        sen2 = 0;
                        //sen3 = 0;

                        //sentence.items=
                        //sentence.Items.Add(thirdParse.Parse(argSen, pn));
                        //sentence.items.Add(thirdParse.Parse(argSen, pn));


                    }
                    else
                    {
                        if (char.IsWhiteSpace(argRes[sen1]) && char.IsUpper(argRes[sen1 + 1]) || char.IsUpper(argRes[sen1]))
                        {
                            Sentence sentence = new Sentence();
                            sentence.paragraphNumber = pn;
                            argSen = new char[sen2];
                            //sen3 = sen1;
                            Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2);
                            //sen3 = sen1 + 1;
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
                        //sen3 = sen1;
                        //Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2+1);
                        Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2);
                        //sen3 = sen1+1;
                        //ThirdParse thirdParse = new ThirdParse(argSen,pn);
                        sentence = thirdParse.Parse(argSen, pn);
                        text.TextItems.Add(sentence);
                        sen1 = 0;
                        sen2 = 0;
                        //sen3 = 0;
                    }
                }

            }
            return text;
        }
    }
}
