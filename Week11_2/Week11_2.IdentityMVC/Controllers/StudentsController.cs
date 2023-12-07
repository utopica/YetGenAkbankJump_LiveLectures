using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Week11_2.IdentityMVC.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
