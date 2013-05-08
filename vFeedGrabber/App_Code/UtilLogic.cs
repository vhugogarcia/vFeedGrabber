using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace UtilLogic
{
    public class Configuration
    {
        public static string GetKey(string key)
        {
            return ConfigurationSettings.AppSettings[key].ToString();
        }
    }
}
