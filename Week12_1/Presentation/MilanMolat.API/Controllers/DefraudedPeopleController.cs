using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilanMolat.API.Services;
using MilanMolat.API.Services.Interfaces;
using MilanMolat.Infrastructure.Contexts;

namespace MilanMolat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefraudedPeopleController : ControllerBase
    {
        private readonly MilanMolatDbContext _milanMolatDbContext;
        private readonly IDefraudedPersonService _defraudedPersonService;


        public DefraudedPeopleController(MilanMolatDbContext milanMolatDbContext, IDefraudedPersonService defraudedPersonService)
        {
            _milanMolatDbContext = milanMolatDbContext;

            _defraudedPersonService = defraudedPersonService;

            _milanMolatDbContext.DefraudedPeople.AddRange(_defraudedPersonService.CreateDefraudedPeople());

            _milanMolatDbContext.SaveChanges();


        }

        [HttpGet("action / {defraudedPersonId:guid}")]
        public IActionResult GetDefraudedPersonName(Guid defraudedPersonId)
        {
            var defraudedPerson =  _milanMolatDbContext.DefraudedPeople.FirstOrDefault(x => x.Id == defraudedPersonId);

            if (defraudedPerson is null)
                return BadRequest("Defrauded person not found.");

            Console.WriteLine(string.Join("\n", _milanMolatDbContext.DefraudedPeople.Select(x => x.Id).ToList()));

            return Ok(defraudedPerson);
        }

       
    }
}
