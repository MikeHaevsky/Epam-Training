using ProjectAirline.Classes;
using ProjectAirline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Serialize
{
    [Serializable]
    public class CreatorPassenger: CreatorAirplane
    {
        public int _steardess;
        public int _classes;
        public CreatorPassenger() { }
        public CreatorPassenger(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumprion, int stewardess, int classes)
            : base(id, model, producer, crew, fuelCapacity, totalLoad, fuelConsumprion)
        {
            _steardess = stewardess;
            _classes = classes;
        }
        public override IAirplane GetAirplane()
        {
            return new Passenger(_id, _model, _producer, _crew, _fuelCapacity, _totalLoad, _fuelConsumption, _steardess, _classes);
        }
    }
}
