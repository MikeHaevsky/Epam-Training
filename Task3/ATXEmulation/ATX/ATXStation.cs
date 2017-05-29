﻿using ATXEmulation.ATX.Components;
using ATXEmulation.ATX;
using ATXEmulation.ATX.Exchanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX
{
    public class ATXStation
    {
        private int CountSessions=0;
        public ATXStation()
        {
            Sessions = new List<ISession>();
        }
        public ICollection<Port> Ports
        {
            get;
            set;
        }
        public ICollection<ITerminal> Terminals
        {
            get;
            set;
        }
        public ICollection<ISession> Sessions
        {
            get;
            set;
        }
        public ICollection<Call> CallSessions
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
        //public void ConnectBilling(BillingSystem billingSystem)
        //{

        //}
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
                if (find_OutPort(call).Status == PortStatusValue.Free)
                {
                    save_Session(call);
                    //Console.WriteLine("Wait...");
                    find_OutPort(call).IncomingCalledPort(call.FirstAbonent);
                    //call.Status = SessionSatusValue.Wait;
                    
                }
                else
                {
                    Console.WriteLine("Abonent is busy now...\nCallback later");
                    call.Status = SessionStatusValue.Compleated;
                }
                //Ports.Single(x => x.Number == call.SecondAbonent).IncomingCalledPort(call.SecondAbonent);
                //Ports.Single(x => x.Number.Number == outNumber && x.Number.Code == outCode).IncomingCalledPort(call.SecondAbonent);
                Console.WriteLine("working");
            }
            catch
            {
                Console.WriteLine("Please, check the called number");
                //Call endedCall = call;
                //Sessions.Add(call);
            }
            finally
            {
                //Sessions = new List<Call>(new Call(call));
                //Sessions.Add(call);
                //save_Session(call);
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
        public void port_Answered(object sender, int numberSession)
        {
            Sessions.ElementAt(numberSession).Status = SessionStatusValue.OpenChanel;
        }
        public void port_Dropped(object sender, int numberSession)
        {
            Sessions.ElementAt(numberSession).Status = SessionStatusValue.Compleated;
            Call call = Sessions.ElementAt(numberSession) as Call;
            //hardcode time
            call.TimeOverSeconds = 180;
            onVoteBilling(call);
            find_InPort(Sessions.ElementAt(numberSession)).Status = PortStatusValue.Free;
            find_OutPort(Sessions.ElementAt(numberSession)).Status = PortStatusValue.Free;
        }
        private Port find_OutPort(ISession session)
        {
            int outNumber = session.SecondAbonent.Number;
            short outCode = session.SecondAbonent.Code;
            return Ports.Single(x => x.Number.Number == outNumber && x.Number.Code == outCode);
        }
        public void BlockingPort(TelephoneNumber number)
        {
            int num = number.Number;
            short code = number.Code;
            Ports.Single(x => x.Number.Number == num && x.Number.Code == code).Status = PortStatusValue.Blocked;
        }
        public void UnblockingPort(TelephoneNumber number)
        {
            int num = number.Number;
            short code = number.Code;
            Ports.Single(x => x.Number.Number == num && x.Number.Code == code).Status = PortStatusValue.Free;
        }
        private Port find_InPort(ISession session)
        {
            int inNumber = session.FirstAbonent.Number;
            short inCode = session.FirstAbonent.Code;
            return Ports.Single(x => x.Number.Number == inNumber && x.Number.Code == inCode);
        }
        public void save_Session(TextMessage session)
        {
            int outNumber = session.SecondAbonent.Number;
            int inNumber = session.FirstAbonent.Number;
            short outCode=session.SecondAbonent.Code;
            short inCode = session.FirstAbonent.Code;
            find_InPort(session).SetNumberActiveSession(CountSessions);
            find_OutPort(session).SetNumberActiveSession(CountSessions);
            Sessions.Add(session);
            CountSessions = ++CountSessions;
        }
        public void save_Session(Call session)
        {
            int outNumber = session.SecondAbonent.Number;
            int inNumber = session.FirstAbonent.Number;
            short outCode = session.SecondAbonent.Code;
            short inCode = session.FirstAbonent.Code;
            find_InPort(session).SetNumberActiveSession(CountSessions);
            find_OutPort(session).SetNumberActiveSession(CountSessions);
            Sessions.Add(session);
            CountSessions = ++CountSessions;
        }
        #region Events for Billing
        private EventHandler<Call> _voteBilling;
        public event EventHandler<Call> VoteBilling
        {
            add
            {
                _voteBilling += value;
            }
            remove
            {
                _voteBilling -= value;
            }
        }
        private void onVoteBilling(Call call)
        {
            if (_voteBilling != null)
                _voteBilling(this, call);
        }
        //public 
        #endregion
        //public static IEnumerable<int> IndexesWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        //{
        //    int index = 0;
        //    foreach (T element in source)
        //    {
        //        if (predicate(element))
        //        {
        //            yield return index;
        //        }
        //        index++;
        //    }
        //}


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
