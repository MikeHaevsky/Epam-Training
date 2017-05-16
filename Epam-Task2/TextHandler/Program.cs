using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Implementation;
using TextHandler.NewParser;
using TextHandler.Parser;

namespace TextHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string filename = "Data.txt";
            //string path = string.Concat(Directory.GetCurrentDirectory()," ", filename);
            string path = "D:\\Data.txt";
            
            //FirstParser parser = new FirstParser();
            //MainParser parser = new MainParser();
            
            Text text = new Text();
            //text=parser.Parse(path);
            MainParser ParseLevel1(path);

            //Console.WriteLine(text.Query2());
            //rigth queryies
            //Console.WriteLine(string.Join("\n", text.Query1()));
            //Console.WriteLine(text.ToString());
            Console.WriteLine("It's done");
            Console.ReadKey();
        }
    }
}
