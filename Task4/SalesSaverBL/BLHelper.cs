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
            return date;
        }
        public static int CreateCost(this string lineElement)
        {
            int cost;
            if (Int32.TryParse(lineElement, out cost) == true)
            {
                return cost;
            }
            return cost;
        }
        public static void InitializeSetting(string key)
        {
            try
            {
                string value = @Resource.DefaultWorkDerictory;
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
                FolderSetting = @Resource.DefaultWorkDerictory;
            }
        }
    }
}
