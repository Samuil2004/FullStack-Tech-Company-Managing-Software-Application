using MediaBazaarApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using static Microsoft.Azure.Management.ResourceManager.Fluent.ResourceManager;
using DataAccessLayer;

namespace MediaBazaarWeb.Pages
{
    public class ResetPasswordModel : PageModel
    {
        public Person loggedInPerson { get; set; }
        public bool IsAuthenticated { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public PeopleManagement peopleManagement = new PeopleManagement();

        public SQLDatabase _sql;
        public IActionResult OnGet(string email)
        {
            Email = email;
            Email = TempData["Email"]?.ToString();
            Password = TempData["Password"]?.ToString();
            IsAuthenticated = true;
            return Page();
        }

        public IActionResult OnPost()
        {
            bool found = false;
            //foreach (Person p in peopleManagement.getAllPeople())
            //{
            //    if (p.getEmail() == Email)
            //    {
            //        loggedInPerson = p;
            //        found = true;
            //    }
            //}
            Person foundPerson = peopleManagement.FindPerson(Email);
            if (foundPerson != null)
            {
                loggedInPerson = foundPerson;
                found = true;
            }
            else
            {
                //ModelState.AddModelError(string.Empty, "Invalid secret question and answer");
                TempData["ErrorMessage"] = $"Invalid secret question and answer";

            }
            if (found)
            {
                try
                {
                    if (loggedInPerson != null)
                    {
                        peopleManagement.ChangePassword(loggedInPerson.GetId(), Password);
                        TempData["Email"] = Email;
                        TempData["Password"] = Password;
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage("Error");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"{ex.Message}";
                    return Page();
                }
            }
            return Page();
        }
    }
}
