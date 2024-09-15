using System.ComponentModel.DataAnnotations;

namespace MediaBazaarWeb.Model
{
    /// <summary>
    /// A DTO model for the log in page including the requirements for each of the credentials
    /// </summary>
    public class LoginFormDTOModel
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
