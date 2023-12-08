using MilanMolat.API.Services.Interfaces;
using MilanMolat.Domain.Entities;

namespace MilanMolat.API.Services
{
    public class DefraudedPersonService : IDefraudedPersonService
    {
        public List<DefraudedPerson> CreateDefraudedPeople()
        {
            var defraudedPeople = new List<DefraudedPerson>
            {
                new DefraudedPerson { Id = Guid.Parse("12f59c7c-d95d-47a4-a3a7-8a74c7fb9f4e"), FirstName = "John", LastName = "Doe" },
                new DefraudedPerson { Id = Guid.Parse("0a4e1a79-6323-493c-b1dc-d48f96b43d0d"), FirstName = "Alice", LastName = "Smith" },
                new DefraudedPerson { Id = Guid.Parse("8f46f3d9-19c8-4f8d-94cb-64f1b5ccdb14"), FirstName = "Bob", LastName = "Johnson" },
                new DefraudedPerson { Id = Guid.Parse("5e41f64b-4c17-4a7d-af84-36c107d99172"), FirstName = "Emily", LastName = "Brown" },
                new DefraudedPerson { Id = Guid.Parse("c9f9b4cc-b54c-4948-97d4-b0056aa50623"), FirstName = "Michael", LastName = "Wilson" }
            };




            return defraudedPeople;
        }
    }
}
