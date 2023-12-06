using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Week10_1.Domain.Identity;
using Week11_2.IdentityMVC.ViewModels;

namespace Week11_2.IdentityMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IToastNotification _toastNotification;

        public AuthController(UserManager<User> userManager, IToastNotification toastNotification)
        {
            _userManager = userManager;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var regiesterViewModel = new AuthRegisterViewModel();

            return View(regiesterViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(AuthRegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var userId = Guid.NewGuid();

            var user = new User()
            {
                Id = userId,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                BirthDate = registerViewModel.BirthDate,
                Gender = registerViewModel.Gender,
                UserName = registerViewModel.Username,
                CreatedByUserId = userId.ToString(),
                CreatedOn = DateTimeOffset.UtcNow,
            };

            var identityResult = await _userManager.CreateAsync(user,registerViewModel.Password);

            if(!identityResult.Succeeded)
            {
                throw new Exception("Identity operation failed.");
            }

            //if regiestering is successful

            _toastNotification.AddSuccessToastMessage("You have successfully registered to the application.");


            return View();
        }
    }
}
