using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.Azure.Management.ResourceManager.Fluent.ResourceManager;
using System.Security.Claims;
using DataAccessLayer;
using MediaBazaarApp;
using MediaBazaarWeb.Model;

namespace MediaBazaarWeb.Pages
{
    public class ShiftRequestsModel : PageModel
    {
        [BindProperty]
        public AvailabilitiesDTOModel AvailabilityModel { get; set; }
        private SQLDatabase _sql;
        private AvailabilityDataAccessLayer availabilitySQL;
        public bool IsAuthenticated { get; set; }
        public Person LoggedInPerson { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserEmail { get; set; }
        public string Password { get; set; }
        
        private PeopleManagement peopleManagement;
        private int page;

        public ShiftRequestsModel()
        {
            _sql = new SQLDatabase();
            peopleManagement = new PeopleManagement();
            availabilitySQL = new AvailabilityDataAccessLayer();
        }
        public void OnGet()
        {
            try
            {
                IsAuthenticated = true;
                var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                if (userEmailClaim != null)
                {
                    UserEmail = userEmailClaim.Value;
                    LoggedInPerson = _sql.FindPerson(UserEmail);
                    TempData["email"] = UserEmail;
                    TempData["password"] = Password;
                    TempData["page"] = page;
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
            }
        }
    }
}
