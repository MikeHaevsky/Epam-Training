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
            XmlData xmlData = new XmlData();
            if (File.Exists("D:\\Data.xml"))
            {
                Airline airline1 = xmlData.Read();
                GUI.Airline = airline1;
            }
            else
            {

                Airline airline = new Airline(
                new List<IAirplane>()
                {
                    new Cargo(1,"An2","antonov",2,132,2000,500),
                    new Passenger(2,"TU204","tupolev",4,600,107500,100,10,3),
                    new Charter(3,"A321","aerobus",5,1000,89000,100,10,3),
                    new Charter(4,"757-200","boing",6,3000,108800,100,15,4)
                }, "Aeroflot", "Fly in order for fly"
                );
                xmlData.Write(airline);
                GUI.Airline = airline;
            }
            GUI.Start();
        }
    }
}
