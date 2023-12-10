using Week11_Assignment.Persistence.Domain.Entities;

namespace Week11_Assignment.Persistence.API.Services.Interfaces
{
    public interface IDefraudedPersonService
    {
        List<DefraudedPerson> CreateDefraudedPeople();
    }
}
