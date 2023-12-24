using Microsoft.EntityFrameworkCore;
using MilanMolat.Application.Abstract;
using MilanMolat.Domain.Common;
using MilanMolat.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilanMolat.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : EntityBase
    {
        private readonly MilanMolatDbContext _context;

        public ReadRepository(MilanMolatDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public List<T> GetAll()
        {
           return Table.ToList();
        }

        public T GetById(string id)
        {
           return Table.FirstOrDefault(x => x.Id == Guid.Parse(id));
        }

        

    }
}
