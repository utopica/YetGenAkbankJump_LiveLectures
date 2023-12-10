using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Week11_Assignment.Persistence.API.Models.ModelMetaDataType
{
    [ModelMetadataType(typeof(BankAccountMetaData))]
    public class BankAccountMetaData
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name length can't be more than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name length can't be more than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone Number must contain only numbers")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Balance is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Balance must be a positive value")]
        public decimal Balance { get; set; }
    }
}
