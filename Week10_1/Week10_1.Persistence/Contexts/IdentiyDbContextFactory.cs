using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10_1.Persistence.Contexts
{
    public class IdentiyDbContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConnectionString.json")
                .Build();


            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();

            var connectionString = configuration.GetSection("YetgenPostgreSQLDB").Value;

            optionsBuilder.UseNpgsql(connectionString);

            return new IdentityContext(optionsBuilder.Options);
        }

        
    }
}
