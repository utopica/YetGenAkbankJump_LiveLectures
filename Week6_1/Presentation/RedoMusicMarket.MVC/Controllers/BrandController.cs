using Microsoft.AspNetCore.Mvc;
using RedoMusicMarket.Domain.Entities;
using RedoMusicMarket.Persistence.Contexts;

namespace RedoMusicMarket.MVC.Controllers
{
    public class BrandController : Controller
    {
        private readonly RedoMusicMarketDbContext _context;

        public BrandController()
        {
            _context = new();
        }

        public IActionResult Index()
        {
            var brands = _context.Brands.ToList() ;
            return View(brands);
        }
        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBrand(string brandName, string brandDisplayText, string brandAddress,string brandPhoneNumber)
        {
            var brand = new Brand()
            {
                Id = Guid.NewGuid(),
                Name = brandName,
                Address = brandAddress,
                DisplayText = brandDisplayText,
                PhoneNumber = brandPhoneNumber,
                CreatedOn = DateTime.UtcNow,
            };

            _context.Brands.Add(brand);

            _context.SaveChanges();

            return View();
        }

        [HttpGet]
        public IActionResult DeleteBrand(string Id)
        {
            var brand = _context.Brands.Where(x=>x.Id == Guid.Parse(Id)).FirstOrDefault();
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
