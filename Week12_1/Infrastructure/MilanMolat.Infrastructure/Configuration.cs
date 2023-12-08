using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11_Assignment.Persistence
{
    public static class Configuration
    {
        public static string GetStringFromJson(string key)
        {
            ConfigurationManager configurationManager = new();
            string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Infrastructure\\MilanMolat.Infrastructure";

            configurationManager.SetBasePath(path);

            //reading
            configurationManager.AddJsonFile("PrivateInformations.json");

            return configurationManager.GetSection(key).Value;
        }
    }
}
