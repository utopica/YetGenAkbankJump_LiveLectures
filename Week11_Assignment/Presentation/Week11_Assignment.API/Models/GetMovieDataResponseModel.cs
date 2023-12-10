using Week11_Assignment.Persistence.Domain.Entities;
using Week11_Assignment.Persistence.Domain.Enums;

namespace Week11_Assignment.Persistence.API.Models
{
    public class GetMovieDataResponseModel
    {
        public string Title { get; set; }
        public Guid DirectorId { get; set; }
        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }
    }
}
