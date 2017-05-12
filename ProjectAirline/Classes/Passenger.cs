using ProjectAirline.Interfaces;
using ProjectAirline.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Classes
{
    class Passenger: Airplane, IPassenger
    {
        private int _steardess;
        private int _classes;
        public Passenger(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumption, int stewardess, int classes)
            : base(id, model, producer, crew, fuelCapacity, totalLoad, fuelConsumption)
        {
            _steardess = stewardess;
            _classes = classes;
        }
        public int Stewardess
        {
            get
            {
                return _steardess;
            }
        }

        public int Classes
        {
            get
            {
                return _classes;
            }
        }
        public override string GetInfo()
        {
            return string.Format("{0}\n" +
                "Stewardess:{8}\n"+
                "Classes:{9}",
                base.GetInfo(), Stewardess, Classes); ;
        }
        public override Serialize.CreatorAirplane GetCreator()
        {
            return new CreatorPassenger(Id, Model, Producer, Crew, FuelCapacity, TotalLoad, FuelConsumption, Stewardess, Classes);
        }
    }
}
