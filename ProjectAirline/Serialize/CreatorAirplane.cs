using ProjectAirline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectAirline.Serialize
{
    [Serializable]
    [XmlInclude(typeof(CreatorCargo))]
    [XmlInclude(typeof(CreatorPassenger))]
    [XmlInclude(typeof(CreatorCharter))]
    public abstract class CreatorAirplane
    {
        public int _id;
        public string _model;
        public string _producer;
        public int _crew;
        public int _fuelCapacity;
        public int _totalLoad;
        public int _fuelConsumption;
        public CreatorAirplane() { }
        public CreatorAirplane(int id, string model, string producer, int crew, int fuelCapacity, int totalLoad, int fuelConsumption)
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
