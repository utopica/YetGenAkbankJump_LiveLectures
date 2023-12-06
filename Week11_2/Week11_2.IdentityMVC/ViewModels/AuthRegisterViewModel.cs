using System.ComponentModel.DataAnnotations;
using Week10_1.Domain.Enums;
using Week10_1.Domain.Identity;

namespace Week11_2.IdentityMVC.ViewModels
{
    public class AuthRegisterViewModel
    {
        // what i need when registering
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTimeOffset? BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}
