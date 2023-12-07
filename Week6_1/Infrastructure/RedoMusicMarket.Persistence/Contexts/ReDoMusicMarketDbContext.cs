using Microsoft.EntityFrameworkCore;
using RedoMusicMarket.Domain.Entities;
using RedoMusicMarket.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoMusicMarket.Persistence.Contexts
{
    public class RedoMusicMarketDbContext : DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configurations.GetStringFromJson("ConnectionStrings:PostgreSQL"));
        }

    }
}
