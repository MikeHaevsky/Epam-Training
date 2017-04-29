using ProjectAirline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Serialize
{
    public abstract class Creator
    {
        protected int _id;
        protected string _model;
        protected string _producer;
        protected int _crew;
        protected int _fuelCapacity;
        protected int _totalLoad;
        protected int _fuelConsumption;
        public Creator(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumption)
        {
            _id = id;
            _model = model;
            _producer = producer;
            _crew = crew;
            _fuelCapacity = fuelCapacity;
            _totalLoad = totalLoad;
            _fuelConsumption = fuelConsumption;
        }
        public abstract IAirplane GetAirplane();
    }
}
