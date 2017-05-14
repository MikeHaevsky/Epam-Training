using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation.TextItems;
using TextHandler.Implementation.TextItems.SentenceItems;

namespace TextHandler.Parser
{
    class ThirdParse
    {
        Sentence Parse(char[] argSen,int pn)
        {
            //char[] argSen;
            char[] argSymb;
            int x = 0;
            int y = 0;
            Sentence sentence = new Sentence();
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
                        word.letters = argSymb;
                        sentence.items.Add(word);
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
                            //word.letters = argSymb;
                            word.letters = argSymb;
                            sentence.items.Add(word);
                            //sentence.items.Add(word);
                            //sentence.items = word;
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
                            digit.symbols = argSymb;
                            sentence.items.Add(digit);
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
                                digit.symbols = argSymb;
                                sentence.items.Add(digit);
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
                                    y = 0;
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
                                    punctuation.symbols = argSymb;
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
                                        punctuation.symbols = argSymb;
                                        sentence.items.Add(punctuation);
                                        y = 0;
                                    }
                                }
                                //if (char.IsPunctuation(argRes[x])==false)
                                //{
                                //    argSymb = new char[y];
                                //    Array.Copy(argRes, x - y, argSymb, 0, y);
                                //    y = 0;
                                //}
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
