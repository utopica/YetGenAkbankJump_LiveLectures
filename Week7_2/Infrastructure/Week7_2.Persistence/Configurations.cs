using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7_2.Persistence
{
    public static class Configurations
    {

        public static string GetStringFromJson(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("Infrastructure/Week7_2.Persistence/PrivateInformations.json");

            IConfiguration configuration = builder.Build();

            return configuration[key];
        }


        //public static string GetStringFromJson(string key)
        //{
        //    ConfigurationManager configurationManager = new();

        //    string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Infrastructure\\Week7_2.Persistence";

        //    configurationManager.SetBasePath(path);

        //    configurationManager.AddJsonFile("PrivateInformations.json");

        //    return configurationManager.GetSection(key).Value;


            
        //}
    }
}
