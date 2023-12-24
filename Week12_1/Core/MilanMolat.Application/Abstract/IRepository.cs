using Microsoft.EntityFrameworkCore;
using MilanMolat.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MilanMolat.Application.Abstract
{
    public interface IRepository<T> where T : EntityBase
    {
        DbSet<T> Table { get; }
    }
}
//public interface IRepository<T> where T : class