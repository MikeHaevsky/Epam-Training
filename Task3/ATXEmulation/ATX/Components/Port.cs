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
                Console.WriteLine("You blocked. Need more gold!");
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
        
        #endregion

        public void RegistrateTerminal(ITerminal terminal)
        {
            terminal.Connected += TerminalConnect;
            terminal.Disconnected += TerminalDisconnect;
            terminal.Called += TerminalCall;
            terminal.Dropped += TerminalDrop;
            terminal.Answered += TerminalAnswer;
            IncomingCalled += terminal.IncomingCall;
        }
        public void AbortRegistrateTerminal(ITerminal terminal)
        {
            terminal.Connected -= TerminalConnect;
            terminal.Disconnected -= TerminalDisconnect;
            terminal.Called -= TerminalCall;
            terminal.Dropped -= TerminalDrop;
            terminal.Answered -= TerminalAnswer;
            IncomingCalled += terminal.IncomingCall;
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
        #endregion
        public void Dispose()
        {
            _answered=null;
            _called = null;
            _connected = null;
            _disconnected = null;
            _dropped = null;
            _incomingCalled = null;
        }
    }
}
