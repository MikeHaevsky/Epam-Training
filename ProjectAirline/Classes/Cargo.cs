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

        public override Serialize.CreatorAirplane GetCreator()
        {
            return new CreatorCargo(Id,Model,Producer,Crew,FuelCapacity,TotalLoad,FuelConsumption);
        }
    }
}
