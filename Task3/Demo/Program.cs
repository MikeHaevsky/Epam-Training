using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATXEmulation.ATX;
using ATXEmulation.ATX.Exchanges;
using ATXEmulation.ATX.Components;
using BillingSystem;
using BillingSystem.Components;

namespace Demo
{
    static class Program
    {
        static void Main(string[] args)
        {
            RunATXStation();
            RunBillingSystem();
            BillSystem.BillingConnect();
            //AddMike();
            Number1().AddSubject("Mike", 1).AbonentConnect();
            Number2().AddSubject("Valary", 1).AbonentConnect();
            Number3().AddSubject("Puntuth", 1).AbonentConnect();
            Number4().AddSubject("Eugenij", 1).AbonentConnect();
            //AbonentConnect(0);
            //AbonentConnect(1);
            //AbonentConnect(2);
            //AbonentConnect(3);
            //TelephoneNumber number = new TelephoneNumber(375, 7868348);
            //number.AbonentCall(0);
            //AbonentDrop(0);
            //number = new TelephoneNumber(375, 8833548);
            //number.AbonentCall(1);
            //AbonentDrop(1);
            //AbonentDisconnect(0);
            //AbonentDisconnect(1);
            //AbonentDisconnect(2);
            //AbonentDisconnect(3);
        }

        #region For Demonstration

        private static int  Client1=0;
        private static int Client2=1;
        private static int Client3=2;
        private static int Client4=3;
        private static int countClient;

        public static TelephoneNumber Number1()
        {
            return new TelephoneNumber(375, 8680737);
        }
        public static TelephoneNumber Number2()
        {
            return new TelephoneNumber(375, 7653457);
        }
        public static TelephoneNumber Number3()
        {
            return new TelephoneNumber(375, 5860786);
        }
        public static TelephoneNumber Number4()
        {
            return new TelephoneNumber(375, 8833548);
        }
        #endregion

        public static ATXStation Station
        {
            get;
            set;
        }
        public static Billing BillSystem
        {
            get;
            set;
        }
        #region Station methods
        public static void RunATXStation()
        {
            ATXStation station = new ATXStation();
            station.Ports = new List<Port>();
            station.Terminals = new List<ITerminal>();
            station.Sessions = new List<ISession>();
            station.CallSessions = new List<Call>();
            //station.Ports = new List<Port>()
            //{
            //    new Port(new TelephoneNumber(375, 8680737), "Mike"),
            //    new Port(new TelephoneNumber(375, 5860786), "Vadim"),
            //    new Port(new TelephoneNumber(375, 7868348), "Valery"),
            //    new Port(new TelephoneNumber(375, 8833548), "Eugeny")
            //};
            //station.Terminals = new List<ITerminal>()
            //{
            //    new Terminal(0),
            //    new Terminal(1),
            //    new Terminal(2),
            //    new Terminal(3)
            //};
            Station = station;
        }
        
        public static void AbonentConnect(this int id)
        {
            Station.Connect(Station.Ports.ElementAt(id));
            Station.Ports.ElementAt(id).RegistrateTerminal(Station.Terminals.ElementAt(id));
            Station.Terminals.ElementAt(id).Connecting();
        }
        public static void AbonentDisconnect(int id)
        {
            Station.Terminals.ElementAt(id).EndingCall();
        }
        //public static void AbonentCall(int id, TelephoneNumber number)
        //{
        //    Station.Terminals.ElementAt(id).BeginCall(number);
        //}
        public static void AbonentDrop(int id)
        {
            Station.Terminals.ElementAt(id).EndingCall();
        }
        public static void AbonentCall(this TelephoneNumber number, int id)
        {
            Station.Terminals.ElementAt(id).BeginCall(number);
        }
        public static void ReturnCallSession(object sender, Call call)
        {
            Station.CallSessions.Add(call);
        }
        public static void BlockAbonent(object sender, TelephoneNumber number)
        {
            Station.BlockingPort(number);
        }
        public static void UnblockAbonent(object sender, TelephoneNumber number)
        {
            Station.UnblockingPort(number);
        }
        public static void AddPortStation(object sender, User user)
        {
            if (user.Number.IsOnStation() == false)
            {
                Port port = new Port(user.Number, user.Name);
                Terminal terminal=new Terminal(0);
                Station.Ports.Add(port);
                Station.Terminals.Add(terminal);
            }
            else
            {
                Console.WriteLine("Please insert another number for registration.");
            }
            
        }
        public static void RemovePortStation(object sender, User user)
        {
            if(user.Number.IsOnStation()==true)
            {
                Port port=new Port(user.Number,user.Name);
                Station.Ports.Remove(Station.Ports.Single(item=>item.Number==user.Number));
            }
        }
        private static bool IsOnStation(this TelephoneNumber number)
        {
            try
            {
                Station.Ports.Single(item => item.Number == number);
                //Console.WriteLine("This number exists on station");
                return true;
            }
            catch
            {
                //Console.WriteLine("This number not exists on station");
                return false;
            }
        }
        #endregion

        #region Billing methods

        public static void RunBillingSystem()
        {
            Billing billingSystem = new Billing();
            //billingSystem.Users = new List<User>()
            //{
                
            //    new User("Mike",new TelephoneNumber(375,8680737),1),
            //    new User("Valery",new TelephoneNumber(375,7868348),1),
            //    new User("Vadim",new TelephoneNumber(375,5860786),1),
            //    new User("Eugenij",new TelephoneNumber(375,8833548),1)
            //};
            BillSystem = billingSystem;
        }
        public static int AddSubject(this TelephoneNumber number, string name,int tarifId)
        {
            User user = new User(name, number,tarifId);
            BillSystem.AddClient(user);
            countClient = countClient++;
            return countClient;
        }

        #endregion

        #region Billing events
        public static void BillingConnect(this Billing billing)
        {
            billing.VoteDemo += ReturnCallSession;
            billing.BlockedClient += BlockAbonent;
            billing.UnblockClient += UnblockAbonent;
            billing.AddUser += AddPortStation;
            billing.RemoveUser += RemovePortStation;
        }
        public static void BillingDisconnect(Billing billing)
        {
            billing.VoteDemo -= ReturnCallSession;
            billing.BlockedClient -= BlockAbonent;
            billing.UnblockClient -= UnblockAbonent;
            billing.AddUser -= AddPortStation;
            billing.RemoveUser -= RemovePortStation;
        }

        #endregion
    }
}
