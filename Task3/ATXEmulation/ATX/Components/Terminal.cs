using ATXEmulation.ATX;
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
        public int Id
        {
            get;
            set;
        }
        public Terminal(int i)
        {
            Id = i;
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
        public void GetDetalization()
        {
            OnGetDetalization();
        }
        public void ChooseDetlizationFilter(object sender, string detalization)
        {
            Console.WriteLine(detalization);
            Console.WriteLine("\nIf  you want to filtered this information, press:\n" +
                "1. over the date\n"+
                "2. over the abonent\n"+
                "3. over the duration\n"+
                "press other key to exit...");
            ConsoleKeyInfo key=Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Write start date (in format: MM/DD/YYYY hh:mm:ss.ms;where ms ##):");
                    string startDate=Console.ReadLine();
                    Console.WriteLine("Write end date (in format: MM/DD/YYYY hh:mm:ss.ms;where ms ##):");
                    string endDate=Console.ReadLine();
                    string s1 = string.Concat(startDate + "|" + endDate);
                    FilterDetalization filter1 = new FilterDetalization(FilterTypes.CurrentDate,s1);
                    OnSetFilter(filter1);
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Write abonent code(in format: ###):");
                    string code=Console.ReadLine();
                    Console.WriteLine("Write abonent number(in format: #######):");
                    string number = Console.ReadLine();
                    string s2 = string.Concat(code + "|" + number);
                    FilterDetalization filter2 = new FilterDetalization(FilterTypes.OverAbonentNumber,s2);
                    OnSetFilter(filter2);
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Write lover duration(in format: hh:mm:ss.ms):");
                    string LoverDuration=Console.ReadLine();
                    Console.WriteLine("Write upper duration(in format: hh:mm:ss.ms):");
                    string upperDuration=Console.ReadLine();
                    string s3 = string.Concat(LoverDuration + "|" + upperDuration);
                    FilterDetalization filter3 = new FilterDetalization(FilterTypes.Duration,s3);
                    OnSetFilter(filter3);
                    break;
                default:
                    break;
            }

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
        private EventHandler _getCallDetalization;
        public event EventHandler GetCallDetalization
        {
            add
            {
                _getCallDetalization += value;
            }
            remove
            {
                _getCallDetalization -= value;
            }
        }
        private void OnGetDetalization()
        {
            if (_getCallDetalization != null)
                _getCallDetalization(this, null);
        }

        private EventHandler<FilterDetalization> _setFilter;
        public event EventHandler<FilterDetalization> SetFilter
        {
            add
            {
                _setFilter = value;
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
