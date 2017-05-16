using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation;
using TextHandler.Implementation.TextItems;
using TextHandler.Implementation.TextItems.SentenceItems;

namespace TextHandler.NewParser
{
    public static class MainParser
    {
        char[] result;
        char[] argRes;
        char[] argSymb;
        //public StreamReader Initiate(string path)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    StreamReader reader = File.OpenText(path);
        //    return reader;
        //}
        public IList<char[]> ParseLevel1(string path)
        {
            StringBuilder builder = new StringBuilder();
            StreamReader reader = File.OpenText(path);
            result = new char[reader.BaseStream.Length];
            reader.Read(result, 0, (int)reader.BaseStream.Length);
            List<char[]> bufer = new List<char[]>();
            int i = 0;
            int j = 0;
            int n = 0;
            foreach (char c in result)
            {
                switch (c)
                {
                    case '\r':
                        n = i;
                        i = i+1;
                        j = j+1;
                        break;
                    case '\n':
                        argRes = new char[n];
                        Array.Copy(result, i-j, argRes, 0, n);
                        bufer.Add(argRes);
                        n = 0;
                        i = ++i;
                        j = 0;
                        break;
                    default:
                        if (i >= result.Length)
                        {
                            i = i++;
                            j = j++;
                            argRes = new char[n];
                            //pn = ++pn;
                            Array.Copy(result, i-j, argRes, 0, n);
                            bufer.Add(argRes);
                        }
                        else
                        {
                            i = ++i;
                            j = ++j;
                        }

                        break;
                }
            }
            return bufer;
        }
        public ICollection<Sentence> ParseLevel2(IList<char[]> l1)
        {
            Text text = new Text();
            ICollection<Sentence> textItems;            
            //ICollection<Sentence> sentences=new ICollection<Sentence>(); 
            int pn = 0;
            int x = 0;
            int y = 0;
            //char symb;

            int i = 0;
            
            
            int cLength=0;
            int sLength = 0;
            foreach (char[] c in l1)
            {
                char symb;
                Sentence sentence = new Sentence();
                
                for (int num = 0; num <= c.Length; num++)
                {
                    symb=c[num];
                    if(IsParagraph(symb)==true)
                    {
                        
                    }
                    else if (IsSentence(symb)==true)
                    {

                    }
                }
            }

        }
        public  ParseSymbols(char symb)
        {
            if (char.IsLetter(symb)) 
                       {
                            if(++num<=c.Length & char.IsLetter(c[++num]))
                            {
                                cLength=++cLength;
                                num=++num;
                            }
                            else
                            {
                                argSymb=new char[cLength];
                                Array.Copy(c,num,argSymb,0,cLength);
                                ParseLetters(argSymb);
                                //sentence.Add(ParseLetters(argSymb));
                                cLength=0;
                            }
                        }
                        else
                        {
                            if (char.IsDigit(symb))
                            {
                                if(++num>=c.Length & char.IsDigit(c[++num]))
                                {
                                    cLength=++cLength;
                                    num=++num;
                                }
                                    else
                                    {
                                        argSymb=new char[cLength];
                                        Array.Copy(c,num,argSymb,0,cLength);
                                        ParseDigits(argSymb);
                                        cLength=0;
                                    }
                            }
                            else
                            {
                                if (char.IsWhiteSpace(symb))
                                {
                                    if(++num<=c.Length & char.IsWhiteSpace(c[++num]))
                                    {
                                        cLength=++cLength;
                                        num=++num;
                                    }
                                    else
                                    {
                                        argSymb = new char[cLength];
                                        Array.Copy(c, num, argSymb, 0, cLength);
                                        ParseSeparators(argSymb);
                                        cLength=0;
                                    }
                                }
                                else
                                {
                                    if (++num <= c.Length)
                                    {
                                        cLength = ++cLength;
                                        num = ++num;
                                    }
                                    else
                                    {
                                        argSymb = new char[cLength];
                                        Array.Copy(c, num, argSymb, 0, cLength);
                                        ParseOtherSymbols(argSymb);
                                        cLength = 0;
                                    }
                                }
                            }
    }
}
        public static bool IsSentence(char c)
        {
            List<char>list=new List<char>{'.','!','?'};
            return list.Contains(c);
        }
        public static bool IsParagraph(char c)
        {
            List<char>list=new List<char>{'\n','\r'};
            return list.Contains(c);
        }
        public static IsSentenceInsideParagraph(char[] c)
        {
            //char[] argPunct = new char[3] { '.', '?', '!' };
            char[] argSymb;
            
            int i = (Array.IndexOf(c,'.')!=null)?Array.IndexOf(c,'.'):
                        (Array.IndexOf(c,'?')!=null)?Array.IndexOf(c,'?'):
                        (Array.IndexOf(c,'!')!=null)?Array.IndexOf(c,'!'):0;
            //if (Array.IndexOf(c,'.')!=null||(Array.IndexOf(c,'?')!=null||(Array.IndexOf(c,'!')!=null))
            //{
            //    int i=Array.IndexOf(c,'.');
            //    argSymb=new char[i];
                
            //}
            //else
            //{
            //    if((Array.IndexOf(c,'?')!=null)
            //    {
            //        int i = (Array.IndexOf(c,'.')!=null)?Array.IndexOf(c,'.'):
            //            (Array.IndexOf(c,'?')!=null)?Array.IndexOf(c,'?'):
            //                (Array.IndexOf(c,'!')!=null)?Array.IndexOf(c,'!');
            //    }
            //    else()
            //}
        }
        public static Word ParseLetters(char[] argSymb)
        {
            Word word=new Word();
            word.Symbols=argSymb;
            return word;
        }
        public static Digit ParseDigits(char[] argSymb)
        {
            Digit digit=new Digit();
            digit.Symbols=argSymb;
            return digit;
        }
        public static WordSeparator ParseSeparators(char[] argSymb)
        {
            WordSeparator separator = new WordSeparator();
            separator.Symbols = argSymb;
            return separator;
        }
        public static OtherSymbols ParseOtherSymbols(char[] argSymb)
        {
            OtherSymbols symbols = new OtherSymbols();
            symbols.Symbols = argSymb;
            return symbols;
        }
    }
}
//foreach (char[] c in l1)
//{
//    pn = ++pn;

//    foreach (char s in c)
//    {

//        if(s=='.'||s=='?'||s=='!')
//        {

//        }   
//        else
//        {

//        }
//    }
//    text.TextItems.Add(sentence);
//}

            //char[] argSen;
            //int sen1 = 0;
            //int sen2 = 0;
            //foreach (char[] argRes in l1)
            //{
            //    foreach (char s in argRes)
            //    {
            //        sen1 = ++sen1;
            //        sen2 = ++sen2;
            //        if (s == '.')
            //        {
            //            if (sen1 >= argRes.Length)
            //            {
            //                Sentence sentence = new Sentence();
            //                sentence.paragraphNumber = pn1;
            //                argSen = new char[sen2];
            //                Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2);
            //                //sentence = thirdParse.Parse(argSen, pn);
            //                //text.TextItems.Add(sentence);
            //                sen1 = 0;
            //                sen2 = 0;
            //            }
            //            else
            //            {
            //                if (char.IsWhiteSpace(argRes[sen1]) && char.IsUpper(argRes[sen1 + 1]) || char.IsUpper(argRes[sen1]))
            //                {
            //                    Sentence sentence = new Sentence();
            //                    sentence.paragraphNumber = pn1;
            //                    argSen = new char[sen2];
            //                    Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2);
            //                    //sentence = thirdParse.Parse(argSen, pn);
            //                    //text.TextItems.Add(sentence);
            //                    sen2 = 0;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (sen1 >= argRes.Length)
            //            {
            //                Sentence sentence = new Sentence();
            //                sentence.paragraphNumber = pn1;
            //                argSen = new char[sen2];
            //                Array.Copy(argRes, sen1 - sen2, argSen, 0, sen2);
            //                //sentence = thirdParse.Parse(argSen, pn);
            //                //text.TextItems.Add(sentence);
            //                sen1 = 0;
            //                sen2 = 0;
            //            }
            //        }
            //}                
            //    }
            //return text;
