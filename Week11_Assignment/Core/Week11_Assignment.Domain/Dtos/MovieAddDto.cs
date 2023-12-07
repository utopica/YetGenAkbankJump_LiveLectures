using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_Assignment.Domain.Enums;

namespace Week11_Assignment.Domain.Dtos
{
    public class MovieAddDto
    {
        public string Title { get; set; }

        public Guid DirectorId { get; set; }
        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }
        public TimeSpan Duration { get; set; }

    }
}
