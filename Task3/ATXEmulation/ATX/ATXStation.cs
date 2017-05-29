using ATXEmulation.ATX.Components;
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
        public void GetHistory()
        {
            CallSessions.Select(items=>items);
        }
        public void FilteredHistoryOverTheDateSpan(ICollection<Call> sessions,DateTime date1,DateTime date2)
        {
            sessions.Where(item => (item.StartTimeSession > date1) && (item.StartTimeSession < date2));
                //return _airplanes.Where(item => (item.FuelConsumption > x) & (item.FuelConsumption < y)).Select(item => string.Format("{1}{0} | FuelConsumption:{2} \n", item.Model, item.Producer, item.FuelConsumption));
        }
        public void FilteredHistoryOverTheCurrentDate(ICollection<Call> sessions, DateTime date)
        {
            sessions.Where(item=>(item.StartTimeSession==date));
        }
        public void FilteredHistiryOverTheDuration(ICollection<Call> sessions, TimeSpan duration1, TimeSpan duration2)
        {
            sessions.Where(item=>(item.Duration>duration1)&&(item.Duration<duration2));
        }
        public void FilteredHistoryOverTheAbonent(ICollection<Call> sessions, TelephoneNumber abonent)
        {
            sessions.Where(item => item.SecondAbonent == abonent);
        }
        public void GetCallHistory(TelephoneNumber number)
        {
            Sessions.Where(item => item.FirstAbonent==number);
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
            try
            {
                if (find_OutPort(call).Status == PortStatusValue.Free)
                {
                    save_Session(call);
                    find_OutPort(call).IncomingCalledPort(call.FirstAbonent);
                }
                else
                {
                    Console.WriteLine("Abonent is busy now...\nCallback later");
                    call.Status = SessionStatusValue.Compleated;
                }
                Console.WriteLine("wait for answer...");
            }
            catch
            {
                Console.WriteLine("Please, check the called number");
            }
            finally
            {
            }
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
            call.EndTimeSession = DateTime.Now;
            call.GetDuration();
            onVoteBilling(call);
            find_InPort(Sessions.ElementAt(numberSession)).Status = PortStatusValue.Free;
            find_OutPort(Sessions.ElementAt(numberSession)).Status = PortStatusValue.Free;
        }
        private Port find_OutPort(ISession session)
        {
            return Ports.Single(x => x.Number==session.SecondAbonent);
        }
        public void BlockingPort(TelephoneNumber number)
        {
            Ports.Single(x => x.Number==number).LockStatus = PortBlockedValue.Blocked;
        }
        public void UnblockingPort(TelephoneNumber number)
        {
            Ports.Single(x => x.Number==number).LockStatus = PortBlockedValue.Unblocked;
        }
        private Port find_InPort(ISession session)
        {
            return Ports.Single(x => x.Number == session.FirstAbonent);
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
