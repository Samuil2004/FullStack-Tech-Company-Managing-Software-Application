using LogicLayer;
using MediaBazaarApp;
using MediaBazaarWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;

namespace MediaBazaarWeb.Pages
{
    public class SetPasswordPageModel : PageModel
    {
        UserManager um = new UserManager();
        PeopleManagement peopleManagement = new PeopleManagement();
        [BindProperty]
        public SetPasswordModel SetPasswordModel { get; set; }
        public string UserEmail { get; private set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                    if (userEmailClaim != null)
                    {
                        UserEmail = userEmailClaim.Value;
                        peopleManagement.ChangePassword(um.GetUserId(UserEmail), SetPasswordModel.ConfirmPassword);
                        um.MarkSuccessfullLogIn(UserEmail);
                        return RedirectToPage("Schedule", new { UserEmail, SetPasswordModel.ConfirmPassword });
                    }
                    return Page();
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
                return Page();
            }

        }
    }
}
