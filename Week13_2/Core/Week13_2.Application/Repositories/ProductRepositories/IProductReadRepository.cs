using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13_2.Domain.Common;
using Week13_2.Domain.Entities;

namespace Week13_2.Application.Repositories.ProductRepositories
{
    public interface IProductReadRepository<T> : IReadRepository<T> where T : EntityBase
    {

    }
}
