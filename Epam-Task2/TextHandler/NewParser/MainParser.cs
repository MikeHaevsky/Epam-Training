using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation;
using TextHandler.Implementation.TextItems;
using TextHandler.Implementation.TextItems.SentenceItems;
using TextHandler.Interfaces;

namespace TextHandler.NewParser
{
    public class MainParser
    {
        char[] result;
        char[] argRes;
        char[] argSymb;
        private ICollection<Sentence> textItems;
        private ICollection<ISentenceItem> sentenceItems;
        
        public Text ParseLevel1(string path)
        {
            StringBuilder builder = new StringBuilder();
            StreamReader reader = File.OpenText(path);
            result = new char[reader.BaseStream.Length];
            reader.Read(result, 0, (int)reader.BaseStream.Length);
            textItems = new List<Sentence>();
            Text text=new Text();
            int pn = 0;
            int n = 0;
            int m = 0;
            int pos = 0;
            while (n < result.Length)
            {
                if (IsParagraph(result[n]) == true)
                {
                    m = n;
                    while (m < result.Length && IsParagraph(result[n]))
                    {
                        n++;
                    }
                    pn++;
                    argRes = new char[m];
                    Array.Copy(result, n-m, argRes, 0, m);
                    textItems=ParseSymbols(argRes,pn);
                    pos=n-1;
                    m = 0;
                }
                else
                {
                    if (IsParagraph(result[n]) == true)
                    {
                        m = n;
                        while (m < result.Length && IsSentence(result[n]))
                        {
                            n++;
                        }
                        argRes = new char[m];
                        Array.Copy(result, n - m, argRes, 0, m);
                        textItems = ParseSymbols(argRes, pn);
                        pos = n - 1;
                        m = 0;
                    }
                }
                n++;
            }
            text.TextItems=textItems;
            return text;
        }
        public ICollection<Sentence> ParseSymbols(char[] argRes,int pn)
        {
            
            sentenceItems = new List<ISentenceItem>();
            Sentence sentence = new Sentence();
            sentence.ParagraphNumber = pn;

            int i = 0;
            int j = 0;
            while (i < argRes.Length)
            {
                if (char.IsLetter(argRes[i]))
                {
                    j = i;
                    while (j < argRes.Length && char.IsLetter(argRes[j]))
                    {
                        j++;
                    }
                    argSymb = new char[j - i];
                    Array.Copy(argRes, i, argSymb, 0, j - i);
                    ParseLetters(argSymb);
                    sentenceItems.Add(ParseLetters(argSymb));
                    i = j - 1;
                }
                else
                {
                    if (char.IsDigit(argRes[i]))
                    {
                        j = i;
                        while (j < argRes.Length && char.IsDigit(argRes[j]))
                        {
                            j++;
                        }
                        argSymb = new char[j - i];
                        Array.Copy(argRes, i, argSymb, 0, j - i);
                        ParseDigits(argSymb);
                        sentenceItems.Add(ParseDigits(argSymb));
                        i = j - 1;
                    }
                    else
                    {
                        if (char.IsWhiteSpace(argRes[i]))
                        {
                            j = i;
                            while (j < argRes.Length && char.IsWhiteSpace(argRes[j]))
                            {
                                //j++;
                            }
                            argSymb = new char[j - i];
                            Array.Copy(argRes, i, argSymb, 0, j - i);
                            ParseSeparators(argSymb);
                            sentenceItems.Add(ParseSeparators(argSymb));
                            i = j - 1;
                        }
                        else
                        {
                            if (IsPunctuation(argRes[i]))
                            {
                                j = i;
                                while (j < argRes.Length && IsPunctuation(argRes[j]))
                                {
                                    j++;
                                }
                                argSymb = new char[j - i];
                                Array.Copy(argRes, i, argSymb, 0, j - i);
                                ParsePunctuations(argSymb);
                                sentenceItems.Add(ParsePunctuations(argSymb));
                                i = j - 1;
                            }
                            else
                            {
                                j = i;
                                while (j < argRes.Length)
                                {
                                    j++;
                                }
                                argSymb = new char[j - i];
                                Array.Copy(argRes, i, argSymb, 0, j - i);
                                ParsePunctuations(argSymb);
                                sentenceItems.Add(ParseOtherSymbols(argSymb));
                                i = j - 1;
                            }
                        }
                    }
                }
                i++;
            }
            return textItems;
}
        private static bool IsPunctuation(char c)
        {
            List<char> list = new List<char> { ',', ':', ';','-'};
            return list.Contains(c);
        }
        private static bool IsSentence(char c)
        {
            List<char>list=new List<char>{'.','!','?'};
            return list.Contains(c);
        }
        private  bool IsParagraph(char c)
        {
            List<char>list=new List<char>{'\n','\r'};
            return list.Contains(c);
        }
        private static Word ParseLetters(char[] argSymb)
        {
            Word word=new Word();
            word.Symbols=argSymb;
            return word;
        }
        private static Digit ParseDigits(char[] argSymb)
        {
            Digit digit=new Digit();
            digit.Symbols=argSymb;
            return digit;
        }
        private static WordSeparator ParseSeparators(char[] argSymb)
        {
            WordSeparator separator = new WordSeparator();
            separator.Symbols = argSymb;
            return separator;
        }
        private Punctuation ParsePunctuations(char[] argSymb)
        {
            Punctuation punctuation = new Punctuation();
            punctuation.Symbols = argSymb;
            return punctuation;
        }
        private static OtherSymbols ParseOtherSymbols(char[] argSymb)
        {
            OtherSymbols symbols = new OtherSymbols();
            symbols.Symbols = argSymb;
            return symbols;
        }
    }
}