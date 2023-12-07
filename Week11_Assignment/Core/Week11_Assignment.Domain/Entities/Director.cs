using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_Assignment.Domain.Common;

namespace Week11_Assignment.Domain.Entities
{
    public class Director : EntityBase<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<DirectorMovie> DirectorMovies { get; set; }

        
    }
}
