﻿using System;
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
            AbonentConnect(0);
            AbonentConnect(1);
            AbonentConnect(2);
            AbonentConnect(3);
            TelephoneNumber number = new TelephoneNumber(375, 7868348);
            number.AbonentCall(0);
            AbonentDrop(0);
            number = new TelephoneNumber(375, 8833548);
            number.AbonentCall(1);
            AbonentDrop(1);
            AbonentDisconnect(0);
            AbonentDisconnect(1);
            AbonentDisconnect(2);
            AbonentDisconnect(3);
        }
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
            station.Ports = new List<Port>()
            {
                new Port(new TelephoneNumber(375, 8680737), "Mike"),
                new Port(new TelephoneNumber(375, 5860786), "Vadim"),
                new Port(new TelephoneNumber(375, 7868348), "Valery"),
                new Port(new TelephoneNumber(375, 8833548), "Eugeny")
            };
            station.Terminals = new List<ITerminal>()
            {
                new Terminal(0),
                new Terminal(1),
                new Terminal(2),
                new Terminal(3)
            };
            Station = station;
        }
        public static void AbonentConnect(int id)
        {
            Station.Connect(Station.Ports.ElementAt(id));
            Station.Ports.ElementAt(id).RegistrateTerminal(Station.Terminals.ElementAt(id));
            Station.Terminals.ElementAt(id).Connecting();
        }
        public static void AbonentDisconnect(int id)
        {
            Station.Terminals.ElementAt(id).EndingCall();
        }
        public static void AbonentCall(int id, TelephoneNumber number)
        {
            Station.Terminals.ElementAt(id).BeginCall(number);
        }
        public static void AbonentDrop(int id)
        {
            Station.Terminals.ElementAt(id).EndingCall();
        }
        public static void AbonentCall(this TelephoneNumber number, int id)
        {
            Station.Terminals.ElementAt(id).BeginCall(number);
        }
        public static void ReturnCall(object sender, Call call)
        {
            Station.CallSessions.Add(call);
        }
        public static void BlockAbonent(object sender, EventArgs e)
        {
            //Station.Ports
        }
        public static void UnblockAbonent(object sender, EventArgs e)
        {
            //Station.Ports
        }
        #endregion

        #region Billing methods
        public static void BillingConnect(Billing billing)
        {
            billing.VoteDemo += ReturnCall;
            billing.BlockedClient += BlockAbonent;
            billing.UnblockClient += UnblockAbonent;
        }
        public static void BillingDisconnect(Billing billing)
        {
            billing.VoteDemo -= ReturnCall;
            billing.BlockedClient -= BlockAbonent;
            billing.UnblockClient -= UnblockAbonent;
        }

        #endregion
        private static void ShowEvent(EventHandler asd, EventArgs e)
        {
            Console.WriteLine("{0}", asd);
        }
        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        
        #region Methods Billing


        //public void ConnectBillingSystem(System billingSystem)
        //{
            
        //}
        //public void DisconnectVilingSystem()
        //{

        //}

        #endregion

        #region Events

        //private EventHandler<Call> _modifyCall;
        //public event EventHandler<Call> ModifyCall
        //{
        //    add
        //    {
        //        _modifyCall += value;
        //    }
        //    remove
        //    {
        //        _modifyCall -= value;
        //    }
        //}

        #endregion
        //public static void AbonentCall(this TelephoneNumber number, int id)
        //{
        //    ATXProgram.AbonentCall(id, number);
        //}
        //public static ATXEmulation.ATX.ATXStation station { get; set; }
    }
}
