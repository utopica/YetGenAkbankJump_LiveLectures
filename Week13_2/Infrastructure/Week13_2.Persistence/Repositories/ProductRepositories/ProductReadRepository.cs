using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13_2.Application.Repositories.ProductRepositories;
using Week13_2.Domain.Entities;

namespace Week13_2.Persistence.Repositories.ProductRepositories
{
    public class ProductReadRepository : IProductReadRepository<Product>
    {
        public DbSet<Product> Table => throw new NotImplementedException();

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
