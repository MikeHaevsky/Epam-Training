using ProjectAirline.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectAirline.Serialize
{
    [Serializable]
    public  class CreatorAirline
    {
        public CreatorAirplane[] _creator;
        public string _name;
        public string _slogan;
        public CreatorAirline() { }
        public CreatorAirline(string name, string slogan, CreatorAirplane[] creator)
        {
            _creator = creator;
            _name = name;
            _slogan = slogan;
        }
    }
}
