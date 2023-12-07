using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week11_Assignment.API.Models;
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

        [HttpPost("AddDirector&ItsMovies")]
        public async Task<IActionResult> AddAsync(DirectorAddDto directorAddDto, CancellationToken cancellationToken)
        {
            if (directorAddDto is null || string.IsNullOrEmpty(directorAddDto.FirstName))
            {
                return BadRequest();
            }

            List<DirectorMovie> directorMovies = new List<DirectorMovie>();

            var id = Guid.NewGuid();

            if (directorAddDto.MovieIds is not null && directorAddDto.MovieIds.Any())
            {
                foreach (var movieId in directorAddDto.MovieIds)
                {
                    var directorMovie = new DirectorMovie()
                    {
                        MovieId = movieId,
                        DirectorId = id,

                    };

                    directorMovies.Add(directorMovie);
                }
            }

            var director = new Director()
            {
                Id = Guid.NewGuid(),
                FirstName = directorAddDto.FirstName,
                LastName = directorAddDto.LastName,
                CreatedByUserId = "elifokumus",
                CreatedOn = DateTimeOffset.UtcNow,
                IsDeleted = false,
                DirectorMovies = directorMovies
            };

            await _assignmentDbContext.Directors.AddAsync(director, cancellationToken);

            await _assignmentDbContext.SaveChangesAsync(cancellationToken);

            return Ok(director);
        }

        [HttpPost]

        public async Task<IActionResult> AddOnlyAsync(DirectorOnlyAddDto directorOnlyAddDto, CancellationToken cancellationToken)
        {
            if (directorOnlyAddDto is null)
                return BadRequest("Director's name cannot be null");

            var director = new Director()
            {
                Id = Guid.NewGuid(),
                FirstName = directorOnlyAddDto.FirstName,
                LastName = directorOnlyAddDto.LastName,
                CreatedByUserId = "elifokumus",
                CreatedOn = DateTimeOffset.UtcNow,
                IsDeleted = false,
            };

            await _assignmentDbContext.Directors.AddAsync(director, cancellationToken);

            await _assignmentDbContext.SaveChangesAsync(cancellationToken);

            return Ok();
        }

        [HttpGet("GetOnlyDirectors")]
        public async Task<IActionResult> GetOnlyAsync(CancellationToken cancellationToken)
        {
            var directors = await _assignmentDbContext
                .Directors
                .AsNoTracking()
                .ToListAsync(cancellationToken);


            return Ok(directors);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var directors = await _assignmentDbContext
                .Directors
                .Include(x => x.DirectorMovies)
                .ThenInclude(x => x.Movie)
                .AsNoTracking()
                .Select(x => new DirectorDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Movies = x.DirectorMovies.Select(x => new DirectorGetAllMovieDto()
                    {
                        MovieId = x.Movie.Id,
                        MovieTitle = x.Movie.Title

                    }).ToList()


                }).ToListAsync(cancellationToken);

            return Ok(directors);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var director = await _assignmentDbContext
                .Directors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return Ok(director);
        }

        [HttpGet("[action] /{DirectorId}")]
        public GetDirectorDataResponseModel GetDirectorData(Guid DirectorId)
        {
            var director = _assignmentDbContext.Directors.FirstOrDefault(x => x.Id == DirectorId);

            var response = new GetDirectorDataResponseModel()
            {
                FirstName = director.FirstName,
                LastName = director.LastName,
                DirectorMovies = director.DirectorMovies,
            };

            return response;
        }


    }
}
