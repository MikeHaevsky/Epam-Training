using ATXEmulation.ATX;
using ATXEmulation.ATX.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation
{
    class Program
    {
        static void Main(string[] args)
        {
        //    ATXStation atxStation = new ATXStation();
        //    atxStation.PortAdded += ShowMessage;
        //    atxStation.TerminalAdded += ShowMessage;
        //    atxStation.Ports = new List<Port>(){new Port(1),new Port(2),new Port(3),new Port(4),new Port(5)};
        //    atxStation.Terminals = new List<Terminal>() 
        //    {
        //        new Terminal(1, 101), 
        //        new Terminal(1, 102), 
        //        new Terminal(1, 103), 
        //        new Terminal(1, 104)
        //    };
        //    atxStation.PortAdded -= ShowMessage;
        //    atxStation.TerminalAdded -= ShowMessage;
            //EventHandler _event;
            int i=0;
            ATXStation station = new ATXStation();
            station.Ports = new List<Port>()
            {
                new Port(new TelephoneNumber(375, 8680737), "Mike"),
                new Port(new TelephoneNumber(375, 7853457), "Valery")};
            station.Terminals = new List<ITerminal>()
            {
                new Terminal(1),
                new Terminal(2),
            };
            station.Connect(station.Ports.ElementAt(0));
            station.Ports.ElementAt(0).RegistrateTerminal(station.Terminals.ElementAt(0));
            station.Connect(station.Ports.ElementAt(1));
            station.Ports.ElementAt(1).RegistrateTerminal(station.Terminals.ElementAt(1));
            station.Terminals.ElementAt(0).Connecting();
            TelephoneNumber calledNumber=new TelephoneNumber(375,7863457);
            station.Terminals.ElementAt(0).BeginCall(calledNumber);
            //station.Terminals.ElementAt(1).BeginCall(new TelephoneNumber());
            //i = ++i;
            //Terminal terminal = new Terminal(i);
            //i = ++i;
            //Terminal terminal1 = new Terminal(i++);
            //station.
            //terminal.Id = 1;

            //terminal.Disconnected += port.TerminalDisconnect;
            //terminal.Connected += port.TerminalConnect;

            //terminal.Dropped += Console.WriteLine("1");
            //station.Terminals = new List<Terminal>() { };
            //station.Terminals.Add(terminal);
            //terminal.Connected+=ShowEvent(_event);
            //terminal.Connecting();
            //terminal1.Connecting();
            //terminal.Disconnected -= port.TerminalDisconnect;
            //terminal.Connected -= port.TerminalConnect;
        }
        public ATXStation RunATXStation()
        {
            ATXStation station = new ATXStation();
            return station;
        }
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
