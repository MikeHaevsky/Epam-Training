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
            Console.WriteLine("Terminal №{0} abort call", Id);
            OnDropped();
        }
        public void IncomingCall(object sender,TelephoneNumber number)
        {
            Console.WriteLine("This is terminal№{0}", Id);
                Console.WriteLine("Incoming call from +{0} {1} \nAnswer or Drop", number.Code, number.Number);
                ConsoleKeyInfo key=Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter :
                        AnsweringCall();
                        break;
                    case ConsoleKey.Escape:
                        EndingCall();
                        break;
                    default:
                        break;
                }
        }
        private void AnsweringCall()
        {
            Console.WriteLine("{0} call.......",Id);
            OnAnswered();
        }
        public void Connecting()
        {
            Console.WriteLine("Terminal {0} has connected",Id);
            OnConnected();
        }
        public void Disconnecting()
        {
            Console.WriteLine("Terminal {0} has disconnected", Id);
            OnDisconnected();
        }
        #endregion
        #region Events
        
        private EventHandler <Call> _called;
        private EventHandler _dropped;
        private EventHandler _answered;
        private EventHandler _connected;
        private EventHandler _disconnected;
        //private EventHandler <TelephoneNumber> _incomingCalled;

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
        //public event EventHandler<TelephoneNumber> IncomingCalled
        //{
        //    add
        //    {
        //        _incomingCalled += value;
        //    }
        //    remove
        //    {
        //        _incomingCalled -= value;
        //    }
        //}
        private void OnCalled(Call call)
        {
            if (_called != null)
                _called(this, call);
        }
        //private void OnIncCalled(TelephoneNumber number)
        //{
        //    if (_incomingCalled != null)
        //        _incomingCalled(this, number);
        //}
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
            //_incomingCalled = null;
        }
    }
}
