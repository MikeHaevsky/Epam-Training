using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirline.Interfaces
{
    interface IArmy
    {
        bool Rockets { get; set; }
        int RocketsWeight { get; }
        int RocketQuantity { get; set; }
        bool Mushingan { get; set; }
        int MushingenWeight { get; }
        bool Bomb { get; set; }
        int BombWeight { get; }
        int BombQuantity { get; set; }
        bool HasRittderWalküren { get; set; }
    }
}
