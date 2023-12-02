using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week7_2.Persistence.Contexts;
using Week7_2.Domain.Common;
using Week7_2.Domain.Entities;

namespace Week7_2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersAndDriversController : ControllerBase
    {
        private readonly Week7_2DbContext _context;

        public PassengersAndDriversController(Week7_2DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllPassengers()
        {
            var passenger = _context.Passengers;

            return Ok(passenger);
        }

        [HttpGet("{id}")]
        public IActionResult GetPassengersById(string id)
        {

            var passenger = _context.Passengers.FirstOrDefault(p => p.Id == Guid.Parse(id));

            return Ok(passenger);
        }

        [HttpPost]
        public IActionResult CreatePassenger([FromBody] Passenger passenger)
        {

            _context.Passengers.Add(passenger);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPassengersById), new { id = passenger.Id }, passenger);
        }

        

    }
}
