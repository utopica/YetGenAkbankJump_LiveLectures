using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Week11_Assignment.Persistence.Domain.Identity;
using Week11_Assignment.Persistence.Domain.Entities;

namespace Week11_Assignment.Persistence.Infrastructure.Contexts
{
    public class AssignmentIdentityDbContext : IdentityDbContext<User,Role,Guid>
    {

        public AssignmentIdentityDbContext(DbContextOptions<AssignmentIdentityDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetStringFromJson("ConnectionStrings:PostgreSQLIdentity"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Ignore<BankAccount>();
            modelBuilder.Ignore<Movie>();
            modelBuilder.Ignore<Director>();
            modelBuilder.Ignore<DirectorMovie>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
