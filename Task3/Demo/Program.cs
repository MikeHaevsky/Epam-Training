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
using System.Timers;

namespace Demo
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Timer timer = new Timer(86400000);
            //timer.AutoReset = true;
            //timer.Elapsed+=BillSystem.TimerAction;
            TelephoneNumber Number1 = new TelephoneNumber(375, 8680737);
            TelephoneNumber Number2 = new TelephoneNumber(375, 7868348);
            TelephoneNumber Number3 = new TelephoneNumber(375, 5554433);
            TelephoneNumber Number4 = new TelephoneNumber(375, 5860786);
            TelephoneNumber Number5 = new TelephoneNumber(375, 8833548);
            RunATXStation();
            RunBillingSystem();
            BillSystem.BillingConnect();
            BillSystem.AddTarifs();
            Number1.AddSubject("Mike", 0);
            Number2.AddSubject("Valary", 0);
            Number3.AddSubject("Sergei", 0);
            Number4.AddSubject("Pontuth", 0);
            Number5.AddSubject("Eugenij", 0);
            Client1.AbonentConnect();
            Client2.AbonentConnect();
            Client3.AbonentConnect();
            Client4.AbonentConnect();
            Client5.AbonentConnect();
            Client1.AbonentCall(Number2);
            //Client1.AbonentCall(Number3);
            System.Threading.Thread.Sleep(10000);
            Client2.AbonentDrop();
            Client1.AbonentCall(Number3);
            System.Threading.Thread.Sleep(1000);
            Client1.AbonentDrop();
            Client1.AbonentCall(Number4);
            System.Threading.Thread.Sleep(15000);
            Client1.AbonentDrop();
            Client1.AbonentCall(Number5);
            System.Threading.Thread.Sleep(8000);
            Client1.AbonentDrop();
            Client1.AbonentDetalization();
        }

        

        #region For Demonstration

        private static int Client1 = 0;
        private static int Client2 = 1;
        private static int Client3 = 2;
        private static int Client4 = 3;
        private static int Client5 = 4;
        private static int countPort = 0;
        private static int countClient=0;

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
        public static void AbonentDisconnect(this int id)
        {
            Station.Terminals.ElementAt(id).EndingCall();
        }
        public static void AbonentDetalization(this int id)
        {
            Station.Terminals.ElementAt(id).GetDetalization();
        }
        public static void AbonentDrop(this int id)
        {
            Station.Terminals.ElementAt(id).EndingCall();
        }
        public static void AbonentCall(this int id, TelephoneNumber number)
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
                Terminal terminal=new Terminal(countPort);
                Station.Ports.Add(port);
                Station.Terminals.Add(terminal);
                countPort++;
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
            billingSystem.Tarifs = new List<ITarif>();
            BillSystem = billingSystem;
        }
        public static int AddSubject(this TelephoneNumber number, string name,int tarifId)
        {
            User user = new User(name, number,tarifId);
            BillSystem.AddClient(user);
            countClient++;
            return countClient;
        }
        public static void AddTarifs(this Billing billingSystem)
        {
            Tarif1 tarif1=new Tarif1();
            Tarif2 tarif2 = new Tarif2();
            billingSystem.Tarifs.Add(tarif1);
            billingSystem.Tarifs.Add(tarif2);
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
            BillSystem.ConnectToStation(Station);
        }
        public static void BillingDisconnect(Billing billing)
        {
            billing.VoteDemo -= ReturnCallSession;
            billing.BlockedClient -= BlockAbonent;
            billing.UnblockClient -= UnblockAbonent;
            billing.AddUser -= AddPortStation;
            billing.RemoveUser -= RemovePortStation;
            BillSystem.DisconnectFromStation(Station);
        }

        #endregion
    }
}
