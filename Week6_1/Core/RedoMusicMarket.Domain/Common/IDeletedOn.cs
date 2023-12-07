using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoMusicMarket.Domain.Common
{
    public interface IDeletedOn
    {
        public DateTimeOffset? DeletedOn { get; set; }
    }
}
