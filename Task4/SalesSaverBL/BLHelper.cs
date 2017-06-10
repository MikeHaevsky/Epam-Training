using SalesSaverBL.Model;
using SalesSaverDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSaverBL
{
    public static class BLHelper
    {
        public static DateTime CreateDate(this string lineElement)
        {
            DateTime date;
            if (DateTime.TryParse(lineElement, out date) == true)
            {
                return date;
            }
            else
            {
                Console.WriteLine("Incorrect Date value.");
            }
            return date;
        }
        public static int CreateCost(this string lineElement)
        {
            int cost;
            if (Int32.TryParse(lineElement, out cost) == true)
            {
                return cost;
            }
            else
            {
                Console.WriteLine("Incorrect Cost value.");
            }
            return cost;
        }
    }
}
