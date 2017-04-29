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
        public Passenger(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumprion, int stewardess, int classes)
            : base(id, model, producer, crew, fuelCapacity, totalLoad, fuelConsumprion)
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
            set
            {
                _steardess = value;
            }
        }

        public int Classes
        {
            get
            {
                return _classes;
            }
            set
            {
                _classes = value;
            }
        }
        public override string GetInfo()
        {
            return string.Format("{0}{1}\nCrew:{2}\nFuel capacity:{3}\nTotal load:{4}\nFuel consumption:{5}\nCapacity:{6}\nRange:{7}\nStewardess:{8}\nClasses:{9}", Producer, Model, Crew, FuelCapacity, TotalLoad, FuelConsumption, GetCapacity(), GetRage(), Stewardess, Classes); ;
        }
        public override Serialize.Creator GetCreator()
        {
            return new CreatorPassenger(Id, Model, Producer, Crew, FuelCapacity, TotalLoad, FuelCapacity, Stewardess, Classes);
        }
    }
}
