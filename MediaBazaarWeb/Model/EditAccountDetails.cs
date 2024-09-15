using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MediaBazaarWeb.Model
{
    public class EditAccountDetails
    {
        [BindProperty]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }
        [BindProperty]
        [Phone(ErrorMessage = "The PhoneNumber field is not a valid phone number.")]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public string SecurityQuestion { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "The SecurityAnswer field is required.")]
        public string SecurityAnswer { get; set; }
    }
}
