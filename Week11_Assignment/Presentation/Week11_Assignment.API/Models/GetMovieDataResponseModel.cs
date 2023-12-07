using Week11_Assignment.Domain.Entities;
using Week11_Assignment.Domain.Enums;

namespace Week11_Assignment.API.Models
{
    public class GetMovieDataResponseModel
    {
        public string Title { get; set; }
        public Guid DirectorId { get; set; }
        public Director Director { get; set; }
        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }
    }
}
