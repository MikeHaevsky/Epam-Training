using SalesSaverBL.Model;
using SalesSaverDAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSaverBL
{
    public static class BLHelper
    {
        public static string FolderSetting
        {
            get;
            set;
        }
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
        public static void InitializeSetting(string key)
        {
            try
            {
                string value = "D:\\SalesSaver";
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    value = settings[key].Value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                FolderSetting = value;
            }
            catch
            {
                Console.WriteLine("Error writing app settings");
                FolderSetting = "D:\\SalesSaver";
            }
        }
    }
}
