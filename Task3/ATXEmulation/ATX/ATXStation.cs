using ATXEmulation.ATX.Components;
using ATXEmulation.ATX.Events;
using ATXEmulation.ATX.Exchanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX
{
    class ATXStation
    {
        private ICollection<Port> _ports;
        private ICollection<ITerminal> _terminals;
        private ICollection<ISession> _sessions;
        int count;
        public ATXStation()
        {
            Sessions = new List<ISession>();
        }
        public ICollection<Port> Ports
        {
            get
            {
                return _ports;
            }
            set
            {
                _ports = value;
            }
        }
        public ICollection<ITerminal> Terminals
        {
            get
            {
                return _terminals;
            }
            set
            {
                _terminals = value;
            }
        }
        public ICollection<ISession> Sessions
        {
            get;
            set;
        }
        public void Connect(Port port)
        {
            port.Connected += ConnectToStation;
            port.Disconnected += DisconnectFromStation;
        }
        public void Disconnect(Port port)
        {
            port.Connected -= ConnectToStation;
            port.Disconnected -= DisconnectFromStation;
        }
        public void ConnectToStation(object sender, EventArgs e)
        {
            Port port = sender as Port;
            if (port != null)
            {
                port.Called+=port_Called;
                port.Answered+=port_Answered;
                port.Dropped+=port_Dropped;
                //IncomingCall += port.IncomingCalledPort;
            }
        }
        public void DisconnectFromStation(object sender, EventArgs e)
        {
            Port port = sender as Port;
            if (port != null)
            {
                port.Called -= port_Called;
                port.Answered -= port_Answered;
                port.Dropped -= port_Dropped;
                //IncomingCall -= port.IncomingCalledPort;
            }
        }
        public void port_Called(object sender, Call call)
        {
            int outNumber = call.SecondAbonent.Number;
            short outCode=call.SecondAbonent.Code;
            //Port port=Ports.Where(x=>x.Number==outNumber).Select();
            //Port port = Ports.FirstOrDefault(x => x.Number == outNumber);
            //Ports.Single(x=>x.Number.Number==outNumber&&x.Number.Code==outCode);

            //Port port = Ports.Single(x=>x.Number.Number==outNumber&&x.Number.Code==outCode);
            //Ports.Single(x=>x.Number.Number==outNumber&&x.Number.Code==outCode).Dispose();
            try
            {
                //Ports.FirstOrDefault(x => x.Number == call.SecondAbonent).IncomingCalledPort(call.SecondAbonent);
                //Ports.Single(x=>x.Status==PortStatusValue.);
                if (Ports.Single(x => x.Number.Number == outNumber && x.Number.Code == outCode).Status == PortStatusValue.Free)
                {
                    //Console.WriteLine("Wait...");
                    Ports.Single(x => x.Number.Number == outNumber && x.Number.Code == outCode).IncomingCalledPort(call.SecondAbonent);
                    Ports.Single(x => x.Number.Number == outNumber && x.Number.Code == outCode).Status = PortStatusValue.Busy;
                }
                else
                {
                    Console.WriteLine("Abonent is busy now...\nCallback later");
                    call.Status = SessionSatusValue.Compleated;
                }
                //Ports.Single(x => x.Number == call.SecondAbonent).IncomingCalledPort(call.SecondAbonent);
                //Ports.Single(x => x.Number.Number == outNumber && x.Number.Code == outCode).IncomingCalledPort(call.SecondAbonent);
                Console.WriteLine("working");
            }
            catch
            {
                Console.WriteLine("Local error");
                //Call endedCall = call;
                //Sessions.Add(call);
            }
            finally
            {
                //Sessions = new List<Call>(new Call(call));
                Sessions.Add(call);
            }
            //Port sPort = _ports.FirstOrDefault(x => x.Number == CallNumber);
        }
        private EventHandler<TelephoneNumber> _incomingCall;
        public event EventHandler<TelephoneNumber> IncomingCall
        {
            add
            {
                _incomingCall += value;
            }
            remove
            {
                _incomingCall -= value;
            }
        }
        private void OnIncomingCall(TelephoneNumber number)
        {
            if (_incomingCall != null)
                _incomingCall(this, number);
        }
        public void port_Answered(object sender, EventArgs e)
        {

        }
        public void port_Dropped(object sender, EventArgs e)
        {

        }

        //public Port AddNumber(TelephoneNumber number,Port abonent)
        //{
        //    Terminal terminal = new Terminal(count);
        //    Port port = new Port(number,abonent.Abonent);
        //    PhoneBook.Add(terminal.Id, abonent.Abonent);
        //    return port;
        //}
        //public int GetSomePort(int portNumber)
        //{
        //    return Ports.ElementAt(portNumber).Id;
        //    //return Ports.Where(x => x.Id == pNumber).Select(y => y.Id);
        //}
        //public PortStatusValue GetSomePortStatus(int pNumber)
        //{
        //    return Ports.ElementAt(pNumber).Status;
        //    //return Ports.Where(x=>x.Id == pNumber).Select(y=>y.State);
        //}
        //public int GetFreePort()
        //{
        //    //for(int i=0, i<this.PortsCount(),i++){}
        //}
        //public string GetFreePorts()
        //{
        //    return String.Join("\n",Ports.Where(x => x.Status==PortStatusValue.Free).Select(y => y.Id));
        //}
        //public int PortsCount()
        //{
        //    return Ports.Count;
        //}
        //private static void ShowMessage(string message)
        //{
        //    Console.WriteLine(message);
        //}

        //public delegate void NewPortsHandler(object sender, PortEventArgs e);
        //public delegate void NewTerminalHandler(object sender, TerminalEventArgs e);

        //public int GetNumberValue()
        //{
        //    return Terminals.
        //}
        //public static bool IsFree(this int portNumber)
        //{
        //    if (Ports.ElementAt(portNumber).Status == PortStatusValue.Free)
        //        return true;
        //    else
        //        return false;
        //}   
    }
}
