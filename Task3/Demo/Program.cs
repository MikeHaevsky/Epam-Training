using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATXEmulation;

namespace Demo
{
    static class Program
    {
        static void Main(string[] args)
        {
            //ATXProgram program = new ATXProgram();
            
            //ATXProgram.RunATXStation();           
            //ATXProgram.AbonentConnect(0);
            //ATXProgram.AbonentConnect(1);
            //ATXProgram.AbonentConnect(2);
            //ATXProgram.AbonentConnect(3);
            ATXProgram.AbonentConnect(0);
            ATXProgram.AbonentConnect(1);
            ATXProgram.AbonentConnect(2);
            ATXProgram.AbonentConnect(3);
            ATXEmulation.ATX.Components.TelephoneNumber number = new ATXEmulation.ATX.Components.TelephoneNumber(375,8680737);
            number.AbonentCall(2);
        }
        public static void AbonentCall(this ATXEmulation.ATX.Components.TelephoneNumber number, int id)
        {
            ATXProgram.AbonentCall(id, number);
        }
        //public static ATXEmulation.ATX.ATXStation station { get; set; }
    }
}
