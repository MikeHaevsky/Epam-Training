using ProjectAirline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Classes
{
    class Charter: Airplane, IPassenger
    {
        private int _steardess;
        private int _classes;
        public Charter(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumprion, int stewardess, int classes)
            : base(id, model, producer, crew, fuelCapacity, totalLoad, fuelConsumprion)
        {
            _steardess = stewardess;
            _classes = classes;
        }
        public int Stewardess
        {
            get
            {
                return _steardess;
            }
            set
            {
                _steardess = value;
            }
        }

        public int Classes
        {
            get
            {
                return _classes;
            }
            set
            {
                _classes = value;
            }
        }

        public override int GetCapacity()
        {
            int gc = (((_totalLoad - _fuelConsumption) / 62) / 100) * 90 - _crew;
            return gc;
        }

        public override string GetInfo()
        {
            return string.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10}", Model, Producer, Crew, FuelCapacity, TotalLoad, FuelConsumption, GetCapacity(), GetRage(),Stewardess,Classes);
        }
    }
}