using ProjectAirline.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline
{
    static class GUI
    {
        public const string separator = "_____________________________";
        public const string pseparator = "- - - - - - - - - - - - - - -";
        private static Airline _airline;
        public static void Start()
        {
            //if (flag == 0)
            {
                Console.Clear();
                Console.WriteLine(" Hollo, master!\n What are you want from me?\n Choose your operation.....");
                Console.WriteLine("{0}", separator);
                Console.WriteLine("1.Show airline info\n2.Exit program");
                string choseAction = Console.ReadLine();
                ChooseAction1(choseAction);
                Console.ReadLine();
            }
        //    if
        }
        private static void ChooseAction1(string s)
        {
            switch (s)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("{0}",_airline.ShowInfo());
                    Console.ReadKey();
                    break;
                //case "2":break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Exit program");
                    Environment.Exit(0);
                    break;
                default:
                    Error();
                    break;
            }
            Start();
        } 
        private static void SortItems()
        {
            int x, y;
            Console.WriteLine("Write first fuel range...");
            int.TryParse(Console.ReadLine(),out x);
            Console.WriteLine("Write roofer fuel range...");
            int.TryParse(Console.ReadLine(), out y);
            Console.WriteLine(string.Join("\n", _airline.FindByFuelConsumption(x, y)));
        }
        private static void Error()
        {
            Console.WriteLine("ERROR\nWrong key!\n!Please follow the instruction!");
            System.Threading.Thread.Sleep(3000);
            Start();
        }
        public static Airline Airline
        {
            set { _airline = value; }
        }
    }
}
