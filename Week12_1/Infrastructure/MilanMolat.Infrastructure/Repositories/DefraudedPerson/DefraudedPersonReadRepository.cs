using Microsoft.EntityFrameworkCore;
using MilanMolat.Application.Abstract.DefraudedPersonRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilanMolat.Domain.Entities;
using MilanMolat.Infrastructure.Contexts;

namespace MilanMolat.Infrastructure.Repositories.DefraudedPerson
{
    public class DefraudedPersonReadRepository : ReadRepository<Domain.Entities.DefraudedPerson>, IDefraudedPersonReadRepository
    {

        public DefraudedPersonReadRepository(MilanMolatDbContext context) : base(context) 
        { 

        }


        //before-->
        //public DbSet<Domain.Entities.DefraudedPerson> Table => throw new NotImplementedException();

        //public List<Domain.Entities.DefraudedPerson> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Domain.Entities.DefraudedPerson GetById(string id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
 