using ProjectAirline.Classes;
using ProjectAirline.Interfaces;
using ProjectAirline.Serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline
{
    class Program
    {
        static void Main(string[] args)
        {
            Airline airline;
            const string filename = "Data.xml";
            string path = string.Concat(Directory.GetCurrentDirectory(), "\\", filename);
            XmlData xmlData = new XmlData();
            if (File.Exists(path))
            {
                airline = xmlData.Read(path);
                //GUI.Airline = airline1;
            }
            else
            {
                airline = new Airline(
                new List<IAirplane>()
                {
                    new Cargo(1,"An2","antonov",2,500,2000,132),
                    new Passenger(2,"TU204","tupolev",4,600,107500,100,10,3),
                    new Charter(3,"A321","aerobus",5,1000,89000,100,10,3),
                    new Charter(4,"757-200","boeing",6,3000,108800,100,15,4),
                    new Charter(5,"TU154","tupolev",4,4000,102000,150,10,2)
                }, "Aeroflot", "Fly in order for fly"
                );
                xmlData.Write(airline, path);
            }
            GUI.Start(airline);
        }
    }
}
