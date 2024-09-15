using MediaBazaarApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.Azure.Management.ResourceManager.Fluent.ResourceManager;
using System.Security.Claims;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc.Razor;
using MediaBazaarWeb.Model;

namespace MediaBazaarWeb.Pages
{
    public class AccountModel : PageModel
    {

        PeopleManagement peopleManager = new PeopleManagement();
        public bool IsAuthenticated { get; set; }
        public Person LoggedInPerson { get; set; }

        public string UserEmail { get; set; }

        [BindProperty]
        public EditAccountDetailsDTOModel editAccountDetails { get; set; }

        public IActionResult OnGet(string email)
        {
            try
            {
                var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                if (userEmailClaim != null)
                {
                    UserEmail = userEmailClaim.Value;
                    
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
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LoggedInPerson = peopleManager.FindPerson(editAccountDetails.Email);
                    string email = editAccountDetails.Email;
                    string phoneNumber = editAccountDetails.PhoneNumber;
                    string securityQuestion = editAccountDetails.SecurityQuestion;
                    string securityAnswer = editAccountDetails.SecurityAnswer;

                    peopleManager.UpdateUserDetails(LoggedInPerson.GetId(), email, phoneNumber, securityQuestion, securityAnswer);
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Invalid information.";
                }

                TempData["SuccessMessage"] = "Changes saved successfully.";
                return RedirectToPage("/Profile");
            }
            return Page();
        }
    }
}
