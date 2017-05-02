using ProjectAirline.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Classes
{
    class Cargo: Airplane
    {
        public Cargo(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumption)
            :base (id, model, producer, crew, fuelCapacity, totalLoad, fuelConsumption)
        { }
        public override int GetCapacity()
        {
            return ((TotalLoad - FuelConsumption) - Crew) / intAverageHumanWeight;
        }
        public override string GetInfo()
        {
            return string.Format("{0}{1}\nCrew:{2}\n"+
                "Fuel capacity:{3}\n"+
                "Total load:{4}\n"+
                "Fuel consumption:{5}\n"+
                "Capacity:{6}\n"+
                "Range:{7}",
                Producer, Model, Crew, FuelCapacity, TotalLoad, FuelConsumption, GetCapacity(), GetRage());
        }
        public override Serialize.CreatorAirplane GetCreator()
        {
            return new CreatorCargo(Id,Model,Producer,Crew,FuelCapacity,TotalLoad,FuelConsumption);
        }
    }
}
