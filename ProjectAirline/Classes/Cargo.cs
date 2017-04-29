using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Classes
{
    class Cargo: Airplane
    {
        public Cargo(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumprion)
            :base (id, model, producer, crew, fuelCapacity, totalLoad, fuelConsumprion)
        {
            _fuelCapacity = fuelCapacity;
            _totalLoad = totalLoad;
            _fuelConsumption = fuelConsumprion;
        }
        public override int GetCapacity()
        {
            int gc = ((_totalLoad - _fuelConsumption)-_crew)/65;
            return gc;

        }
        public override string GetInfo()
        {
            return string.Format("{0}{1}\nCrew:{2}\nFuel capacity:{3}\nTotal load:{4}\nFuel consumption:{5}\nCapacity:{6}\nRange:{7}", Producer, Model, Crew, FuelCapacity, TotalLoad, FuelConsumption, GetCapacity(), GetRage());
        }
    }
}
