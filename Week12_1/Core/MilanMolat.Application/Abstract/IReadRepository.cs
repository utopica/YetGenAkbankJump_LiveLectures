using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilanMolat.Application.Abstract
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        T GetById(string id);
        List<T> GetAll();
    }
}
