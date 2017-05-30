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
        private Port detalizationPort;
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
        
        #region For Detalization

        public void GetDetalization(object sender, EventArgs e)
        {
            //port.Clean();
            Port port = sender as Port;
            this.ChooseFilter += port.SendToTerminalDetalization;
            port.SetFilter += this.GetDetalization;
            detalizationPort = port;
            string details = ShowDetalization(GetCallHistory(port));
            OnChooseFilter(details);
            this.ChooseFilter -= port.SendToTerminalDetalization;
            port.SetFilter -= this.Filtered;
        }
        public void GetDetalization(object sender, FilterDetalization filter)
        {
            switch (filter.Type)
            {
                case FilterTypes.CurrentDate:
                    string[] a = filter.Value.Split('|');
                    DateTime startDate = Convert.ToDateTime(a[0]);
                    DateTime endDate = Convert.ToDateTime(a[1]);
                    string details = ShowDetalization(FilteredOverTheCurrentDate(GetCallHistory(detalizationPort), startDate,endDate));
                    OnChooseFilter(details);
                    break;
                case FilterTypes.Duration:
                    TimeSpan duration;
                    //TimeSpan time;
                    try
                    {
                        TimeSpan.TryParse(filter.Value, out duration);
                        string[] b = filter.Value.Split('|');
                        //DateTime fTime = Convert.ToDateTime(a[0]);
                        //DateTime sTime = Convert.ToDateTime(a[1]);
                        TimeSpan fTime,sTime;
                        TimeSpan.TryParse(b[0], out fTime);
                        TimeSpan.TryParse(b[1], out sTime);
                        string details1 = ShowDetalization(FilteredOverTheDuration(GetCallHistory(detalizationPort), fTime,sTime));
                        OnChooseFilter(details1);
                    }
                    catch
                    {
                        string details2="incorrect format";
                        OnChooseFilter(details2);
                    };
                    break;
                default:
                    string[] c= filter.Value.Split('|');
                    int number,i;
                    int.TryParse(c[0],out i);
                    int.TryParse(c[1],out number);
                    short code=Convert.ToInt16(i);
                    TelephoneNumber telNumber = new TelephoneNumber(code, number);
                    string details3 = ShowDetalization(FilteredOverTheAbonent(GetCallHistory(detalizationPort), telNumber));
                    OnChooseFilter(details3);
                    break;
            }
        }
        public void Filtered(object sender, FilterDetalization filter)
        {
            //FilteredOverTheCurrentDate
        }
        public IEnumerable<Call> FilteredOverTheCurrentDate(IEnumerable<Call> sessions, DateTime date1, DateTime date2)
        {
            return sessions.Where(item => (item.StartTimeSession > date1) && (item.StartTimeSession < date2));
            //return _airplanes.Where(item => (item.FuelConsumption > x) & (item.FuelConsumption < y)).Select(item => string.Format("{1}{0} | FuelConsumption:{2} \n", item.Model, item.Producer, item.FuelConsumption));
        }
        public IEnumerable<Call> FilteredOverTheAbonent(IEnumerable<Call> sessions, TelephoneNumber abonent)
        {
            return sessions.Where(item => item.SecondAbonent == abonent);
        }
        public IEnumerable<Call> FilteredOverTheDuration(IEnumerable<Call> sessions, TimeSpan fTime, TimeSpan sTime)
        {
            return sessions.Where(item => (item.Duration > fTime)&&(item.Duration<sTime));
        }
        public IEnumerable<Call> GetCallHistory(Port port)
        {
            return CallSessions.Where(item => item.FirstAbonent == port.Number);
        }
        public string ShowDetalization(IEnumerable<Call> calls)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Your call history\r\n");
            foreach (Call call in calls)
            {
                sb.Append(string.Format("Call to:{0} | Start:{1}| End: {2}| Duration: {3}| Cost: {4}\r\n",
                    call.SecondAbonent, call.StartTimeSession, call.EndTimeSession,call.Duration,call.Coast)); 
            }
            return sb.ToString();
        }

        #endregion

        public void FilteredHistiryOverTheDuration(ICollection<Call> sessions, TimeSpan duration1, TimeSpan duration2)
        {
            sessions.Where(item=>(item.Duration>duration1)&&(item.Duration<duration2));
        }
        
        public void GetCallHistory(TelephoneNumber number)
        {
            Sessions.Where(item => item.FirstAbonent==number);
        }
        public void ConnectToStation(object sender, EventArgs e)
        {
            Port port = sender as Port;
            if (port != null)
            {
                port.Called+=port_Called;
                port.Answered+=port_Answered;
                port.Dropped+=port_Dropped;
                port.Detalization += GetDetalization;
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
                port.Detalization -= GetDetalization;
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

        #region Events for port

        private EventHandler <string> _chooseFilter;
        public event EventHandler<string> ChooseFilter
        {
            add
            {
                _chooseFilter += value;
            }
            remove
            {
                _chooseFilter -= value;
            }
        }
        private void OnChooseFilter(string detalization)
        {
            if (_chooseFilter != null)
                _chooseFilter(this, detalization);
        }

        
        #endregion

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

        //private EventHandler
        //public 
        #endregion
        }
}
