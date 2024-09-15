using LogicLayer;
using MediaBazaarApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using static System.Net.Mime.MediaTypeNames;
using DataAccessLayer;
namespace MediaBazaarWeb.Pages
{
    public class ForgottenPasswordModel : PageModel
    {
        public UserManager _userManager;

        public DataAccessLayer.SQLDatabase _sql;
        public Person LoggedInPerson { get; set; }
        PeopleManagement peopleManagement = new PeopleManagement();
        public bool IsAuthenticated { get; set; }

        [BindProperty]
        public DateTime SelectedDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty]
        public string SelectedSecretQuestionOption { get; set; }

        [BindProperty]
        public string SecretAnswer { get; set; }

        public ForgottenPasswordModel()
        {
            _sql = new DataAccessLayer.SQLDatabase();
        }
        public IActionResult OnGet(string email)
        {
            Email = email;
            Email = TempData["Email"]?.ToString();
            IsAuthenticated = true;
            return Page();
        }
        public IActionResult OnPost()
        {
            try
            {
                var selectedOption = Request.Form["SecretQuestionOptions"];
                bool found = false;
                //foreach (Person p in peopleManagement.getAllPeople())
                //{
                //    if (p.getEmail() == Email)
                //    {
                //        LoggedInPerson = p;
                //        found = true;
                //    }
                //}
                Person foundPerson = peopleManagement.FindPerson(Email);
                if (foundPerson != null)
                {
                    LoggedInPerson = foundPerson;
                    found = true;
                }
                else
                {
                    //ModelState.AddModelError(string.Empty, "Invalid secret question and answer");
                    TempData["ErrorMessage"] = $"Invalid secret question and answer";

                }
                if (found)
                {
                    if (LoggedInPerson != null && LoggedInPerson.SecretQuestion == selectedOption && LoggedInPerson.SecretAnswer == SecretAnswer)
                    {
                        TempData["Email"] = Email;
                        return RedirectToPage("ResetPassword", new { email = LoggedInPerson.Email });
                    }
                    else
                    {
                        //ModelState.AddModelError(string.Empty, "Invalid secret question and answer");
                        TempData["ErrorMessage"] = $"Invalid secret question and answer";
                        return Page();
                    }

                }
                return Page();
            }
            catch(Exception ex)
            {
                //ModelState.AddModelError(string.Empty,ex.Message);
                TempData["ErrorMessage"] = $"An error occured: {ex.Message}";
                return Page();
            }

        }
    }
}
