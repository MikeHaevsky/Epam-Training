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
        //static string filename="D:\\Text.txt";
        char[] result;
        //ICollection<String> Str;
        char[] argRes;
        char[] argSen;
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
            
            //paragraphNumber for sentence
            int pn=0;

            //first cycle counts
            int i = 0;
            int n = 0;
            int j = 0;
            int n2 = 0;

            //second cyrcle count
            int sen = 0;
            int sen1 = 0;
            int sen2 = 0;

            //third cycle counts
            int x = 0;
            int y = 0;
            //int z = 0;
            //int m = 0;

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
                        pn = ++pn;
                        //Sentence sentence = new Sentence();
                        //sentence.paragraphNumber = pn;
                        Array.Copy(result, n2, argRes, 0, n);
                        //construct the buisness logics
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
                                }
                                else
                                {
                                    if (char.IsWhiteSpace(argRes[sen1]) && char.IsUpper(argRes[sen1 + 1]) || char.IsUpper(argRes[sen1]))
                                    {
                                        Sentence sentence = new Sentence();
                                        sentence.paragraphNumber = pn;
                                        argSen = new char[sen2];
                                        Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2);
                                        //ошибка it нужно поменять
                                        //foreach (char it in argSen)
                                        //{
                                        //    if (char.IsLetter(s))
                                        //    {
                                        //        x = ++x;
                                        //        y = ++y;
                                        //        if (x >= argSen.Length)
                                        //        {
                                        //            argSymb = new char[y];
                                        //            Array.Copy(argSen, x - y, argSymb, 0, y);
                                        //            Word word = new Word();
                                        //            word.letters = argSymb;
                                        //            sentence.items.Add(word);
                                        //            y = 0;
                                        //            x = 0;
                                        //        }
                                        //        else
                                        //        {
                                        //            if (char.IsLetter(argSen[x]) == false)
                                        //            {
                                        //                argSymb = new char[y];
                                        //                Array.Copy(argSen, x - y, argSymb, 0, y);
                                        //                Word word = new Word();
                                        //                //word.letters = argSymb;
                                        //                word.letters = argSymb;
                                        //                sentence.items.Add(word);
                                        //                //sentence.items.Add(word);
                                        //                //sentence.items = word;
                                        //                y = 0;
                                        //            }
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        if (char.IsDigit(s))
                                        //        {
                                        //            x = ++x;
                                        //            y = ++y;
                                        //            if (x >= argSen.Length)
                                        //            {
                                        //                argSymb = new char[y];
                                        //                Array.Copy(argSen, x - y, argSymb, 0, y);
                                        //                Digit digit = new Digit();
                                        //                digit.symbols = argSymb;
                                        //                sentence.items.Add(digit);
                                        //                y = 0;
                                        //                x = 0;
                                        //            }
                                        //            else
                                        //            {
                                        //                if (char.IsDigit(argSen[x]) == false)
                                        //                {
                                        //                    argSymb = new char[y];
                                        //                    Array.Copy(argSen, x - y, argSymb, 0, y);
                                        //                    Digit digit = new Digit();
                                        //                    digit.symbols = argSymb;
                                        //                    sentence.items.Add(digit);
                                        //                    y = 0;
                                        //                }
                                        //            }
                                        //        }
                                        //        else
                                        //        {
                                        //            if (char.IsWhiteSpace(s))
                                        //            {
                                        //                x = ++x;
                                        //                y = ++y;
                                        //                if (x >= argSen.Length)
                                        //                {
                                        //                    argSymb = new char[y];
                                        //                    Array.Copy(argSen, x - y, argSymb, 0, y);
                                        //                    y = 0;
                                        //                    x = 0;
                                        //                }
                                        //                else
                                        //                {
                                        //                    if (char.IsWhiteSpace(argSen[x]) == false)
                                        //                    {
                                        //                        argSymb = new char[y];
                                        //                        Array.Copy(argSen, x - y, argSymb, 0, y);
                                        //                        y = 0;
                                        //                    }
                                        //                }
                                        //            }
                                        //            else
                                        //            {
                                        //                if (char.IsPunctuation(s))
                                        //                {
                                        //                    x = ++x;
                                        //                    y = ++y;
                                        //                    if (x >= argSen.Length)
                                        //                    {
                                        //                        argSymb = new char[y];
                                        //                        Array.Copy(argSen, x - y, argSymb, 0, y);
                                        //                        Punctuation punctuation = new Punctuation();
                                        //                        punctuation.symbols = argSymb;
                                        //                        sentence.items.Add(punctuation);
                                        //                        y = 0;
                                        //                        x = 0;
                                        //                    }
                                        //                    else
                                        //                    {
                                        //                        if (char.IsPunctuation(argSen[x]) == false)
                                        //                        {
                                        //                            argSymb = new char[y];
                                        //                            Array.Copy(argSen, x - y, argSymb, 0, y);
                                        //                            Punctuation punctuation = new Punctuation();
                                        //                            punctuation.symbols = argSymb;
                                        //                            sentence.items.Add(punctuation);
                                        //                            y = 0;
                                        //                        }
                                        //                    }
                                        //                    //if (char.IsPunctuation(argRes[x])==false)
                                        //                    //{
                                        //                    //    argSymb = new char[y];
                                        //                    //    Array.Copy(argRes, x - y, argSymb, 0, y);
                                        //                    //    y = 0;
                                        //                    //}
                                        //                }
                                        //                else
                                        //                {
                                        //                    x = ++x;
                                        //                    y = ++y;
                                        //                    if (x >= argSen.Length)
                                        //                    {
                                        //                        argSymb = new char[y];
                                        //                        Array.Copy(argSen, x - y, argSymb, 0, y);
                                        //                        y = 0;
                                        //                        x = 0;
                                        //                    }
                                        //                    else
                                        //                    {
                                        //                        if (char.IsLetter(argSen[x]) == false ||
                                        //                            char.IsDigit(argSen[x]) == false ||
                                        //                            char.IsWhiteSpace(argSen[x]) == false ||
                                        //                            char.IsPunctuation(argSen[x]) == false)
                                        //                        {
                                        //                            argSymb = new char[y];
                                        //                            Array.Copy(argSen, x - y, argSymb, 0, y);
                                        //                            y = 0;
                                        //                        }
                                        //                    }
                                        //                }
                                        //            }
                                        //        }
                                        //    }
                                        //}
                                        text.TextItems.Add(sentence);
                                        sen2 = 0;
                                    }
                                }
                            }
                            
                        }
                        //text.TextItems.Add(sentence);
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


//if (x >= argRes.Length) 
//{

//    y = ++y;
//    argSymb = new char[y];
//    Array.Copy(argRes, x - y, argSymb, 0, y);
//    y = 0;
//}
////break;
//else
//{

//if (x >= argRes.Length)
//{
//    y = ++y;
//    argSymb = new char[y];
//    Array.Copy(argRes, x - y, argSymb, 0, y);
//    y = 0;
//    break;
//}
//x = ++x;
//y = ++y;
//if ()

//if (char.IsPunctuation(argRes[x]) == false)
//{
//    argSymb = new char[y];
//    Array.Copy(argRes, x - y, argSymb, 0, y);
//    y = 0;
//}
                                        
                                    
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
  
