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
        public const string strSeparator = "_____________________________";
        public const string strPSeparator = "- - - - - - - - - - - - - - -";
        private const int time = 1000;
        private static Airline _airline;
        public static void Start( Airline airline)
        {
            _airline = airline;
            {
                Console.Clear();
                Console.WriteLine(" Hollo, master!\n"+
                    "What are you want from me?\n"+
                    "Choose your operation.....");
                Console.WriteLine(strSeparator);
                Console.WriteLine("1.Begin and show airline info\n"+
                    "0.Exit program");
                ChooseAction0(Console.ReadLine(), "level0");
                Console.ReadLine();
            }
        }
        private static void ChooseAction0(string s,string level)
        {
            switch (s)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(_airline.ShowInfo());
                    Console.WriteLine(strSeparator);
                    Action0("level0");
                    break;
                case "0":
                    Environment.Exit(0);
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
                    Console.WriteLine(strSeparator);
                    Action0("level1");
                    break;
                case"2":
                    Console.Clear();
                    FindItems();
                    Console.WriteLine(strSeparator);
                    Action0("level1");
                    break;
                case"3":
                    Console.Clear();
                    ShowAirlineInfo();
                    Console.WriteLine(strSeparator);
                    Action0("level1");
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
                    Environment.Exit(0);
                    break;
                default:
                    Error("level1");
                    break;
            }
        }
        private static void Action0(string level)
        {
            Console.WriteLine(strSeparator);
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
                "Sum capacity: {3}\n"+
                "Sum total load: {4}",
                _airline.Name, _airline.Slogan, _airline.GetSumRange(), _airline.GetSumCapacity(),_airline.GetSumTotalLoad());
        }
        private static void SortItems()
        {
            Console.WriteLine(string.Join("\n" + strPSeparator + "\n", _airline.SortByRange()));
            Console.WriteLine(strSeparator);
        }
        private static void FindItems()
        {
            int x, y;
            Console.WriteLine("Write first fuel range...");
            int.TryParse(Console.ReadLine(),out x);
            Console.WriteLine("Write roofer fuel range...");
            int.TryParse(Console.ReadLine(), out y);
            Console.Clear();
            Console.WriteLine("Search airplane with a fuel consumption more than {0} and less than {1}\nResult your searching :", x, y);
            Console.WriteLine(string.Join("\n", _airline.FindByFuelConsumption(x, y)));
        }
        private static void Error(string level)
        {
            Console.WriteLine("ERROR\nWrong key!\n!Please follow the instruction!");
            System.Threading.Thread.Sleep(time);
            switch (level)
            {
                case "level0":
                    Start(_airline);
                    break;
                case "level1":
                    ChooseAction0("1","level1");
                    break;
            }
        }
        private static void GoBack(string level)
        {
            switch (level)
            {
                case "level0":
                    Start(_airline);
                    break;
                case "level1":
                    ChooseAction0("1","level1");
                    break;
            }
        }
    }
}
