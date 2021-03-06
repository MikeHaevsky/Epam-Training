﻿using ATXEmulation.ATX;
using ATXEmulation.ATX.Components;
using ATXEmulation.ATX.Exchanges;
using BillingSystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BillingSystem
{
    public class Billing
    {
        public ICollection<ITarif> Tarifs
        {
            get;
            set;
        }
        public ICollection<User> Users
        {
            get;
            set;
        }
        public Billing()
        {
            Users = new List<User>();
        }
        public void SwitchTarif(TelephoneNumber number)
        {
            DateTime judgmentDay = FindUser(number).RegistrationDate.AddMonths(1);
            if (FindUser(number).RegistrationDate > judgmentDay)
            {
                String.Join("\n",Tarifs.Select(item=>item.Tittle));
                int i = Tarifs.Count;
                Console.WriteLine("Choose number your new Tarif1");
                int j = Convert.ToInt32(Console.ReadLine());
                if (i >= j)
                    FindUser(number).TarifId = j;
                else
                    Console.WriteLine("Write correct tarif number");
            }
            else
            {
                Console.WriteLine("This operathion is blocked now. You can switch tarif after a month.");
            }
        }
        public void AddClient(User user)
        {
            Users.Add(user);
            OnAddUser(user);
        }
        public void RemoveClient(User user)
        {
            Users.Remove(user);
            OnRemoveUser(user);
        }
        public void PutMoney(TelephoneNumber number,double money)
        {
            Users.Single(x => x.Number == number).Money+=money;
        }
        public void DebitBalans(TelephoneNumber number)
        {
            FindUser(number).DebitMoney();
            if (FindUser(number).Money<0)
                OnBlockedClient(number);
            else
                OnUnblockClient(number);
        }
        public void TimerAction(object sender, EventArgs e)
        {           
            foreach (User item in Users)
            {
                if (item.IsUserNeedLock() == true)
                    OnBlockedClient(item.Number);
            }
        }
        public void GetCoastCall(object sender, Call call)
        {
            double coast;
            int tarif = FindUser(call).TarifId;
            double s = FindUser(call).Money;
            int seconds = call.Duration.Seconds;
            coast = Tarifs.ElementAt(tarif).GetCoastSession(seconds);
            s = +coast;
            call.Coast = coast;
            OnVoteDemo(call);
        }
        public User FindUser(Call call)
        {
            return Users.Single(x => x.Number==call.FirstAbonent);
        }
        public User FindUser(TelephoneNumber number)
        {
            return Users.Single(x => x.Number == number);
        }
        private EventHandler<Call> _voteDemo;
        public event EventHandler<Call> VoteDemo
        {
            add
            {
                _voteDemo += value;
            }
            remove
            {
                _voteDemo -= value;
            }
        }
        private void OnVoteDemo(Call call)
        {
            if (_voteDemo != null)
                _voteDemo(this, call);
        }
        public void ConnectToStation(ATXStation station)
        {
            station.VoteBilling += GetCoastCall;
        }
        public void DisconnectFromStation(ATXStation station)
        {
            station.VoteBilling -= GetCoastCall;
        }

        #region Events

        #region BlockedClient

        private EventHandler<TelephoneNumber> _blokedClient;
        public event EventHandler<TelephoneNumber> BlockedClient
        {
            add
            {
                _blokedClient += value;
            }
            remove
            {
                _blokedClient -= value;
            }
        }
        public void OnBlockedClient(TelephoneNumber number)
        {
            if (_blokedClient != null)
                _blokedClient(this, number);
        }

        #endregion

        #region UnblockedClient

        private EventHandler <TelephoneNumber> _unblockedClient;
        public event EventHandler<TelephoneNumber> UnblockClient
        {
            add
            {
                _unblockedClient += value;
            }
            remove
            {
                _unblockedClient -= value;
            }
        }
        public void OnUnblockClient(TelephoneNumber number)
        {
            if (_unblockedClient != null)
                _unblockedClient(this, number);
        }

        #endregion

        #region AddUser

        private EventHandler<User> _addUser;
        public event EventHandler<User> AddUser
        {
            add
            {
                _addUser += value;
            }
            remove
            {
                _addUser -= value;
            }
        }
        private void OnAddUser(User user)
        {
            if (_addUser != null)
                _addUser(this, user);
        }

        #endregion

        #region RemoveUser

        private EventHandler<User> _removeUser;
        public event EventHandler<User> RemoveUser
        {
            add
            {
                _removeUser += value;
            }
            remove
            {
                _removeUser -= value;
            }
        }
        private void OnRemoveUser(User user)
        {
            if (_removeUser != null)
                _removeUser(this, user);
        }

        #endregion

        #endregion
    }
}
