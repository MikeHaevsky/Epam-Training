using ProjectAirline.Interfaces;
using ProjectAirline.Serialize;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Classes
{
    public class Airline
    {
        public IEnumerable<IAirplane> _airplanes;
        public string _name;
        public string _slogan;
        private CreatorAirplane[] creator;
        public Airline(IEnumerable<IAirplane> airplanes, string name, string slogan)
        {
            _airplanes = airplanes;
            _name = name;
            _slogan = slogan;
        }

        public IEnumerable<IAirplane> Airplanes
        {
            get
            {
                return _airplanes;
            }
        }
        public IAirplane GetElementByNumber(int number)
        {
            return _airplanes.ElementAt(number);
        }
        public int GetSumCopacity()
        {
            return _airplanes.Sum(item => item.GetCapacity());   
        }
        public int GetSumRange()
        {
            return _airplanes.Sum(item => item.GetRage());
        }
            
        public IEnumerable<string> SortByRange()
        {
            return _airplanes.OrderBy(item => item.GetRage()).
                Select(item =>item.GetInfo());
        }
        public IEnumerable<string> FindByFuelConsumption(int x, int y)
        {
            return _airplanes
                .Where(item => (item.FuelConsumption > x) & (item.FuelConsumption < y))
                .Select(item => string.Format("{1}{0} | TotalLoad:{2} \n", item.Model, item.Producer, item.FuelConsumption));
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Slogan
        {
            get
            {
                return _slogan;
            }
        }
        public string ShowInfo()
        {
            string s = string.Format("Airline: {0}\nSlogan:{1}\n{2}\n{3}", _name, _slogan,GUI.separator, string.
                Join("\n"+GUI.pseparator+"\n", _airplanes.Select(item => item.GetInfo())));
            return s;
        }
    }
}