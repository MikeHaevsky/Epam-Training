﻿using ProjectAirline.Interfaces;
using ProjectAirline.Serialize;
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
        }
        public int Classes
        {
            get
            {
                return _classes;
            }
        }
        public override int GetCapacity()
        {
            int gc = (((_totalLoad - _fuelConsumption) / 62) / 100) * 90 - _crew;
            return gc;
        }
        public override string GetInfo()
        {
            return string.Format("{0}{1}\nCrew:{2}\nFuel capacity:{3}\nTotal load:{4}\nFuel consumption:{5}\nCapacity:{6}\nRange:{7}\nStewardess:{8}\nClasses:{9}", Producer, Model, Crew, FuelCapacity, TotalLoad, FuelConsumption, GetCapacity(), GetRage(), Stewardess, Classes);
        }
        public override Serialize.CreatorAirplane GetCreator()
        {
            return new CreatorCharter(Id, Model, Producer, Crew, FuelCapacity, TotalLoad, FuelCapacity, Stewardess, Classes);
        }
    }
}