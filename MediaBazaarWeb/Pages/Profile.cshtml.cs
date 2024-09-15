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
		PeopleManagement peopleManager = new PeopleManagement();
        public bool IsAuthenticated { get; set; }
        public Person LoggedInPerson { get; set; }

		[BindProperty(SupportsGet = true)]
		public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }
        public string UserEmail { get; set; }

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
					IsAuthenticated = true;
					LoggedInPerson = peopleManager.FindPerson(UserEmail);
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