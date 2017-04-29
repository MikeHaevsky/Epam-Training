using ProjectAirline.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Serialize
{
    class CreatorCargo: Creator
    {
        public CreatorCargo(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumption)
            :base (id, model, producer, crew, fuelCapacity, totalLoad, fuelConsumption)
        { }

        public override Interfaces.IAirplane GetAirplane()
        {
            return new Cargo(_id, _model, _producer, _crew, _fuelCapacity, _totalLoad, _fuelConsumption);
        }
    }
}
