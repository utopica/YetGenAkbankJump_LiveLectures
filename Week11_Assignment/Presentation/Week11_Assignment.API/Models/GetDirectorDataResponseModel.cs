using Week11_Assignment.Domain.Entities;

namespace Week11_Assignment.API.Models
{
    public class GetDirectorDataResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<DirectorMovie> DirectorMovies { get; set; }
    }
}
