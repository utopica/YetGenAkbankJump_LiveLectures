using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week10_1.Domain.Entities;
using Week10_1.Persistence.Configurations;
using Week10_1.Domain.Identity;

namespace Week10_1.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet <Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Ignore<User>(); // those classes aren't this dbcontext's concern
            modelBuilder.Ignore<Role>();
            modelBuilder.Ignore<UserSetting>();

            base.OnModelCreating(modelBuilder);

        }

    }
}

//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    modelBuilder.ApplyConfiguration(new StudentConfiguration());
//    base.OnModelCreating(modelBuilder);
//}