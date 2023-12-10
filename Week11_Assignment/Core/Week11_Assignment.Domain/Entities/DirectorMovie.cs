using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11_Assignment.Domain.Entities
{
    public class DirectorMovie
    {
        public Guid DirectorId { get; set; }
        public Director Director { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        
    }
}
