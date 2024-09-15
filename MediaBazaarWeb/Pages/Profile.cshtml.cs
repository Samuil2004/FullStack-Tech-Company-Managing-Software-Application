using MediaBazaarApp;
using MediaBazaarWeb.Model;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DataAccessLayer;
namespace MediaBazaarWeb.Pages
{
	public class ProfileModel : PageModel
	{
		SQLDatabase _sql = new SQLDatabase();
        public bool IsAuthenticated { get; set; }
        // Property to hold the logged-in person
        public Person LoggedInPerson { get; set; }

		[BindProperty(SupportsGet = true)]
		public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }
        public string UserEmail { get; set; }


        // Handler method for GET request
        public IActionResult OnGet(string email, string password)
		{
			try
			{
                var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
				if (userEmailClaim != null)
				{
					UserEmail = userEmailClaim.Value;

					Email = email;
					Password = password;
					// Find the logged-in person based on email and password
					IsAuthenticated = true;
					LoggedInPerson = _sql.FindPerson(UserEmail);
				}
				return Page();
			}
			catch (Exception ex)
			{
                TempData["ErrorMessage"] = $"I{ex.Message}";
                return Page();
            }
		}
	}
}