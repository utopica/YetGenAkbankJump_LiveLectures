using MilanMolat.Domain.Entities;

namespace MilanMolat.API.Services.Interfaces
{
    public interface IDefraudedPersonService
    {
        List<DefraudedPerson> CreateDefraudedPeople();
    }
}
