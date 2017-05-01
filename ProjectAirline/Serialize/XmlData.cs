using ProjectAirline.Classes;
using ProjectAirline.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProjectAirline.Serialize
{
    class XmlData
    {
        public void Write(Airline airline)
        {
            CreatorAirplane[] creator = airline.Airplanes.Select(item => item.GetCreator()).ToArray();

            CreatorAirline cont = new CreatorAirline(airline.Name, airline.Slogan,creator);

            StreamWriter sw = new StreamWriter("D:\\Data.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CreatorAirline));
            xmlSerializer.Serialize(sw, cont);
            sw.Close();
        }
        public Airline Read()
        {
            StreamReader sr = new StreamReader("D:\\Data.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CreatorAirline));
            CreatorAirline creator = (CreatorAirline)xmlSerializer.Deserialize(sr);
            sr.Close();
            return new Airline(creator._creator.Select(item => item.GetAirplane()), creator._name, creator._slogan);
        }
    }
}
