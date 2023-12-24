using MilanMolat.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilanMolat.Domain.Entities
{
    public class DefraudedPerson : EntityBase
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
