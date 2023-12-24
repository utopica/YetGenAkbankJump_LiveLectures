using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilanMolat.API.Services;
using MilanMolat.API.Services.Interfaces;
using MilanMolat.Application.Abstract.DefraudedPersonRepositories;
using MilanMolat.Infrastructure.Contexts;

namespace MilanMolat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefraudedPeopleController : ControllerBase
    {
        private readonly IDefraudedPersonReadRepository _context;

        private readonly MilanMolatDbContext _milanMolatDbContext; //created just because creating example instances
        
        private readonly IDefraudedPersonService _defraudedPersonService;


        public DefraudedPeopleController(IDefraudedPersonService defraudedPersonService, IDefraudedPersonReadRepository context, MilanMolatDbContext milanMolatDbContext)
        {
            _context = context;

            _milanMolatDbContext = milanMolatDbContext;

            _defraudedPersonService = defraudedPersonService;

            //you should code IDefraudedPersonWriteRepository 
            //_context.Table.AddRange(_defraudedPersonService.CreateDefraudedPeople());
            //_context.SaveChanges();

            
        }
        public void CreateExampleInstances()
        {
            _milanMolatDbContext.DefraudedPeople.AddRange(_defraudedPersonService.CreateDefraudedPeople());
            _milanMolatDbContext.SaveChanges(); //you should save changes one time.
            
            //Console.WriteLine(string.Join("\n", _milanMolatDbContext.DefraudedPeople.Select(x => x.Id).ToList()));

        }
        [HttpGet("action / {defraudedPersonId:guid}")]
        public async Task<IActionResult> GetByIdAsync(string defraudedPersonId, CancellationToken cancellationToken)
        {
            var person = _context.GetById(defraudedPersonId);

            return Ok(person is null ? "Could'nt find!" : person.FirstName);

            //before the repository pattern 
            //var defraudedPerson = await _context
            //    .DefraudedPeople
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(x => x.Id == defraudedPersonId,cancellationToken);

            //if (defraudedPerson is null)
            //    return BadRequest("Defrauded person not found.");


            //return Ok(defraudedPerson);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var defraudedPeople = _context.GetAll();
            //before repository patter

            //var defraudedPeople = _milanMolatDbContext.DefraudedPeople.ToList();

            //var defraudedPeople = await _context
            //    .DefraudedPeople
            //    .AsNoTracking()
            //    .ToListAsync(cancellationToken);

            return Ok(defraudedPeople);
        }

       
    }
}
