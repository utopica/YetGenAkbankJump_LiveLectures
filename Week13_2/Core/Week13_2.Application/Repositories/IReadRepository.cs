using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13_2.Domain.Common;

namespace Week13_2.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : EntityBase
    {
        List<T> GetAll();

        T GetById(string Id);
    }
}
