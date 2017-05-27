using ATXEmulation.ATX.Events;
using ATXEmulation.ATX.Exchanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXEmulation.ATX.Components
{
    public class Terminal:ITerminal
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public Terminal(int i)
        {
            _id = i;
        }
        #region Methods
        public void BeginCall(TelephoneNumber number)
        {
            Call call = new Call();
            call.SecondAbonent = number;
            OnCalled(call);
        }

        public void EndingCall()
        {
            OnDropped();
        }
        public void IncomingCall()
        {
            Console.WriteLine("asdasd");
        }
        public void AnsweringCall()
        {
            OnAnswered();
        }


        public void Connecting()
        {
            OnConnected();
        }

        public void Disconnecting()
        {
            OnDisconnected();
        }
        #endregion
        #region Events
        
        private EventHandler <Call> _called;
        private EventHandler _dropped;
        private EventHandler _answered;
        private EventHandler _connected;
        private EventHandler _disconnected;

        public event EventHandler<Call> Called
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

        private void OnCalled(Call call)
        {
            if (_called != null)
                _called(this, call);
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
        private void OnDisconnected()
        {
            if (_disconnected != null)
                _disconnected(this, null);
        }
        #endregion
        public void Dispose()
        {
            _called = null;
            _dropped = null;
            _disconnected = null;
            _connected = null;
            _answered = null;
        }
    }
}
