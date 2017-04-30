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
        public int _crew;
        public int _fuelCapacity;
        public int _totalLoad;
        public int _fuelConsumption;
        public Airplane(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumprion)
        {
            _id = id;
            _model = model;
            _producer = producer;
            _crew = crew;
            _fuelCapacity = fuelCapacity;
            _totalLoad = totalLoad;
            _fuelConsumption = fuelConsumprion;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        public string Producer
        {
            get
            {
                return _producer;
            }
            set
            {
                _producer = value;
            }
        }

        public int Crew
        {
            get
            {
                return _crew;
            }
            set
            {
                _crew = value;
            }
        }
        public int FuelCapacity
        {
            get
            {
                return _fuelCapacity;
            }
            set
            {
                _fuelCapacity = value;
            }
        }

        public int TotalLoad
        {
            get
            {
                return _totalLoad;
            }
            set
            {
                _totalLoad = value;
            }
        }

        public int FuelConsumption
        {
            get
            {
                return _fuelConsumption;
            }
            set
            {
                _fuelConsumption = value;
            }
        }
        //(метод по умолчанию)средний вес человека на земле составляет 62 кг, а в чартерах мест в среднем больше на 10%
        //исходя из этого, находим грузоподъёмность
        public virtual int GetCapacity()
        {
            int gc = (((_totalLoad - _fuelConsumption) / 62) / 100) * 80 - _crew;
            return gc;
        }
        //дальность полёта
        public int GetRage()
        {
            int gr = _fuelCapacity / _fuelConsumption;
            return gr;
        }
        public virtual string GetInfo()
        {
            return string.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8}", Model, Producer, Crew, FuelCapacity, TotalLoad, FuelConsumption, GetCapacity(), GetRage());
        }


        public abstract Serialize.CreatorAirplane GetCreator();
    }
}
