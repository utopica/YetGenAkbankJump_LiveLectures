using Week11_Assignment.Persistence.Domain.Entities;

namespace Week11_Assignment.Persistence.API.Models
{
    public class GetDirectorDataResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<DirectorMovie> DirectorMovies { get; set; }
    }
}
