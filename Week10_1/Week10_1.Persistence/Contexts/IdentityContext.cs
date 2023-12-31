﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Week10_1.Domain.Entities;
using Week10_1.Domain.Identity;

namespace Week10_1.Persistence.Contexts
{
    public class IdentityContext :IdentityDbContext<User, Role,Guid>
    {
        public IdentityContext(DbContextOptions<IdentityContext> dbContextOptions) : base(dbContextOptions)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Ignore<User>(); //because we get the "categories already exist" 
            modelBuilder.Ignore<Student>();
            modelBuilder.Ignore<Product>();
            modelBuilder.Ignore<Category>();
            modelBuilder.Ignore<ProductCategory>();


            base.OnModelCreating(modelBuilder);
        }
    }
}
