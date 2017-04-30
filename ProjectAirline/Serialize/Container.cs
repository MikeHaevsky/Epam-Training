using ProjectAirline.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectAirline.Serialize
{
    public  class Container
    {
        public IEnumerable< Creator> _creator;
        public string _name;
        public string _slogan;

        public Container() { }
        public Container(IEnumerable<Creator> creator,string name, string slogan)
        {
            _creator = creator;
            _name = name;
            _slogan = slogan;
        }
        //public Airline GetAirline()
        //{
        //    return new Airline(_creator, _name, _slogan);
        //}
    }
}
