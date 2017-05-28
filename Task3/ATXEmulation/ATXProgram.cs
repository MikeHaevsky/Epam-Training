using ATXEmulation.ATX;
using ATXEmulation.ATX.Exchanges;
using ATXEmulation.ATX.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation
{
    public static class ATXProgram
    {
        //static void Main(string[] args)
        //{
        //    ATXStation station = new ATXStation();
        //    station.Ports = new List<Port>()
        //    {
        //        new Port(new TelephoneNumber(375, 8680737), "Mike"),
        //        new Port(new TelephoneNumber(375, 5860786), "Vadim"),
        //        new Port(new TelephoneNumber(375, 7868348), "Valery"),
        //        new Port(new TelephoneNumber(375, 8833548), "Eugeny")
        //    };
        //    station.Terminals = new List<ITerminal>()
        //    {
        //        new Terminal(0),
        //        new Terminal(1),
        //        new Terminal(2),
        //        new Terminal(3)
        //    };
        //    station.Connect(station.Ports.ElementAt(0));
        //    station.Ports.ElementAt(0).RegistrateTerminal(station.Terminals.ElementAt(0));
        //    station.Terminals.ElementAt(0).Connecting();

        //    station.Connect(station.Ports.ElementAt(1));
        //    station.Ports.ElementAt(1).RegistrateTerminal(station.Terminals.ElementAt(1));
        //    station.Terminals.ElementAt(1).Connecting();

        //    station.Connect(station.Ports.ElementAt(2));
        //    station.Ports.ElementAt(2).RegistrateTerminal(station.Terminals.ElementAt(2));
        //    station.Terminals.ElementAt(2).Connecting();

        //    station.Connect(station.Ports.ElementAt(3));
        //    station.Ports.ElementAt(3).RegistrateTerminal(station.Terminals.ElementAt(3));
        //    station.Terminals.ElementAt(3).Connecting();
                    
        //    TelephoneNumber calledNumber = new TelephoneNumber(375, 7868348);
        //    station.Terminals.ElementAt(0).BeginCall(calledNumber);
        //    station.Terminals.ElementAt(2).EndingCall();
        //    calledNumber = new TelephoneNumber(375, 8833548);
        //    station.Terminals.ElementAt(1).BeginCall(calledNumber);
        //}
        public static ATXStation Station
        {
            get;
            set;
        }
        public static void RunATXStation()
        {
            ATXStation station = new ATXStation();
            station.Ports = new List<Port>()
            {
                new Port(new TelephoneNumber(375, 8680737), "Mike"),
                new Port(new TelephoneNumber(375, 5860786), "Vadim"),
                new Port(new TelephoneNumber(375, 7868348), "Valery"),
                new Port(new TelephoneNumber(375, 8833548), "Eugeny")
            };
            station.Terminals = new List<ITerminal>()
            {
                new Terminal(0),
                new Terminal(1),
                new Terminal(2),
                new Terminal(3)
            };
            Station = station;
        }
        public static void AbonentConnect(int id)
        {
            Station.Connect(Station.Ports.ElementAt(id));
            Station.Ports.ElementAt(id).RegistrateTerminal(Station.Terminals.ElementAt(id));
            Station.Terminals.ElementAt(id).Connecting();
        }
        public static void AbonentDisconnect(int id)
        {
            Station.Terminals.ElementAt(id).EndingCall();
        }
        public static void AbonentCall(int id, TelephoneNumber number)
        {
            Station.Terminals.ElementAt(id).BeginCall(number);
        }
        public static void AbonentDrop(int id)
        {
            Station.Terminals.ElementAt(id).EndingCall();
        }
        //public static void AbonentCall(this TelephoneNumber number, int id)
        //{
        //    Station.Terminals.ElementAt(id).BeginCall(number);
        //}
        
        private static void ShowEvent(EventHandler asd, EventArgs e)
        {
            Console.WriteLine("{0}", asd);
        }
        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
