using ProjectAirline.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Interfaces
{
    public interface IAirplane
    {
        int Id { get; }
        string Model { get; }
        string Producer { get; }
        int Crew { get; }
        int FuelCapacity { get; }
        int TotalLoad { get; }
        int FuelConsumption { get; }
        int GetCapacity();
        int GetRage();
        string GetInfo();
        CreatorAirplane GetCreator();
    }
}
