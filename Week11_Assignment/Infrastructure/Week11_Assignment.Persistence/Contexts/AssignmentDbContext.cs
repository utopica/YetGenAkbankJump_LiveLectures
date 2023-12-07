using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Week11_Assignment.Domain.Entities;


namespace Week11_Assignment.Persistence.Contexts
{
    public class AssignmentDbContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }

        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetStringFromJson("ConnectionStrings:PostgreSQL"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            

            base.OnModelCreating(modelBuilder);
        }

    }
}

//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{
//    optionsBuilder.UseInMemoryDatabase("Assignment App");
//}
