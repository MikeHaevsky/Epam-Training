using ProjectAirline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Classes
{
    abstract class Airplane : IAirplane
    {
        private int _id;
        private string _model;
        private string _producer;
        private int _crew;
        private int _fuelCapacity;
        private int _totalLoad;
        private int _fuelConsumption;
        private const int intAverageSpeed = 900;
        protected const int intAverageHumanWeight = 62;
        public Airplane(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumption)
        {
            _id = id;
            _model = model;
            _producer = producer;
            _crew = crew;
            _fuelCapacity = fuelCapacity;
            _totalLoad = totalLoad;
            _fuelConsumption = fuelConsumption;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }
        public string Model
        {
            get
            {
                return _model;
            }
        }

        public string Producer
        {
            get
            {
                return _producer;
            }
        }

        public int Crew
        {
            get
            {
                return _crew;
            }
        }
        public int FuelCapacity
        {
            get
            {
                return _fuelCapacity;
            }
        }

        public int TotalLoad
        {
            get
            {
                return _totalLoad;
            }
        }

        public int FuelConsumption
        {
            get
            {
                return _fuelConsumption;
            }
        }
        public virtual int GetCapacity()
        {
            return (((_totalLoad - _fuelConsumption) / intAverageHumanWeight) / 100) * 80 - _crew;
        }
        public int GetRage()
        {
            return (_fuelCapacity / _fuelConsumption)*intAverageSpeed;
        }
        public virtual string GetInfo()
        {
            return string.Format("{0}{1}\nCrew:{2}\n"+
                "Fuel capacity:{3}\n"+
                "Total load:{4}\n"+
                "Fuel consumption:{5}\n"+
                "Capacity:{6}\n"+
                "Range:{7}",
                Producer, Model, Crew, FuelCapacity, TotalLoad, FuelConsumption, GetCapacity(), GetRage());
        }
        public abstract Serialize.CreatorAirplane GetCreator();
    }
}
