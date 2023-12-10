using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11_Assignment.Persistence.Domain.Dtos
{
    public class DirectorGetAllMovieDto
    {
        public Guid MovieId { get; set; }
        public string MovieTitle { get; set;}
    }
}
