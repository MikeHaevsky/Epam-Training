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
        private const int time = 1000;
        private const string p = "pause";
        private const string t = "time";
        private static Airline _airline;
        public static void Start()
        {
            {
                Console.Clear();
                Console.WriteLine(" Hollo, master!\n"+
                    "What are you want from me?\n"+
                    "Choose your operation.....");
                Console.WriteLine("{0}", separator);
                Console.WriteLine("1.Begin and show airline info\n"+
                    "0.Exit program");
                string choseAction = Console.ReadLine();
                ChooseAction0(choseAction);
                Console.ReadLine();
            }
        }
        private static void ChooseAction0(string s)
        {
            switch (s)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("{0}",_airline.ShowInfo());
                    Console.WriteLine(separator);
                    Action0("level1");
                    //ChooseAction1(Console.ReadLine());
                    break;
                case "0":
                    Exit();
                    break;
                default:
                    Error("level0");
                    break;
            }
        } 
        private static void ChooseAction1(string s,string level)
        {
            switch (s)
            {
                case "1":
                    Console.Clear();
                    SortItems();
                    Console.WriteLine(separator);
                    Wait(p);
                    break;
                case"2":
                    Console.Clear();
                    FindItems();
                    Wait(p);
                    ChooseAction0("1");
                    break;
                case"3":
                    Console.Clear();
                    ShowAirlineInfo();
                    Action0("level1");
                    Wait(p);
                    break;
                case "4":
                    if (level == "level1")
                    {
                        GoBack("level1");
                    }
                    else
                    {
                        GoBack("level0");
                    }
                    break;
                case "0":
                    Exit();
                    break;
                default:
                    Error("level1");
                    break;
            }
        }
        private static void Action0(string level)
        {
            Console.WriteLine(separator);
            Console.WriteLine("Choose your operation.....\n" +
                "1.Sort airplanes by the range of fly\n" +
                "2.Find airplanes about the range of fuel consumption\n" +
                "3.Show full airline information\n" +
                "4.Go back\n" +
                "0.Exit program");
            ChooseAction1(Console.ReadLine(),level);
        }
        private static void ShowAirlineInfo()
        {
            Console.WriteLine("Airline: {0}\n" +
                "Slogan: {1}\n" +
                "Sum rage: {2}\n" +
                "Sum capacity: {3}",
                _airline._name, _airline._slogan, _airline.GetSumRange(), _airline.GetSumCopacity());
        }
        private static void SortItems()
        {
            Console.WriteLine(string.Join("\n",_airline.SortByRange()));
        }
        private static void FindItems()
        {
            int x, y;
            Console.WriteLine("Write first fuel range...");
            int.TryParse(Console.ReadLine(),out x);
            Console.WriteLine("Write roofer fuel range...");
            int.TryParse(Console.ReadLine(), out y);
            Console.Clear();
            Console.WriteLine("Search airplane with a fuel consumption more than {0} and less than {1}\nResult you searching :",x,y);
            Console.WriteLine(string.Join("\n", _airline.FindByFuelConsumption(x, y)));
        }
        private static void Wait(string value)
        {
            switch (value)
            {
                case "pause":
                    Console.WriteLine("Press any key to return");
                    Console.ReadKey();
                    break;
                case "time":
                    System.Threading.Thread.Sleep(time);
                    break;
            }
        }
        private static void Error(string level)
        {
            Console.WriteLine("ERROR\nWrong key!\n!Please follow the instruction!");
            Wait(t);
            switch (level)
            {
                case "level0":
                    Start();
                    break;
                case "level1":
                    ChooseAction0("1");
                    break;
            }
            //Start();
        }
        private static void GoBack(string level)
        {
            switch (level)
            {
                case "level0":
                    Start();
                    break;
                case "level1":
                    ChooseAction0("1");
                    break;
            }
        }
        private static void Exit()
        {
            //Console.Clear();
            //Console.WriteLine("Exit program.");
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.Write(".");
            //    Wait(100);
            //}
            Environment.Exit(0);
        }
        public static Airline Airline
        {
            set { _airline = value; }
        }
    }
}
