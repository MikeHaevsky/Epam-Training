using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline
{
    static class GUI
    {
        public const string separator = "_____________________________________________________________";
        public static void Start()
        {
            Console.WriteLine(" Hollo, master!\n What are you want from me?\n Choose your operation.....\n");
            Console.WriteLine("{0}",separator);
            Console.WriteLine("1.Show airline info\n 2. Exit program");
        }
    }
}
