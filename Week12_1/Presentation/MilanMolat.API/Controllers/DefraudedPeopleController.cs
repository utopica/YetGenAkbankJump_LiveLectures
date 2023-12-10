using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week11_Assignment.Persistence.API.Services;
using Week11_Assignment.Persistence.API.Services.Interfaces;
using Week11_Assignment.Persistence.Infrastructure.Contexts;

namespace Week11_Assignment.Persistence.API.Controllers
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

            //_milanMolatDbContext.SaveChanges(); //you should save changes one time.


        }

        [HttpGet("action / {defraudedPersonId:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid defraudedPersonId, CancellationToken cancellationToken)
        {
            var defraudedPerson = await _milanMolatDbContext
                .DefraudedPeople
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == defraudedPersonId,cancellationToken);

            if (defraudedPerson is null)
                return BadRequest("Defrauded person not found.");

            //Console.WriteLine(string.Join("\n", _milanMolatDbContext.DefraudedPeople.Select(x => x.Id).ToList()));

            return Ok(defraudedPerson);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            //var defraudedPeople = _milanMolatDbContext.DefraudedPeople.ToList();

            var defraudedPeople = await _milanMolatDbContext
                .DefraudedPeople
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            await Console.Out.WriteLineAsync(string.Join("\n",defraudedPeople.Select(x => x.Id).ToList()));

            return Ok(defraudedPeople);
        }

       
    }
}
