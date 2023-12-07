using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week11_Assignment.Domain.Dtos;
using Week11_Assignment.Domain.Entities;
using Week11_Assignment.Persistence.Contexts;

namespace Week11_Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly AssignmentDbContext _assignmentDbContext;

        public DirectorsController(AssignmentDbContext assignmentDbContext)
        {
            _assignmentDbContext = assignmentDbContext;
        }

        [HttpPost]

        public async Task<IActionResult> AddAsync(DirectorDto directorDto, CancellationToken cancellationToken)
        {
            if (directorDto is null)
                return BadRequest("Director's name cannot be null");

            var director = new Director()
            {
                Id = Guid.NewGuid(),
                FirstName = directorDto.FirstName,
                LastName = directorDto.LastName,
                CreatedByUserId = "elifokumus",
                CreatedOn = DateTimeOffset.UtcNow,
                IsDeleted = false,
            };

            await _assignmentDbContext.Directors.AddAsync(director,cancellationToken);

            await _assignmentDbContext.SaveChangesAsync(cancellationToken);

            return Ok();
        }

    }
}
