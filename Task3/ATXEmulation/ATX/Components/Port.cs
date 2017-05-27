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
        public string Abonent
        {
            get;
            set;
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
            call.Date = DateTime.Now;
            call.FirstAbonent = Number;
            Status = PortStatusValue.Busy;
            OnCalled(call);
        }
        public void IncomingCalledPort(TelephoneNumber number)
        {
            OnIncomingCalled(number);
        }
        public void TerminalDrop(object sender,EventArgs e)
        {
            Status = PortStatusValue.Free;            
            OnDropped();
        }
        public void TerminalAnswer(object sender,EventArgs e)
        {
            Status = PortStatusValue.Busy;
            OnAnswered();
        }
        public void TerminalConnect(object sender, EventArgs e)
        {
            if (Status == PortStatusValue.Busy)
                Console.WriteLine("Finish your operation and try later.");
            else
            {
                if (Status == PortStatusValue.Free)
                    Console.WriteLine("You're already connected");
                Status = PortStatusValue.Free;
                OnConnected();
            }

        }
        public void TerminalDisconnect(object sender, EventArgs e)
        {
            if (Status == PortStatusValue.Busy)
                Console.WriteLine("Finish your operation and try later.");
            else
            {
                if (Status == PortStatusValue.Disconnected)
                    Console.WriteLine("You're already disconnected");
                Status = PortStatusValue.Disconnected;
                OnDiscconnected();
            }
        }
#endregion
        #region Send to terminal
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
        //private void terminal_Connected(object sender, EventArgs e)
        //{
        //    ITerminal terminal=sender as ITerminal;
        //    if (terminal != null)
        //    {
        //        terminal.Called += OnCalled;
        //        terminal.Dropped += OnDropped;
        //        terminal.Answered += OnAnswered;
        //    }
        //}
        //private void terminal_Disconnected(object sender, EventArgs e)
        //{
        //    ITerminal terminal = sender as ITerminal;
        //    if (terminal != null)
        //    {
        //        terminal.Called -= OnCalled;
        //        terminal.Dropped -= OnDropped;
        //        terminal.Answered -= OnAnswered;
        //    }
        //}
#endregion
        #region Events

        private EventHandler <Call> _called;
        private EventHandler _dropped;
        private EventHandler _answered;
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
        public event EventHandler Dropped
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
        public event EventHandler Answered
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
        private void OnDropped()
        {
            if (_dropped != null)
                _dropped(this, null);
        }
        private void OnAnswered()
        {
            if (_answered != null)
                _answered(this, null);
        }
        private void OnConnected()
        {
            if (_connected != null)
                _connected(this, null);
        }
        private void OnDiscconnected()
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
