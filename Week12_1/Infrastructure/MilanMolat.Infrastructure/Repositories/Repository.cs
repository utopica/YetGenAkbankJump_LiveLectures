using Microsoft.EntityFrameworkCore;
using MilanMolat.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilanMolat.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbSet<T> Table { get; }
    }
}
