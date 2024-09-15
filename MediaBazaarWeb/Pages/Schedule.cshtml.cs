using MediaBazaarApp;
using MediaBazaarWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Globalization;
using DataAccessLayer;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MediaBazaarWeb.Pages
{
    [Authorize]
    public class ScheduleModel : PageModel
    {
        [BindProperty]
        public ShiftChangeRequestDTOModel ShiftChangeRequest { get; set; }
        [BindProperty]
        public AvailabilitiesDTOModel AvailabilityModel { get; set; }
        private SQLDatabase _sql;
        private AvailabilityDataAccessLayer availabilitySQL;
        public bool IsAuthenticated { get; set; }
        public Person LoggedInPerson { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserEmail { get; set; }
        public string Password { get; set; }

        [BindProperty]
        public string SelectedShift { get; set; }
        public List<string> datesList = new List<string>();
        private PeopleManagement peopleManagement;
        public List<string> shifts = new List<string>();
        private int page;

        public ScheduleModel()
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
                    GenerateCalendar(page);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                IsAuthenticated = true;
                var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                if (userEmailClaim != null)
                {
                    UserEmail = userEmailClaim.Value;
                    IsAuthenticated = true;
                    LoggedInPerson = _sql.FindPerson(UserEmail);
                }
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
                return Page();
            }
        }
        public List<Tuple<string, DateTime, AvailabilityForTheDay>> GetPossibleShiftChanges()
        {
            try
            {
                var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                if (userEmailClaim != null)
                {
                    UserEmail = userEmailClaim.Value;
                    LoggedInPerson = _sql.FindPerson(UserEmail);

                    if (LoggedInPerson != null)
                    {
                        return availabilitySQL.GetPossibleShiftChanges(LoggedInPerson.GetId());
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
            }
            return null;
        }
        public IActionResult OnPostTakeShift(int itemIndex)
        {
            try
            {
                var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                if (userEmailClaim != null)
                {
                    UserEmail = userEmailClaim.Value;
                    LoggedInPerson = _sql.FindPerson(UserEmail);
                    Tuple<string, DateTime, AvailabilityForTheDay> item = GetPossibleShiftChanges()[itemIndex];
                    availabilitySQL.AddAvailability(LoggedInPerson.GetId(),item.Item3,item.Item2,true);
                    availabilitySQL.DeleteShiftTransferRequest(_sql.FindPerson(item.Item1).GetId(), item.Item2, item.Item3);
                }
                return RedirectToPage("/Schedule");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
            }
            return RedirectToPage("/Schedule");
        }
        public async void OnPostChangePageAsync(int i)
        {
            try
            {
                var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                if (userEmailClaim != null)
                {
                    UserEmail = userEmailClaim.Value;
                    page = Convert.ToInt32(TempData.Peek("page"));
                    page += i;
                    TempData["page"] = page;
                    IsAuthenticated = true;
                    LoggedInPerson = _sql.FindPerson(UserEmail);
                    GenerateCalendar(page);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
            }
        }

        public IActionResult OnPostRequestChange()
        {
            try
            {
                var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                if (userEmailClaim != null)
                {
                    UserEmail = userEmailClaim.Value;
                    LoggedInPerson = _sql.FindPerson(UserEmail);

                    if (LoggedInPerson == null)
                    {
                        TempData["ErrorMessage"] = "Logged in person not found.";
                        return Page();
                    }

                    if (!string.IsNullOrEmpty(ShiftChangeRequest.SelectedShift) && !string.IsNullOrEmpty(ShiftChangeRequest.Reason))
                    {
                        string[] parts = ShiftChangeRequest.SelectedShift.Split(' ');
                        DateTime date = DateTime.ParseExact(parts[0], "dd/MM/yy", CultureInfo.InvariantCulture);
                        AvailabilityForTheDay shift;

                        if (parts[1].ToString().Equals(AvailabilityForTheDay.FirstShift.ToString()))
                        {
                            shift = AvailabilityForTheDay.FirstShift;
                        }
                        else if (parts[1].ToString().Equals(AvailabilityForTheDay.SecondShift.ToString()))
                        {
                            shift = AvailabilityForTheDay.SecondShift;
                        }
                        else
                        {
                            shift = AvailabilityForTheDay.ThirdShift;
                        }

                        bool requestExists = availabilitySQL.CheckExistingRequest(LoggedInPerson.GetId(), shift, date);
                        ViewData["RequestExists"] = requestExists;

                        if (requestExists)
                        {
                            TempData["ErrorMessage"] = "A shift transfer request already exists for this person on the specified date and shift.";
                            return Page();
                        }

                        availabilitySQL.RequestTransfer(LoggedInPerson.GetId(), shift, date, ShiftChangeRequest.Reason);

                        TempData["SuccessMessage"] = "Shift change request submitted successfully.";
                        return RedirectToPage("/Schedule");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Please select a shift and provide a reason to request a change.";
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "User email claim not found.";
                }

                return Page();
            }
            catch (Exception ex)    
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
                return Page();
            }
        }

        public void GenerateCalendar(int page)
        {
            try
            {
                for (int i = 0; i < 21; i++)
                {
                    shifts.Add("");
                }

                DateTime monday = DateTime.Now.AddDays((-(int)DateTime.Now.DayOfWeek + 1) + 7 * page);
                datesList.Add($"{monday:dd/MM/yy}");
                datesList.Add($"{monday.AddDays(1):dd/MM/yy}");
                datesList.Add($"{monday.AddDays(2):dd/MM/yy}");
                datesList.Add($"{monday.AddDays(3):dd/MM/yy}");
                datesList.Add($"{monday.AddDays(4):dd/MM/yy}");
                datesList.Add($"{monday.AddDays(5):dd/MM/yy}");
                datesList.Add($"{monday.AddDays(6):dd/MM/yy}");

                List<Availability> availabilities = peopleManagement.GetUserAvailability(monday, monday.AddDays(6), LoggedInPerson.ID);

                DateTime today = DateTime.Today;
                foreach (Availability availability in availabilities)
                {
                    if (availability.isPersonTaken())
                    {
                        DateTime shiftDate = availability.getTimeSlot();
                        for (int i = 0; i < 7; i++)
                        {
                            if (DateOnly.FromDateTime(shiftDate) == DateOnly.FromDateTime(monday.AddDays(i)))
                            {
                                bool isRequested = availabilitySQL.CheckExistingRequest(LoggedInPerson.GetId(), availability.GetAvailability(), shiftDate);
                                string shiftClass = isRequested ? "Requested" : "Working";

                                if (shiftDate <= today)
                                {
                                    shiftClass = "Locked";
                                }

                                if (availability.GetAvailability() == AvailabilityForTheDay.FirstShift)
                                {
                                    shifts[i] = shiftClass;
                                }
                                else if (availability.GetAvailability() == AvailabilityForTheDay.SecondShift)
                                {
                                    shifts[i + 7] = shiftClass;
                                }
                                else if (availability.GetAvailability() == AvailabilityForTheDay.ThirdShift)
                                {
                                    shifts[i + 14] = shiftClass;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
            }
        }

    }
}
