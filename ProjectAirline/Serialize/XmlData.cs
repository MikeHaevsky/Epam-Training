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
        //public void Write(IEnumerable<IAirplane> data)
        //{
        //    IEnumerable<Creator> creator = data.Select(item => item.GetCreator());

        //    Container cont = new Container("12", "23e", creator);

        //    StreamWriter sw = new StreamWriter("D:\\Data.xml");
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Container));
        //    xmlSerializer.Serialize(sw, cont);
        //    sw.Close();
        //}
        public Container Read()
        {
            StreamReader sr = new StreamReader("D:\\Data.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Container));
            Container creator = (Container)xmlSerializer.Deserialize(sr);
            sr.Close();
            //string filename = "D:\\Data.xml";
            //XmlSerializer dataSerializer = new XmlSerializer(typeof(Container));
            //StreamReader sr = new StreamReader(filename);
            //XmlReader xmlReader = XmlReader.Create(sr);
            ////Container cont;
            //Container cont = (Container)dataSerializer.Deserialize(xmlReader);
            //sr.Close();
            //return cont;
            return creator;
        }


    }
}
