using System.ComponentModel.DataAnnotations;

namespace Week11_2.IdentityMVC.ViewModels
{
    public class AuthLoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
