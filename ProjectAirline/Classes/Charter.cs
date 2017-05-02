using ProjectAirline.Interfaces;
using ProjectAirline.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Classes
{
    class Charter: Airplane, IPassenger
    {
        private int _steardess;
        private int _classes;
        public Charter(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumption, int stewardess, int classes)
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
        public override int GetCapacity()
        {
            return (((TotalLoad - FuelConsumption) / intAverageHumanWeight) / 100) * 90 - Crew;
        }
        public override string GetInfo()
        {
            return string.Format("{0}{1}\nCrew:{2}\n"+
                "Fuel capacity:{3}\n"+
                "Total load:{4}\n"+
                "Fuel consumption:{5}\n"+
                "Capacity:{6}\n"+
                "Range:{7}\n"+
                "Stewardess:{8}\n"+
                "Classes:{9}", 
                Producer, Model, Crew, FuelCapacity, TotalLoad, FuelConsumption, GetCapacity(), GetRage(), Stewardess, Classes);
        }
        public override Serialize.CreatorAirplane GetCreator()
        {
            return new CreatorCharter(Id, Model, Producer, Crew, FuelCapacity, TotalLoad, FuelConsumption, Stewardess, Classes);
        }
    }
}