using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Week13_2.Domain.Entities;
using Week13_2.Persistence.Contexts;

namespace Week13_2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly Week13_2DbContext _context;

        public ProductsController(Week13_2DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            var products = _context.Products.Where(x => x.Price > 25).ToList();

            foreach(var product in products)
            {
                product.Price += 100; 
            }

            _context.SaveChanges();
            return products;
        }
    }
}
