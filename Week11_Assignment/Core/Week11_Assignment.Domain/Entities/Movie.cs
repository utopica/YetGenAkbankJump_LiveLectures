using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_Assignment.Persistence.Domain.Common;
using Week11_Assignment.Persistence.Domain.Enums;

namespace Week11_Assignment.Persistence.Domain.Entities
{
    public class Movie : EntityBase<Guid>
    {
        public string Title { get; set; }
        public Guid DirectorId { get; set; }
        public Director Director { get; set; }
        public ICollection<DirectorMovie> DirectorMovies { get; set; }

        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }
        
    }
}
