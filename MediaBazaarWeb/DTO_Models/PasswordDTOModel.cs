using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MediaBazaarWeb.Model
{
    /// <summary>
    /// A DTO model used for updating user account password including the requirements for a strong password
    /// </summary>
    public class PasswordDTOModel
    {
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}
