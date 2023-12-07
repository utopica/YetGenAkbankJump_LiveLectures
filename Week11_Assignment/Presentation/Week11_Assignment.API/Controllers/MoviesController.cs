using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Week11_Assignment.Domain.Dtos;
using Week11_Assignment.Domain.Entities;
using Week11_Assignment.Persistence.Contexts;

namespace Week11_Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AssignmentDbContext _assignmentDbContext;

        public MoviesController(AssignmentDbContext assignmentDbContext)
        {
            _assignmentDbContext = assignmentDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(MovieAddDto movieAddDto, CancellationToken cancellationToken)
        {
            if (movieAddDto is null || string.IsNullOrEmpty(movieAddDto.Title))
                return BadRequest(); //I will ad other requests later 


            var movie = new Movie()
            {
                Id = Guid.NewGuid(),
                Title = movieAddDto.Title,
                DirectorId = movieAddDto.DirectorId,
                ReleaseYear = movieAddDto.ReleaseYear,
                Genre = movieAddDto.Genre,
                CreatedByUserId = "elifokumus",
                CreatedOn = DateTimeOffset.UtcNow,
                IsDeleted = false,
                

            };
            

            await _assignmentDbContext.Movies.AddAsync(movie, cancellationToken);

            await _assignmentDbContext.SaveChangesAsync(cancellationToken);


            return Ok(movie);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync (Guid id, CancellationToken cancellationToken)
        {
            var movie = await _assignmentDbContext
                .Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id,cancellationToken);

            return Ok(movie);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var movies = await _assignmentDbContext
                .Movies
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return Ok(movies);
        }
    }
}
