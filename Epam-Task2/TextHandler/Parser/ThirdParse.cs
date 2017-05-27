using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation.TextItems;
using TextHandler.Implementation.TextItems.SentenceItems;

namespace TextHandler.Parser
{
    public class ThirdParse
    {
        public Sentence Parse(char[] argSen,int pn)
        {
            char[] argSymb;
            //char[] argPunct;// = new ['.','?','!']
            int x = 0;
            int y = 0;
            char[]argPunct=new char[3] {'.','?','!'};
            Sentence sentence = new Sentence();
            sentence.ParagraphNumber = pn;
            foreach (char s in argSen)
            {
                if (char.IsLetter(s))
                {
                    x = ++x;
                    y = ++y;
                    if (x >= argSen.Length)
                    {
                        argSymb = new char[y];
                        Array.Copy(argSen, x - y, argSymb, 0, y);
                        Word word = new Word();
                        word.Symbols = argSymb;
                        sentence.Items.Add(word);
                        y = 0;
                        x = 0;
                    }
                    else
                    {
                        if (char.IsLetter(argSen[x]) == false)
                        {
                            argSymb = new char[y];
                            Array.Copy(argSen, x - y, argSymb, 0, y);
                            Word word = new Word();
                            word.Symbols = argSymb;
                            sentence.Items.Add(word);
                            y = 0;
                        }
                    }
                }
                else
                {
                    if (char.IsDigit(s))
                    {
                        x = ++x;
                        y = ++y;
                        if (x >= argSen.Length)
                        {
                            argSymb = new char[y];
                            Array.Copy(argSen, x - y, argSymb, 0, y);
                            Digit digit = new Digit();
                            digit.Symbols = argSymb;
                            sentence.Items.Add(digit);
                            y = 0;
                            x = 0;
                        }
                        else
                        {
                            if (char.IsDigit(argSen[x]) == false)
                            {
                                argSymb = new char[y];
                                Array.Copy(argSen, x - y, argSymb, 0, y);
                                Digit digit = new Digit();
                                digit.Symbols = argSymb;
                                sentence.Items.Add(digit);
                                y = 0;
                            }
                        }
                    }
                    else
                    {
                        if (char.IsWhiteSpace(s))
                        {
                            x = ++x;
                            y = ++y;
                            if (x >= argSen.Length)
                            {
                                argSymb = new char[y];
                                Array.Copy(argSen, x - y, argSymb, 0, y);
                                y = 0;
                                x = 0;
                            }
                            else
                            {
                                if (char.IsWhiteSpace(argSen[x]) == false)
                                {
                                    argSymb = new char[y];
                                    Array.Copy(argSen, x - y, argSymb, 0, y);
                                    WordSeparator separator = new WordSeparator();
                                    separator.Symbols = argSymb;
                                    sentence.items.Add(separator);
                                    y = 0;
                                }
                                else
                                {
                                    y = --y;
                                }
                            }
                        }
                        else
                        {
                            if (char.IsPunctuation(s))
                            {
                                x = ++x;
                                y = ++y;
                                if (x >= argSen.Length)
                                {
                                    argSymb = new char[y];
                                    Array.Copy(argSen, x - y, argSymb, 0, y);
                                    Punctuation punctuation = new Punctuation();
                                    punctuation.Symbols = argSymb;
                                    sentence.items.Add(punctuation);
                                    y = 0;
                                    x = 0;
                                }
                                else
                                {
                                    if (char.IsPunctuation(argSen[x]) == false)
                                    {
                                        argSymb = new char[y];
                                        Array.Copy(argSen, x - y, argSymb, 0, y);
                                        Punctuation punctuation = new Punctuation();
                                        punctuation.Symbols = argSymb;
                                        sentence.items.Add(punctuation);
                                        y = 0;
                                    }
                                }
                            }
                            else
                            {
                                x = ++x;
                                y = ++y;
                                if (x >= argSen.Length)
                                {
                                    argSymb = new char[y];
                                    Array.Copy(argSen, x - y, argSymb, 0, y);
                                    y = 0;
                                    x = 0;
                                }
                                else
                                {
                                    if (char.IsLetter(argSen[x]) == false ||
                                        char.IsDigit(argSen[x]) == false ||
                                        char.IsWhiteSpace(argSen[x]) == false ||
                                        char.IsPunctuation(argSen[x]) == false)
                                    {
                                        argSymb = new char[y];
                                        Array.Copy(argSen, x - y, argSymb, 0, y);
                                        y = 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return sentence;
        }
    }
}
