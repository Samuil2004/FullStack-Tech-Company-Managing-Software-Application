using MediaBazaarApp;
using MediaBazaarWeb.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Claims;
using LogicLayer;
using DataAccessLayer;
namespace MediaBazaarWeb.Pages
{
    public class IndexModel : PageModel
    {
        DataAccessLayer.SQLDatabase _sql = new DataAccessLayer.SQLDatabase();
        UserManager um = new UserManager();
        [BindProperty]
        public LoginFormModel LoginForm { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Email;
        public string Password;

        public IActionResult OnGet()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToPage("Schedule");
                }
                IsAuthenticated = false;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                var email = LoginForm.Email;
                var password = LoginForm.Password;

                if (ModelState.IsValid)
                {
                    if (um.CheckUser(email, password))
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Email, LoginForm.Email));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                        if (um.IsUserLoggingINFortheFirstTime(email))
                        {
                            return new RedirectToPageResult("/SetPasswordPage");
                        }
                        return RedirectToPage("Schedule", new { email });
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Invalid email or password";
                        return Page();
                    }
                }
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
                return Page();
            }
        }
    }
}
