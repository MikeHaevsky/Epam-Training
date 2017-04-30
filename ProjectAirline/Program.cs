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
            //Airline airline = new Airline(
            //    new List<IAirplane>()
            //    {
            //        new Cargo(1,"An2","antonov",2,132,2000,500),
            //        new Passenger(2,"TU204","tupolev",4,600,107500,100,10,3),
            //        new Charter(3,"A321","aerobus",5,1000,89000,100,10,3),
            //        new Charter(4,"757-200","boing",6,3000,108800,100,15,4)
            //    }, "Aeroflot", "Fly in order for fly"
            //    );

            ////int x, y;            
            ////Console.WriteLine(string.Join("\r\n", airline.SortByRange()));
            ////Console.WriteLine("Write first fuel range...");
            ////int.TryParse(Console.ReadLine(),out x);
            ////Console.WriteLine("Write roofer fuel range...");
            ////int.TryParse(Console.ReadLine(), out y);
            ////Console.WriteLine(string.Join("\r\n", airline.FindByFuelConsumption(x, y)));
            //GUI.Airline = airline;
            //GUI.Start();

            //Creator[] creator = 
            //{
            //    new CreatorPassenger(2,"TU204","tupolev",4,600,107500,100,10,3),
            //    new CreatorCargo(1,"An2","antonov",2,132,2000,500),
            //    new CreatorCharter(3,"A321","aerobus",5,1000,89000,100,10,3),
            //    new CreatorCharter(4,"757-200","boing",6,3000,108800,100,15,4)
            //};
            //Container container = new Container(creator, "Aeroflot", "Fly in order for fly");
            //GUI.Airline = (Airline)container;
            
            //GUI.Airline = airline;
            //GUI.Start();




            //foreach (var item in creator)
            //{
            //    Console.WriteLine(item.GetAirplane().GetType());
            //}
            //XmlData data = new XmlData();
            //data.Write();
            //Console.WriteLine(string.Join("\n",data.Read()));
            //GUI.Airline = airline1;
            //Airline airline1 = data.Read();
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

            //XmlData xmlData = new XmlData();
            //xmlData.Write(airline);
            //Airline airline1 = xmlData.Read();
            //GUI.Airline = airline1;
            GUI.Start();



            //Console.ReadKey();
            
        }
    }
}
