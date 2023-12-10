using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11_Assignment.Persistence.Domain.Common
{
    public interface IModifiedByEntity
    {
        DateTimeOffset? ModifiedOn { get; set; }
    }
}
