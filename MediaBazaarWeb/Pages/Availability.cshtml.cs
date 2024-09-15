using Azure;
using MediaBazaarApp;
using MediaBazaarWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer;
using LogicLayer;
using System.Security.Claims;

namespace MediaBazaarWeb.Pages
{
    public class AvailabilityModel : PageModel
    {
        private const int DaysPerPage = 28; // 4 weeks * 7 days

        private readonly PeopleManagement peopleManager;
        private readonly AvailabilityManager availabilityManagement;


        public Person LoggedInPerson { get; set; }
        public bool IsAuthenticated { get; set; }

        [BindProperty]
        public List<DateTime> SelectedDates { get; set; } = new List<DateTime>();

        public string UserEmail { get; set; }
        public bool IsScheduleLocked { get; set; }

        public List<string> DatesList { get; set; } = new List<string>();
        public List<string> AvailabilitiesWorker { get; set; } = new List<string>();
        public List<string> IsWorking { get; set; } = new List<string>();

        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        public AvailabilityModel()
        {
            peopleManager = new PeopleManagement();
            availabilityManagement = new AvailabilityManager();
        }

        public IActionResult OnGet(int? pageIndex)
        {
            try
            {
                CurrentPage = pageIndex ?? 1;
                if (CurrentPage < 1)
                {
                    CurrentPage = 1;
                }

                ViewData["CurrentPage"] = CurrentPage;

                var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                if (userEmailClaim != null)
                {
                    UserEmail = userEmailClaim.Value;
                    IsAuthenticated = true;
                    LoggedInPerson = peopleManager.FindPerson(UserEmail);
                    if (LoggedInPerson != null)
                    {
                        DateTime now = DateTime.Now;
                        DateTime startOfWeek = now.AddDays(-(int)now.DayOfWeek);
                        DateTime lockEndDate = startOfWeek.AddDays(21);

                        ViewData["LockStartDate"] = startOfWeek;
                        ViewData["LockEndDate"] = lockEndDate;

                        IsScheduleLocked = true;
                        GenerateCalendar();
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
                        LoggedInPerson = peopleManager.FindPerson(UserEmail);

                        if (LoggedInPerson != null)
                        {
                            if (HttpContext.Session.TryGetValue("IsScheduleLocked", out var locked) &&
                                BitConverter.ToBoolean(locked, 0))
                            {
                                TempData["ErrorMessage"] = "The schedule is locked and cannot be changed.";
                                return RedirectToPage("/Availability");
                            }

                            List<DateTime> datesToRemove = new List<DateTime>();
                            List<DateTime> datesToAdd = new List<DateTime>();

                            foreach (var date in SelectedDates)
                            {
                                if (availabilityManagement.IsDateExist(LoggedInPerson.GetId(), date))
                                {
                                    datesToRemove.Add(date);
                                }
                                else
                                {
                                    datesToAdd.Add(date);
                                }
                            }

                            availabilityManagement.RemoveAvailability(LoggedInPerson.GetId(), datesToRemove);
                            AddAvailabilityForAllShifts(LoggedInPerson.GetId(), datesToAdd);
                        }
                    }
                    return RedirectToPage("/Availability");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"{ex.Message}";
                return Page();
            }
            return Page();
        }
        private void AddAvailabilityForAllShifts(int personId, List<DateTime> datesToAdd)
        {
            foreach (var date in datesToAdd)
            {
                availabilityManagement.AddAvailability(personId, date, AvailabilityForTheDay.FirstShift);
                availabilityManagement.AddAvailability(personId, date, AvailabilityForTheDay.SecondShift);
                availabilityManagement.AddAvailability(personId, date, AvailabilityForTheDay.ThirdShift);
            }
        }
        public void GenerateCalendar()
        {
            try
            {
                DatesList.Clear();
                AvailabilitiesWorker.Clear();
                IsWorking.Clear();

                DateTime startDate = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek + 1).AddDays((CurrentPage - 1) * DaysPerPage);

                for (int i = 0; i < DaysPerPage; i++)
                {
                    DatesList.Add(startDate.AddDays(i).ToString("yyyy-MM-dd"));
                    AvailabilitiesWorker.Add(startDate.AddDays(i).ToString("dd/MM/yy"));
                }

                var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                if (userEmailClaim != null)
                {
                    UserEmail = userEmailClaim.Value;
                    LoggedInPerson = peopleManager.FindPerson(UserEmail);
                    List<Availability> availabilities = new List<Availability>();

                    for (int i = 0; i < DaysPerPage; i++)
                    {
                        availabilities.Add(peopleManager.CheckUserAvailability(startDate.AddDays(i), LoggedInPerson.GetId()));
                    }

                    for (int i = 0; i < DaysPerPage; i++)
                    {
                        IsWorking.Add("NotWorking"); // Default value

                        foreach (Availability availability in availabilities)
                        {
                            DateTime shiftDate = availability.getTimeSlot();
                            if (DateOnly.FromDateTime(shiftDate) == DateOnly.FromDateTime(startDate.AddDays(i)))
                            {
                                if (availability.GetAvailability() == AvailabilityForTheDay.FirstShift ||
                                    availability.GetAvailability() == AvailabilityForTheDay.SecondShift ||
                                    availability.GetAvailability() == AvailabilityForTheDay.ThirdShift)
                                {
                                    IsWorking[i] = "Working";
                                }
                                else if (availability.GetAvailability() == AvailabilityForTheDay.Unavailable)
                                {
                                    IsWorking[i] = "NotWorking";
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
