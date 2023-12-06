using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week10_1.Domain.Dtos;
using Week10_1.Domain.Entities;
using Week10_1.Persistence.Contexts;

namespace Week9_1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoriesController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _applicationDbContext
                .Categories
                .AsNoTracking()
                .Include(x => x.ProductCategories)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var category = await _applicationDbContext
                .Categories
                .AsNoTracking()
                .ToListAsync(cancellationToken);


            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(CategoryAddDto categoryAddDto, CancellationToken cancellationToken)
        {

            if (categoryAddDto is null)
                return BadRequest("Category's name cannot be null");

            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = categoryAddDto.Name,
                CreatedByUserId = "elifokumus",
                CreatedOn = DateTimeOffset.UtcNow,
                IsDeleted = false,
            };

            await _applicationDbContext.Categories.AddAsync(category, cancellationToken);



            await _applicationDbContext.SaveChangesAsync(cancellationToken);



            return Ok(category);
        }
    }


}

//CancellationTokenSource source = new CancellationTokenSource();