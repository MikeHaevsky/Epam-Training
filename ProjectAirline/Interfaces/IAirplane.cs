using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Interfaces
{
    public interface IAirplane
    {
        int Id { get; set; }
        //модель
        string Model { get; set; }
        //производитель
        string Producer { get; set; }
        //экипаж
        int Crew { get; set; }
        //количество топлива, кг
        int FuelCapacity { get; set; }
        //вес с полной загрузкой
        int TotalLoad { get; set; }
        //расход топлива кг/ч
        int FuelConsumption { get; set; }
        //last
        int GetCapacity();
        int GetRage();
        string GetInfo();
    }
}
