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
        private readonly SignInManager<User> _signInManager;
        
        public AuthController(UserManager<User> userManager, IToastNotification toastNotification, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _toastNotification = toastNotification;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", controllerName: "Students");
            }

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
                BirthDate = registerViewModel.BirthDate.Value.ToUniversalTime(),
                Gender = registerViewModel.Gender,
                UserName = registerViewModel.Username,
                CreatedByUserId = userId.ToString(),
                CreatedOn = DateTimeOffset.UtcNow,


            };

            var identityResult = await _userManager.CreateAsync(user, registerViewModel.Password);

            //if(!identityResult.Succeeded)
            //{
            //    throw new Exception("Identity operation failed.");
            //}

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);


                }
                return View(registerViewModel);
            }


            //if regiestering is successful

            _toastNotification.AddSuccessToastMessage("You have successfully registered to the application.");

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", controllerName: "Home");
            } //if the user is authenticated, user should view the index page

            var loginViewModel = new AuthLoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(AuthLoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user is null)
            {
                _toastNotification.AddErrorToastMessage("Your email or password is incorrect!");

                return View(loginViewModel);

            }

            var loginResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, false);

            if (!loginResult.Succeeded)
            {
                _toastNotification.AddErrorToastMessage("Your email or password is incorrect!");

                return View(loginViewModel);
            }

            _toastNotification.AddSuccessToastMessage($"Welcome {user.FirstName}, you have successfully sign in to the application.");

            return RedirectToAction("Index", controllerName: "Students");
        }


    }



}