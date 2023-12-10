using Microsoft.EntityFrameworkCore;
using MilanMolat.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilanMolat.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        public DbSet<T> Table { get; }

        public List<T> GetAll()
        {
           return Table.ToList();
        }

        public T GetById(string id)
        {
            
        }
    }
}
