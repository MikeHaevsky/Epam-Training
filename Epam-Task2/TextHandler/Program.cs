using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            FirstParser parser = new FirstParser(path);
            Console.WriteLine("It's done");
            Console.ReadKey();
        }
    }
}
