using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11_Assignment.Domain.Dtos
{
    public class DirectorGetAllMoviesDto
    {
        public Guid MovieId { get; set; }
        public string MovieName { get; set;}
    }
}
