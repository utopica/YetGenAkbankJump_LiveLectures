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
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductsController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var product = await _applicationDbContext
                .Products
                .Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            //var products =  _applicationDbContext.Products.Where(x => x.CategoryId == id);

            //var categoryName = product.Category.Name;

            return Ok(product);


        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var products = await _applicationDbContext
                .Products
                .Include(x => x.Category)
                .AsNoTracking()
                .ToListAsync(cancellationToken);


            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddDto productAddDto, CancellationToken cancellationToken)
        {
            if (productAddDto is null || String.IsNullOrEmpty(productAddDto.Name) || productAddDto.CategoryId == Guid.Empty)
            {
                return BadRequest();
            }
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = productAddDto.Name,
                CategoryId = productAddDto.CategoryId,
                CreatedByUserId = "ElifOkumus",
                CreatedOn = DateTimeOffset.UtcNow,
                IsDeleted = false

            };

            await _applicationDbContext.Products.AddAsync(product);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(product);
        }

    }
}
