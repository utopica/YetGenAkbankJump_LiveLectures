using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7_2.Domain.Common;
using Week7_2.Domain.Entities;

namespace Week7_2.Persistence.Contexts
{
    public class Week7_2DbContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<TaxiDriver> TaxiDrivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configurations.GetStringFromJson("ConnectionStrings:PostgreSQL"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Account)
                .WithOne(ba => ba.Owner)
                .HasForeignKey<BankAccount>(ba => ba.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
