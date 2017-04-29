using ProjectAirline.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Serialize
{
    class CreatorPassenger: Creator
    {
        private int _steardess;
        private int _classes;
        public CreatorPassenger(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumprion, int stewardess, int classes)
            : base(id, model, producer, crew, fuelCapacity, totalLoad, fuelConsumprion)
        {
            _steardess = stewardess;
            _classes = classes;
        }

        public override Interfaces.IAirplane GetAirplane()
        {
            return new Passenger(_id, _model, _producer, _crew, _fuelCapacity, _totalLoad, _fuelConsumption, _steardess, _classes);
        }
    }
}
