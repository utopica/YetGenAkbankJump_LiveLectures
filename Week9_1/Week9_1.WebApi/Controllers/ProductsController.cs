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
                //.Include(x => x.Category)
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
                .Include(x => x.ProductCategories)
                .ThenInclude(x=>x.Category)
                .AsNoTracking()
                .Select(x=> new ProductDto()
                {
                    Id = x.Id,
                    Name  = x.Name,
                    CreatedOn = x.CreatedOn,
                    Categories = x.ProductCategories.Select(x=> new ProductGetAllCategoryDto()
                    {
                        Id = x.Category.Id,
                        Name = x.Category.Name,
                    }).ToList(),
                })
                .ToListAsync(cancellationToken);


            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductAddDto productAddDto, CancellationToken cancellationToken)
        {
            if (productAddDto is null || String.IsNullOrEmpty(productAddDto.Name) )
            {
                return BadRequest();
            }

            List<ProductCategory> productCategories = new List<ProductCategory>();

            var id = Guid.NewGuid();

            if (productAddDto.CategoryId is not null && productAddDto.CategoryId.Any())
            {
                foreach (var categoryId in productAddDto.CategoryId)
                {
                    var productCategory = new ProductCategory()
                    {
                        CategoryId = categoryId,
                        ProductId = id,
                        CreatedOn = DateTimeOffset.UtcNow,
                        CreatedByUserId = "elifokumus"
                    };

                    productCategories.Add(productCategory);
                }
            }

            var product = new Product()
            {
                Id = id,
                Name = productAddDto.Name,
                //CategoryId = productAddDto.CategoryId,
                CreatedByUserId = "ElifOkumus",
                CreatedOn = DateTimeOffset.UtcNow,
                //IsDeleted = false
                ProductCategories = productCategories

            };

            await _applicationDbContext.Products.AddAsync(product);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(product);
        }

    }
}
