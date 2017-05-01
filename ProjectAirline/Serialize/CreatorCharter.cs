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
    public class CreatorCharter: CreatorAirplane
    {
        public int _steardess;
        public int _classes;
        public CreatorCharter() { }
        public CreatorCharter(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumption, int stewardess, int classes)
            : base(id, model, producer, crew, fuelCapacity, totalLoad, fuelConsumption)
        {
            _steardess = stewardess;
            _classes = classes;
        }
        public override IAirplane GetAirplane()
        {
            return new Charter(_id, _model, _producer, _crew, _fuelCapacity, _totalLoad, _fuelConsumption, _steardess, _classes);
        }
    }
}
