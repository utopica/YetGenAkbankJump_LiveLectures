using Week11_Assignment.Persistence.API.Services.Interfaces;
using Week11_Assignment.Persistence.Domain.Entities;

namespace Week11_Assignment.Persistence.API.Services
{
    public class DefraudedPersonService : IDefraudedPersonService
    {
        public List<DefraudedPerson> CreateDefraudedPeople()
        {
            var defraudedPeople = new List<DefraudedPerson>
            {
                new DefraudedPerson { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" },
                new DefraudedPerson { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Smith" },
                new DefraudedPerson { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Johnson" },
                new DefraudedPerson { Id = Guid.NewGuid(), FirstName = "Emily", LastName = "Brown" },
                new DefraudedPerson { Id = Guid.NewGuid(), FirstName = "Michael", LastName = "Wilson" }
            };




            return defraudedPeople;
        }
    }
}
