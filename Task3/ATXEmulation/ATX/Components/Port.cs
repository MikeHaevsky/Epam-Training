using ATXEmulation.ATX.Exchanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Components
{
    public class Port
    {
        public TelephoneNumber Number
        {
            get;
            set;
        }
        public PortStatusValue Status
        {
            get;
            set;
        }
        public PortBlockedValue LockStatus
        {
            get;
            set;
        }
        public string Abonent
        {
            get;
            set;
        }
        private int NumberActiveSession
        {
            get;
            set;
        }
        public void SetNumberActiveSession(int number)
        {
            NumberActiveSession = number;
        }
        public Port(TelephoneNumber number,string abonent)
        {
            this.Number = number;
            this.Abonent = abonent;
            //this.Status = status;
        }

        #region Send from terminal
        public void TerminalCall(object sender,Call call)
        {
            if (Status == PortStatusValue.Free)
            {
                switch (LockStatus)
                {
                    case PortBlockedValue.Blocked:
                        Console.WriteLine("You blocked!!!Need more gold!");
                        break;
                    default:
                        call.StartTimeSession = DateTime.Now;
                        call.FirstAbonent = Number;
                        Status = PortStatusValue.Busy;
                        OnCalled(call);
                        break;
                }
            }
            else
                Console.WriteLine("Please, connect or compleate your operation");
        }
        public void IncomingCalledPort(TelephoneNumber number)
        {
            OnIncomingCalled(number);
        }
        public void TerminalDrop(object sender, EventArgs e)
        {
            switch (Status)
            {
                case PortStatusValue.Disconnected:
                    Console.WriteLine("...");
                    break;
                case PortStatusValue.Free:
                    Console.WriteLine("...");
                    break;
                default:
                    Status = PortStatusValue.Free;
                    OnDropped(NumberActiveSession);
                    break;
            }
                //Console.WriteLine("You blocked. Need more gold!");
            //if (Status == PortStatusValue.Disconnected)
            //    Console.WriteLine("You blocked. Need more gold!");
            //Status = PortStatusValue.Free;            
            //OnDropped(NumberActiveSession);
        }
        public void TerminalAnswer(object sender,EventArgs e)
        {
            Status = PortStatusValue.Busy;
            OnAnswered(NumberActiveSession);
        }
        public void TerminalConnect(object sender, EventArgs e)
        {
            if (LockStatus == PortBlockedValue.Unblocked)
            {
                switch (Status)
                {
                    case PortStatusValue.Free:
                        Console.WriteLine("You're already connected");
                        break;
                    case PortStatusValue.Disconnected:
                        Console.WriteLine("Connected");
                        Status = PortStatusValue.Free;
                        OnConnected();
                        break;
                    default:
                        Console.WriteLine("Finish your operation and try later.");
                        break;
                }
            }
            else
                Console.WriteLine("Connection...You can accept only incoming calls.");
            //if (Status == PortStatusValue.Busy)
            //    Console.WriteLine("Finish your operation and try later.");
            //else
            //{
            //    if (Status == PortStatusValue.Free)
            //        Console.WriteLine("You're already connected");
            //    Status = PortStatusValue.Free;
            //    OnConnected();
            //}
        }
        public void TerminalDisconnect(object sender, EventArgs e)
        {
            switch (Status)
            {
                case PortStatusValue.Disconnected:
                    Console.WriteLine("You're already disconnected");
                    break;
                case PortStatusValue.Free:
                    Console.WriteLine("Disconnected");
                    Status = PortStatusValue.Free;
                    OnDisconnected();
                    break;
                default:
                    Console.WriteLine("Finish your operation and try later.");
                    break;
            }
            //if (Status == PortStatusValue.Busy)
            //    Console.WriteLine("Finish your operation and try later.");
            //else
            //{
            //    if (Status == PortStatusValue.Disconnected)
            //        Console.WriteLine("You're already disconnected");
            //    Status = PortStatusValue.Disconnected;
            //    OnDisconnected();
            //}
        }
        public void TerminalGetDetalization(object sender, EventArgs e)
        {
            //Port port=new Port(this.Number,this.Abonent);
            //Port port =sender as Port;
            OnDetalization();
        }
        public void TerminalSendFilter(object sender, FilterDetalization filter)
        {
            OnSetFilter(filter);
        }       
        #endregion
        public void SendToTerminalDetalization(object sender, string detalization)
        {
            OnSendDetalization(detalization);
        }
        public void RegistrateTerminal(ITerminal terminal)
        {
            terminal.Connected += TerminalConnect;
            terminal.Disconnected += TerminalDisconnect;
            terminal.Called += TerminalCall;
            terminal.Dropped += TerminalDrop;
            terminal.Answered += TerminalAnswer;
            terminal.GetCallDetalization += TerminalGetDetalization;
            terminal.SetFilter += TerminalSendFilter;

            IncomingCalled += terminal.IncomingCall;
            SendDetalization += terminal.ChooseDetlizationFilter;

        }
        public void AbortRegistrateTerminal(ITerminal terminal)
        {
            terminal.Connected -= TerminalConnect;
            terminal.Disconnected -= TerminalDisconnect;
            terminal.Called -= TerminalCall;
            terminal.Dropped -= TerminalDrop;
            terminal.Answered -= TerminalAnswer;
            terminal.SetFilter -= TerminalSendFilter;

            IncomingCalled -= terminal.IncomingCall;
            SendDetalization -= terminal.ChooseDetlizationFilter;
        }

        #region Events

        private EventHandler <Call> _called;
        private EventHandler <int> _dropped;
        private EventHandler <int> _answered;
        private EventHandler _connected;
        private EventHandler _disconnected;
        private EventHandler <TelephoneNumber> _incomingCalled;

        public event EventHandler <Call> Called
        {
            add
            {
                _called += value;
            }
            remove
            {
                _called -= value;
            }
        }
        public event EventHandler <int>Dropped
        {
            add
            {
                _dropped += value;
            }
            remove
            {
                _dropped -= value;
            }
        }
        public event EventHandler <int>Answered
        {
            add
            {
                _answered += value;
            }
            remove
            {
                _answered -= value;
            }
        }
        public event EventHandler Connected
        {
            add
            {
                _connected += value;
            }
            remove
            {
                _connected -= value;
            }
        }
        public event EventHandler Disconnected
        {
            add
            {
                _disconnected += value;
            }
            remove
            {
                _disconnected -= value;
            }
        }
        public event EventHandler<TelephoneNumber> IncomingCalled
        {
            add
            {
                _incomingCalled += value;
            }
            remove
            {
                _incomingCalled -= value;
            }
        }

        private void OnCalled(Call call)
        {
            if (_called != null)
                _called(this, call);
        }
        private void OnIncomingCalled(TelephoneNumber number)
        {
            if (_incomingCalled != null)
                _incomingCalled(this, number);
        }
        private void OnDropped(int numberActiveSession)
        {
            if (_dropped != null)
                _dropped(this, numberActiveSession);
        }
        private void OnAnswered(int numberActiveSession)
        {
            if (_answered != null)
                _answered(this, numberActiveSession);
        }
        private void OnConnected()
        {
            if (_connected != null)
                _connected(this, null);
        }
        private void OnDisconnected()
        {
            if (_disconnected != null)
                _disconnected(this, null);
        }
        
        private EventHandler _detalization;
        public event EventHandler Detalization
        {
            add
            {
                _detalization += value;
            }
            remove
            {
                _detalization -= value;
            }
        }
        private void OnDetalization()
        {
            if (_detalization != null)
                _detalization(this, null);
        }
        private EventHandler<FilterDetalization> _filterDetalization;
        public event EventHandler<FilterDetalization> FilterDetalization
        {
            add 
            {
                _filterDetalization += value;
            }
            remove
            {
                _filterDetalization -= value;
            }
        }
        private void OnDetalization(FilterDetalization filter)
        {
            if (_detalization != null)
                _detalization(this, filter);
        }

        private EventHandler<string> _sendDetalization;
        public event EventHandler<string> SendDetalization
        {
            add
            {
                _sendDetalization += value;
            }
            remove
            {
                _sendDetalization -= value;
            }
        }
        private void OnSendDetalization(string detalization)
        {
            if (_sendDetalization != null)
                _sendDetalization(this, detalization);
        }

        private EventHandler<FilterDetalization> _setFilter;
        public event EventHandler<FilterDetalization> SetFilter
        {
            add
            {
                _setFilter += value;
            }
            remove
            {
                _setFilter -= value;
            }
        }
        private void OnSetFilter(FilterDetalization filter)
        {
            if (_setFilter != null)
                _setFilter(this, filter);
        }

        #endregion
        public void Clean()
        {
            //_setFilter = null;
            //_sendDetalization = null;
        }
        public void Dispose()
        {
            _answered=null;
            _called = null;
            _connected = null;
            _disconnected = null;
            _dropped = null;
            _incomingCalled = null;
            //_detalization = null;
            //_sendDetalization = null;
            //_setFilter = null;
        }
    }
}
