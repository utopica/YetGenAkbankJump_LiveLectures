using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedoMusicMarket.Domain.Common;

namespace RedoMusicMarket.Domain.Entities
{
    public class Brand : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
