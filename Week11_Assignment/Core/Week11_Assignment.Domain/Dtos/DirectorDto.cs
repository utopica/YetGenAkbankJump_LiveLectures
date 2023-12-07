using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_Assignment.Domain.Entities;

namespace Week11_Assignment.Domain.Dtos
{
    public class DirectorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public ICollection<DirectorMovies> DirectorMovies { get; set; }




        //public ICollection<MovieDto> Movies { get; set; }
    }
}
