using Microsoft.Azure.Management.Network.Fluent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DataAccessLayer;
using ClassLibrary;
using Microsoft.Azure.Management.Network.Fluent;
using System.Windows.Documents;

namespace MediaBazaarApp
{
    public partial class ManagerSchedulePlanner : Form
    {
        PeopleManagement peopleManager;
        ManagerManageShdeule managerManageShdeule;
        Person loggedInUser;
        private bool close_application;
        SQLDatabase database;
        AvailabilitySQL availabilitySQL;
        private Random random = new Random();
        private int numOfWeeks;
        private Department selectedDepartment;
        private Availability selectedAvailability;
        private Person selected_personDrag;
        //public List<EmployeeNumberChange> changesForNumOfEmployees;
        //public BackgroundWorker backgroundWorker1;

        //List<Tuple<DateTime, Department, Role, AvailabilityForTheDay>> shiftShortageStorage;

        //private List<DateTime> datesWithMissingPeople;

        public ManagerSchedulePlanner(PeopleManagement peopleManager, ManagerManageShdeule managerManageShdeule, Person loggedInUser, SQLDatabase database)
        {
            try
            {
                this.peopleManager = peopleManager;
                this.managerManageShdeule = managerManageShdeule;
                this.loggedInUser = loggedInUser;
                InitializeComponent();
                //backgroundWorker1 = new BackgroundWorker();

                //InitializeBackgroundWorker();

                //this.shiftShortageStorage = new Tuple<DateTime, Department, Role, AvailabilityForTheDay>();
                //lbAvailableMemebersFirstShift.DragDrop += new DragEventHandler(lbAvailableMemebersFirstShift_DragDrop_1);
                //shiftShortageStorage = new List<Tuple<DateTime, Department, Role, AvailabilityForTheDay>>();
                //CheckLoggedInUser();
                close_application = true;
                this.database = database;
                availabilitySQL = new AvailabilitySQL();
                rbGenerateDaySchedule.Checked = true;
                cbWeeksRange.SelectedIndex = 2;
                this.numOfWeeks = Convert.ToInt32(cbWeeksRange.SelectedItem);

                //changesForNumOfEmployees = new List<EmployeeNumberChange>();
                cbDepartment.Items.Add(loggedInUser.GetDepartment.ToString());
                //foreach (Department department in Enum.GetValues(typeof(Department)))
                //{
                //    if (department != Department.Owners)
                //    {
                //        cbDepartment.Items.Add(department);
                //        if(department.Equals(loggedInUser.))
                //    }
                //}
                calendar.MinDate = DateTime.Today;
                CheckLoggedInUser();
                btnGenerateSchedule.Visible = true;
                lbDayPlannerFirstShift.AllowDrop = true;
                lbDayPlannerFirstShift.DragDrop += lbDayPlannerFirstShift_DragDrop;
                lbDayPlannerFirstShift.DragEnter += lbDayPlannerFirstShift_DragEnter;

                lbAvailableMemebersFirstShift.AllowDrop = true;
                //lbAvailableMemebersFirstShift.DragDrop += lbAvailableMemebersFirstShift_DragDrop_1;
                //lbAvailableMemebersFirstShift.DragEnter += lbAvailableMemebersFirstShift_DragEnter;

                lbDayPlannerSecondShift.AllowDrop = true;
                lbDayPlannerSecondShift.DragDrop += lbDayPlannerSecondShift_DragDrop;
                lbDayPlannerSecondShift.DragEnter += lbDayPlannerSecondShift_DragEnter;

                lbAvailableMembersSecondShift.AllowDrop = true;
                //lbAvailableMembersSecondShift.DragDrop += lbAvailableMembersSecondShift_DragDrop;
                //lbAvailableMembersSecondShift.DragEnter += lbAvailableMembersSecondShift_DragEnter;

                lbDayPlannerThirdShift.AllowDrop = true;
                lbDayPlannerThirdShift.DragDrop += lbDayPlannerThirdShift_DragDrop;
                lbDayPlannerThirdShift.DragEnter += lbDayPlannerThirdShift_DragEnter;

                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Subscribe to the DrawItem event
            //lbAvailableMembersFirstShift.DrawItem += new DrawItemEventHandler(lbAvailableMembersFirstShift_DrawItem);


            //lbAvailableMemebersFirstShift.MouseDown += lbAvailableMemebersFirstShift_MouseDown;

            //UpdateDataPlannerPage(GetUpcomingSunday(DateTime.Today.AddDays(14)));

        }


        private void CheckLoggedInUser()
        {
            //cbDepartment.Items.Add(loggedInUser.GetDepartment);
            cbDepartment.SelectedIndex = 0;
            cbDepartment.Enabled = false;
            cbRole.Visible = true;
            labelRole.Visible = true;
            cbDepartment.Visible = false;
            labelDepartment.Visible = false;
        }

        private void cbSelectDatePlanner_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateAvailabilityData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateAvailabilityData()
        {
            try
            {
                lbAvailableMembersSecondShift.Items.Clear();
                lbAvailableMemebersFirstShift.Items.Clear();
                lbAvailableMembersThirdShift.Items.Clear();
                lbDayPlannerFirstShift.Items.Clear();
                lbDayPlannerSecondShift.Items.Clear();
                lbDayPlannerThirdShift.Items.Clear();
                DateTime selectedTime = calendar.SelectionStart;
                labelSelectedDayAndDate.Text = $"{selectedTime.DayOfWeek} - {selectedTime.ToString("dd/MM")}";
                Department seleced_department = (Department)Enum.Parse(typeof(Department), cbDepartment.SelectedItem.ToString());
                IEnumerable<Availability> allEmployeesInTheDepartment;

                Role selected_role = (Role)Enum.Parse(typeof(Role), cbRole.SelectedItem.ToString());

                foreach (Availability availability in availabilitySQL.GetAvailabilityForPlannerPage(calendar.SelectionStart.Date, selected_role, seleced_department))
                {
                    if (!availability.isPersonTaken())
                    {
                        if (availability.GetAvailability().Equals(AvailabilityForTheDay.FirstShift))
                        {
                            lbAvailableMemebersFirstShift.Items.Add(availability.getPerson().GetShortInfo());
                        }
                        else if (availability.GetAvailability().Equals(AvailabilityForTheDay.SecondShift))
                        {
                            lbAvailableMembersSecondShift.Items.Add(availability.getPerson().GetShortInfo());
                        }
                        else if (availability.GetAvailability().Equals(AvailabilityForTheDay.ThirdShift))
                        {
                            lbAvailableMembersThirdShift.Items.Add(availability.getPerson().GetShortInfo());
                        }
                    }
                    else if (availability.isPersonTaken())
                    {
                        if (availability.GetAvailability().Equals(AvailabilityForTheDay.FirstShift))
                        {
                            lbDayPlannerFirstShift.Items.Add(availability.getPerson().GetShortInfo());
                        }
                        else if (availability.GetAvailability().Equals(AvailabilityForTheDay.SecondShift))
                        {
                            lbDayPlannerSecondShift.Items.Add(availability.getPerson().GetShortInfo());
                        }
                        else if (availability.GetAvailability().Equals(AvailabilityForTheDay.ThirdShift))
                        {
                            lbDayPlannerThirdShift.Items.Add(availability.getPerson().GetShortInfo());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //foreach(var item in lbAvailableMemebersFirstShift.Items)
            //{
            //    if(lbDayPlannerThirdShift.Items.Contains(item))
            //    {
            //    }
            //}
        }
        //private void lbAvailableMemebersFirstShift_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    // Check if the index is valid
        //    if (e.Index < 0)
        //        return;

        //    // Get the ListBox and the item
        //    ListBox listBox = (ListBox)sender;
        //    string item = (string)listBox.Items[e.Index];

        //    // Determine the background color
        //    Color backgroundColor;
        //    if (e.Index % 2 == 0) // Example condition to change the background color
        //    {
        //        backgroundColor = Color.LightBlue;
        //    }
        //    else
        //    {
        //        backgroundColor = Color.LightGreen;
        //    }

        //    // Draw the background
        //    e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

        //    // Draw the text
        //    TextRenderer.DrawText(e.Graphics, item, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.Left);

        //    // Draw focus rectangle if the item has focus
        //    e.DrawFocusRectangle();
        //}
        private void lbAvailableMembersFirstShift_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if (e.Index < 0)
                    return;

                ListBox listBox = (ListBox)sender;
                string item = (string)listBox.Items[e.Index];

                Color backgroundColor;
                if (lbDayPlannerThirdShift.Items.Contains(item))
                {
                    backgroundColor = Color.LightGray;
                }
                else
                {
                    backgroundColor = e.BackColor;
                }

                e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

                TextRenderer.DrawText(e.Graphics, item, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.Left);

                e.DrawFocusRectangle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lbAvailableMembersThirdShift_DrawItem(object sender, DrawItemEventArgs e)
        {

            try
            {
                if (e.Index < 0)
                    return;

                ListBox listBox = (ListBox)sender;
                string item = (string)listBox.Items[e.Index];

                Color backgroundColor;
                if (lbDayPlannerFirstShift.Items.Contains(item))
                {
                    backgroundColor = Color.LightGray;
                }
                else
                {
                    backgroundColor = e.BackColor;
                }

                e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

                TextRenderer.DrawText(e.Graphics, item, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.Left);

                e.DrawFocusRectangle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static DateTime GetUpcomingSunday(DateTime dateOfReference)
        {
            int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)dateOfReference.DayOfWeek + 7) % 7;
            return dateOfReference.AddDays(daysUntilSunday);
        }
        static DateTime GetLastMonday(DateTime dateOfReference)
        {
            int daysUntilMonday = ((int)dateOfReference.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            return dateOfReference.AddDays(-daysUntilMonday);
        }
        private void btnAddPersonToShift_Click(object sender, EventArgs e)
        {
            try
            {
                Availability selectedAvailability;
                if (lbAvailableMemebersFirstShift.SelectedItem != null)
                {
                    //Person selected_person = database.TakeAllCurrentlyWorkingPeople().FirstOrDefault(p => p.GetShortInfo().Equals(lbAvailableMemebersFirstShift.SelectedItem.ToString()));
                    Person selected_person = peopleManager.FindConcretePerson(lbAvailableMemebersFirstShift.SelectedItem.ToString());
                    Availability av = availabilitySQL.FindAvailability(selected_person, calendar.SelectionStart.Date, AvailabilityForTheDay.FirstShift);
                    availabilitySQL.ChangeIsTaken(av, selected_person.GetId(), calendar.SelectionStart, AvailabilityForTheDay.FirstShift);
                }
                else if (lbAvailableMembersSecondShift.SelectedItem != null)
                {
                    //Person selected_person = database.TakeAllCurrentlyWorkingPeople().FirstOrDefault(p => p.GetShortInfo().Equals(lbAvailableMembersSecondShift.SelectedItem.ToString()));
                    Person selected_person = peopleManager.FindConcretePerson(lbAvailableMembersSecondShift.SelectedItem.ToString());
                    Availability av = availabilitySQL.FindAvailability(selected_person, calendar.SelectionStart.Date, AvailabilityForTheDay.SecondShift);
                    availabilitySQL.ChangeIsTaken(av, selected_person.GetId(), calendar.SelectionStart, AvailabilityForTheDay.SecondShift);
                }
                else if (lbAvailableMembersThirdShift.SelectedItem != null)
                {
                    //Person selected_person = database.TakeAllCurrentlyWorkingPeople().FirstOrDefault(p => p.GetShortInfo().Equals(lbAvailableMembersThirdShift.SelectedItem.ToString()));
                    Person selected_person = peopleManager.FindConcretePerson(lbAvailableMembersThirdShift.SelectedItem.ToString());
                    Availability av = availabilitySQL.FindAvailability(selected_person, calendar.SelectionStart.Date, AvailabilityForTheDay.ThirdShift);
                    availabilitySQL.ChangeIsTaken(av, selected_person.GetId(), calendar.SelectionStart, AvailabilityForTheDay.ThirdShift);
                }
                UpdateAvailabilityData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemovePersonFromShift_Click(object sender, EventArgs e)
        {
            try
            {
                Availability selectedAvailability;
                if (lbDayPlannerFirstShift.SelectedItem != null)
                {
                    //Person selected_person = database.TakeAllCurrentlyWorkingPeople().FirstOrDefault(p => p.GetShortInfo().Equals(lbDayPlannerFirstShift.SelectedItem.ToString()));
                    Person selected_person = peopleManager.FindConcretePerson(lbDayPlannerFirstShift.SelectedItem.ToString());
                    Availability av = availabilitySQL.FindAvailability(selected_person, calendar.SelectionStart.Date, AvailabilityForTheDay.FirstShift);
                    availabilitySQL.ChangeIsTaken(av, selected_person.GetId(), calendar.SelectionStart, AvailabilityForTheDay.FirstShift);
                }
                else if (lbDayPlannerSecondShift.SelectedItem != null)
                {
                    //Person selected_person = database.TakeAllCurrentlyWorkingPeople().FirstOrDefault(p => p.GetShortInfo().Equals(lbDayPlannerSecondShift.SelectedItem.ToString()));
                    Person selected_person = peopleManager.FindConcretePerson(lbDayPlannerSecondShift.SelectedItem.ToString());
                    Availability av = availabilitySQL.FindAvailability(selected_person, calendar.SelectionStart.Date, AvailabilityForTheDay.SecondShift);
                    availabilitySQL.ChangeIsTaken(av, selected_person.GetId(), calendar.SelectionStart, AvailabilityForTheDay.SecondShift);

                }
                else if (lbDayPlannerThirdShift.SelectedItem != null)
                {
                    //Person selected_person = database.TakeAllCurrentlyWorkingPeople().FirstOrDefault(p => p.GetShortInfo().Equals(lbDayPlannerThirdShift.SelectedItem.ToString()));
                    Person selected_person = peopleManager.FindConcretePerson(lbDayPlannerThirdShift.SelectedItem.ToString());
                    Availability av = availabilitySQL.FindAvailability(selected_person, calendar.SelectionStart.Date, AvailabilityForTheDay.ThirdShift);
                    availabilitySQL.ChangeIsTaken(av, selected_person.GetId(), calendar.SelectionStart, AvailabilityForTheDay.ThirdShift);
                }
                UpdateAvailabilityData();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                availabilitySQL.ClearSchedule(calendar.SelectionStart);
                UpdateAvailabilityData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private async void GenerateDayScheduleForCertainRole(Role selected_role)
        //{
        //    try
        //    {
        //        Department seleced_department = (Department)Enum.Parse(typeof(Department), cbDepartment.SelectedItem.ToString());
        //        int neededEmployees = 3;
        //        var shuffledEmployees = dataManager.GetAvailabilityForScheduleGenerator(Convert.ToDateTime(calendar.SelectionStart.Date), selected_role, seleced_department).OrderBy(x => random.Next());
        //        if (seleced_department == Department.Sales && selected_role == Role.Floor_Consultant)
        //        {
        //            if (calendar.SelectionStart.DayOfWeek == DayOfWeek.Saturday || calendar.SelectionStart.DayOfWeek == DayOfWeek.Sunday)
        //            {
        //                neededEmployees = 20;
        //            }
        //            else
        //            {
        //                neededEmployees = 15;
        //            }
        //        }
        //        if (selected_role == Role.Manager)
        //        {
        //            neededEmployees = 1;
        //        }
        //        //foreach (Availability availability in shuffledEmployees)
        //        //{
        //        //    try
        //        //    {

        //        //        if (availability.GetAvailability().Equals(AvailabilityForTheDay.FirstShift) && lbDayPlannerFirstShift.Items.Count < neededEmployees)
        //        //        {
        //        //            lbDayPlannerFirstShift.Items.Add(availability.getPerson().GetShortInfo());
        //        //            availabilitySQL.ChangeIsTaken(availability, 0, calendar.SelectionStart, AvailabilityForTheDay.FirstShift);
        //        //        }
        //        //        else if (availability.GetAvailability().Equals(AvailabilityForTheDay.SecondShift) && lbDayPlannerSecondShift.Items.Count < neededEmployees)
        //        //        {
        //        //            lbDayPlannerSecondShift.Items.Add(availability.getPerson().GetShortInfo());
        //        //            availabilitySQL.ChangeIsTaken(availability, 0, calendar.SelectionStart, AvailabilityForTheDay.SecondShift);
        //        //        }
        //        //        else if (availability.GetAvailability().Equals(AvailabilityForTheDay.ThirdShift) && lbDayPlannerThirdShift.Items.Count < neededEmployees)
        //        //        {
        //        //            lbDayPlannerThirdShift.Items.Add(availability.getPerson().GetShortInfo());
        //        //            availabilitySQL.ChangeIsTaken(availability, 0, calendar.SelectionStart, AvailabilityForTheDay.ThirdShift);
        //        //        }
        //        //        else if (lbDayPlannerFirstShift.Items.Count == neededEmployees && lbDayPlannerSecondShift.Items.Count == neededEmployees && lbDayPlannerThirdShift.Items.Count == neededEmployees)
        //        //        {
        //        //            break;
        //        //        }
        //        //    }
        //        //    catch (Exception ex)
        //        //    {
        //        //        MessageBox.Show(ex.Message);
        //        //    }
        //        //}

        //        foreach (Availability availability in shuffledEmployees)
        //        {
        //            try
        //            {
        //                Dictionary<int, int> shiftsAssignedPerDay = availabilitySQL.GetShiftsAssignedPerDay(calendar.SelectionStart);

        //                if (!shiftsAssignedPerDay.ContainsKey(availability.getPerson().GetId()))
        //                {
        //                    shiftsAssignedPerDay.Add(availability.getPerson().GetId(), 0);
        //                }
        //                if(shiftsAssignedPerDay[availability.getPerson().GetId()] == 0)
        //                {
        //                    if (availability.GetAvailability().Equals(AvailabilityForTheDay.FirstShift) && lbDayPlannerFirstShift.Items.Count < neededEmployees)
        //                    {
        //                        lbDayPlannerFirstShift.Items.Add(availability.getPerson().GetShortInfo());
        //                        availabilitySQL.ChangeIsTaken(availability, 0, calendar.SelectionStart, AvailabilityForTheDay.FirstShift);
        //                    }
        //                    else if (availability.GetAvailability().Equals(AvailabilityForTheDay.SecondShift) && lbDayPlannerSecondShift.Items.Count < neededEmployees)
        //                    {
        //                        lbDayPlannerSecondShift.Items.Add(availability.getPerson().GetShortInfo());
        //                        availabilitySQL.ChangeIsTaken(availability, 0, calendar.SelectionStart, AvailabilityForTheDay.SecondShift);
        //                    }
        //                    else if (availability.GetAvailability().Equals(AvailabilityForTheDay.ThirdShift) && lbDayPlannerThirdShift.Items.Count < neededEmployees)
        //                    {
        //                        lbDayPlannerThirdShift.Items.Add(availability.getPerson().GetShortInfo());
        //                        availabilitySQL.ChangeIsTaken(availability, 0, calendar.SelectionStart, AvailabilityForTheDay.ThirdShift);
        //                    }
        //                    else if (lbDayPlannerFirstShift.Items.Count == neededEmployees && lbDayPlannerSecondShift.Items.Count == neededEmployees && lbDayPlannerThirdShift.Items.Count == neededEmployees)
        //                    {
        //                        break;
        //                    }
        //                }
        //                else if (shiftsAssignedPerDay[availability.getPerson().GetId()] < 2)
        //                {
        //                    AvailabilityForTheDay existingShift = GetExistingShiftForPerson(availability.getPerson().GetId(), calendar.SelectionStart.Date);
        //                    if (IsShiftCompatible(existingShift, availability.GetAvailability()))
        //                    {
        //                        if (availability.GetAvailability().Equals(AvailabilityForTheDay.FirstShift) && lbDayPlannerFirstShift.Items.Count < neededEmployees)
        //                        {
        //                            lbDayPlannerFirstShift.Items.Add(availability.getPerson().GetShortInfo());
        //                            availabilitySQL.ChangeIsTaken(availability, 0, calendar.SelectionStart, AvailabilityForTheDay.FirstShift);
        //                        }
        //                        else if (availability.GetAvailability().Equals(AvailabilityForTheDay.SecondShift) && lbDayPlannerSecondShift.Items.Count < neededEmployees)
        //                        {
        //                            lbDayPlannerSecondShift.Items.Add(availability.getPerson().GetShortInfo());
        //                            availabilitySQL.ChangeIsTaken(availability, 0, calendar.SelectionStart, AvailabilityForTheDay.SecondShift);
        //                        }
        //                        else if (availability.GetAvailability().Equals(AvailabilityForTheDay.ThirdShift) && lbDayPlannerThirdShift.Items.Count < neededEmployees)
        //                        {
        //                            lbDayPlannerThirdShift.Items.Add(availability.getPerson().GetShortInfo());
        //                            availabilitySQL.ChangeIsTaken(availability, 0, calendar.SelectionStart, AvailabilityForTheDay.ThirdShift);
        //                        }
        //                        else if (lbDayPlannerFirstShift.Items.Count == neededEmployees && lbDayPlannerSecondShift.Items.Count == neededEmployees && lbDayPlannerThirdShift.Items.Count == neededEmployees)
        //                        {
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }
        //        }
        //        if (lbDayPlannerFirstShift.Items.Count < neededEmployees)
        //        {
        //            MessageBox.Show("There aren't enough people \nfor first shift!");
        //        }
        //        if(lbDayPlannerSecondShift.Items.Count < neededEmployees)
        //        {
        //            MessageBox.Show("There aren't enough people \nfor second shift!");
        //        }
        //        if(lbDayPlannerThirdShift.Items.Count < neededEmployees)
        //        {
        //            MessageBox.Show("There aren't enough people \nfor third shift!");
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //private bool IsShiftCompatible(AvailabilityForTheDay existingShift, AvailabilityForTheDay newShift)
        //{
        //    //if(existingShift == null)
        //    //{
        //    //    return true;
        //    //}
        //    // Check if the new shift is compatible with the existing one
        //    if ((existingShift == AvailabilityForTheDay.FirstShift && newShift == AvailabilityForTheDay.ThirdShift)||(existingShift == AvailabilityForTheDay.ThirdShift && newShift == AvailabilityForTheDay.FirstShift))
        //    {
        //        // First and third shifts are not compatible
        //        return false;
        //    }
        //    // Add other compatibility checks if needed
        //    return true;
        //}
        //private AvailabilityForTheDay GetExistingShiftForPerson(int personId, DateTime date)
        //{
        //    try
        //    {
        //        //string shift = availabilitySQL.GetAssignedShift(personId, date);
        //        //if(string.IsNullOrEmpty(shift))
        //        //{
        //        //    return null;
        //        //}
        //        //AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), shift);

        //        //return selected_availability; // Placeholder, replace with actual logic
        //        return availabilitySQL.GetAssignedShift(personId, date);
        //    }
        //    catch(Exception ex)
        //    {
        //        throw;
        //    }
        //}


        private void GenerateWeekScheduleForACertainRole2(Role selected_role, DateTime startDate, DateTime upcomingSunday)
        {
            try
            {
                for (DateTime date = startDate; date <= upcomingSunday; date = date.AddDays(1))
                {
                    foreach (AvailabilityForTheDay shift in Enum.GetValues(typeof(AvailabilityForTheDay)))
                    {
                        int neededEmployees = 3;
                        if (availabilitySQL.ReadSpecialShiftsDays(date, selectedDepartment, selected_role, shift) != -1)
                        {
                            neededEmployees = availabilitySQL.ReadSpecialShiftsDays(date, selectedDepartment, selected_role, shift);
                        }
                        else if (selectedDepartment == Department.Sales && selected_role == Role.Floor_Consultant)
                        {
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {
                                neededEmployees = 20;
                            }
                            else
                            {
                                neededEmployees = 15;
                            }
                        }
                        else if (selected_role == Role.Manager)
                        {
                            neededEmployees = 1;
                        }
                        if (shift.Equals(AvailabilityForTheDay.Unavailable))
                        {
                            continue;
                        }
                        int counter = availabilitySQL.GetNumOfAssignedShifts(selected_role, selectedDepartment, date, shift);
                        if (counter <= neededEmployees)
                        {
                            List<Availability> peopleToBeAssigned = availabilitySQL.GetPossiblePeopleToBeAssigned(neededEmployees - counter, selected_role, selectedDepartment, date, shift);

                            foreach (var person in peopleToBeAssigned)
                            {
                                availabilitySQL.ChangeIsTaken(person, 0, date, shift);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CheckForShiftShortages()
        {
            try
            {
                ClearListBox();
                for (DateTime date = DateTime.Today; date <= GetUpcomingSunday(DateTime.Today).AddDays(4 * 7); date = date.AddDays(1))
                {
                    foreach (var role in cbRole.Items)
                    {
                        foreach (AvailabilityForTheDay availability in Enum.GetValues(typeof(AvailabilityForTheDay)))
                        {
                            if (availability != AvailabilityForTheDay.Unavailable)
                            {
                                Role selectedRole = (Role)Enum.Parse(typeof(Role), role.ToString());
                                Department selectedDepartment = loggedInUser.GetDepartment;
                                int alreadyAssinged = availabilitySQL.GetNumOfAssignedShifts(selectedRole, selectedDepartment, date, availability);
                                int toBeAssigned = 3;
                                if (availabilitySQL.ReadSpecialShiftsDays(date, selectedDepartment, selectedRole, availability) != -1)
                                {
                                    toBeAssigned = availabilitySQL.ReadSpecialShiftsDays(date, selectedDepartment, selectedRole, availability);
                                }
                                else if (selectedDepartment == Department.Sales && selectedRole == Role.Floor_Consultant)
                                {
                                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                    {
                                        toBeAssigned = 20;
                                    }
                                    else
                                    {
                                        toBeAssigned = 15;
                                    }
                                }
                                else if (selectedRole == Role.Manager)
                                {
                                    toBeAssigned = 1;
                                }
                                else
                                {
                                    toBeAssigned = 3;
                                }

                                if (alreadyAssinged < toBeAssigned)
                                {
                                    string message = $"There aren't enough people on {date.ToString("dd/MM")} for {selectedDepartment} - {selectedRole} for {availability} shift!";
                                    UpdateListBox(message);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateListBox(string message)
        {
            try
            {
                if (lbNotes.InvokeRequired)
                {
                    lbNotes.BeginInvoke(new Action(() =>
                    {
                        lbNotes.Items.Add(message);
                    }));
                }
                else
                {
                    lbNotes.Items.Add(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearListBox()
        {
            try
            {
                if (lbNotes.InvokeRequired)
                {
                    lbNotes.BeginInvoke(new Action(() =>
                    {
                        lbNotes.Items.Clear();
                    }));
                }
                else
                {
                    lbNotes.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DialogResult ConfirmationBox(ref string userResponse, Department selectedDepartment, DateTime startDate, DateTime upcomingSunday, List<Role> roles, out ChangeEmployeesNum changeForm)
        {
            changeForm = new ChangeEmployeesNum(startDate, upcomingSunday, roles, selectedDepartment);
            DialogResult dialogResult = changeForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                userResponse = "Yes";
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                userResponse = "Cancel";
            }

            return dialogResult;
        }

        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                //changesForNumOfEmployees.Clear();
                Role selected_role = (Role)Enum.Parse(typeof(Role), cbRole.SelectedItem.ToString());
                selectedDepartment = (Department)Enum.Parse(typeof(Department), cbDepartment.SelectedItem.ToString());
                List<Role> rolesForDepartment = new List<Role>();

                if (rbWeekForWholeDepartment.Checked)
                {
                    foreach (var item in cbRole.Items)
                    {
                        rolesForDepartment.Add((Role)Enum.Parse(typeof(Role), item.ToString()));
                    }
                }
                else
                {
                    rolesForDepartment.Add(selected_role);
                }
                string userResponse = "";
                ChangeEmployeesNum changeForm;

                if (rbGenerateDaySchedule.Checked)
                {
                    IEnumerable<Availability> allAvailableEmployees;
                    GenerateWeekScheduleForACertainRole2(selected_role, calendar.SelectionStart.Date, calendar.SelectionEnd.Date);
                    UpdateAvailabilityData();
                }
                else if (rbGenerateWeekSchedule.Checked)
                {
                    if (calendar.SelectionStart.DayOfWeek == DayOfWeek.Sunday)
                    {
                        MessageBox.Show("It's Sunday");
                    }
                    else
                    {
                        DateTime startDate;

                        if (DateTime.Today <= GetLastMonday(calendar.SelectionStart))
                        {
                            startDate = GetLastMonday(calendar.SelectionStart);
                        }
                        else
                        {
                            startDate = DateTime.Today.AddDays(1);
                        }
                        DateTime upcomingSunday = GetUpcomingSunday(calendar.SelectionStart);

                        DialogResult result = ConfirmationBox(ref userResponse, selectedDepartment, startDate, upcomingSunday, rolesForDepartment, out changeForm);
                        //if (result == DialogResult.Yes)
                        //{
                        //    changesForNumOfEmployees = changeForm.changes;
                        //}
                        //else if (result == DialogResult.Cancel)
                        //{
                        //}

                        GenerateWeekScheduleForACertainRole2(selected_role, startDate, upcomingSunday);
                        UpdateAvailabilityData();
                    }
                }
                else if (rbWeekForWholeDepartment.Checked)
                {
                    if (calendar.SelectionStart.DayOfWeek == DayOfWeek.Sunday)
                    {
                        MessageBox.Show("It's Sunday");
                    }
                    else
                    {
                        DateTime startDate;
                        btnGenerateSchedule.Click -= btnGenerateSchedule_Click;

                        if (DateTime.Today <= GetLastMonday(calendar.SelectionStart))
                        {
                            startDate = GetLastMonday(calendar.SelectionStart);
                        }
                        else
                        {
                            startDate = DateTime.Today.AddDays(1);
                        }
                        int numOfWeeks = Convert.ToInt16(cbWeeksRange.SelectedItem);
                        DateTime upcomingSunday = GetUpcomingSunday(calendar.SelectionStart).AddDays(numOfWeeks * 7);

                        DialogResult result = ConfirmationBox(ref userResponse, selectedDepartment, startDate, upcomingSunday, rolesForDepartment, out changeForm);

                        //if (result == DialogResult.Yes)
                        //{
                        //    changesForNumOfEmployees = changeForm.changes;
                        //}
                        //else if (result == DialogResult.Cancel)
                        //{
                        //}

                        foreach (var item in cbRole.Items)
                        {
                            Role selectedRole = (Role)Enum.Parse(typeof(Role), item.ToString());
                            GenerateWeekScheduleForACertainRole2(selectedRole, startDate, upcomingSunday);
                        }
                        UpdateAvailabilityData();
                    }
                }
                // backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                //backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;

                //CheckForShiftShortages();
                //backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CheckForShiftShortages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private async void btnGenerateSchedule_Click(object sender, EventArgs e)
        //{
        //    changesForNumOfEmployees.Clear();
        //    Role selected_role = (Role)Enum.Parse(typeof(Role), cbRole.SelectedItem.ToString());
        //    selectedDepartment = (Department)Enum.Parse(typeof(Department), cbDepartment.SelectedItem.ToString());
        //    List<Role> rolesForDepartment = new List<Role>();

        //    if (rbWeekForWholeDepartment.Checked)
        //    {
        //        foreach (var item in cbRole.Items)
        //        {
        //            rolesForDepartment.Add((Role)Enum.Parse(typeof(Role), item.ToString()));
        //        }
        //    }
        //    else
        //    {
        //        rolesForDepartment.Add(selected_role);
        //    }
        //    string userResponse = "";
        //    ChangeEmployeesNum changeForm;

        //    if (rbGenerateDaySchedule.Checked)
        //    {
        //        IEnumerable<Availability> allAvailableEmployees;
        //        GenerateWeekScheduleForACertainRole2(selected_role, calendar.SelectionStart.Date, calendar.SelectionEnd.Date);
        //        // Run UpdateAvailabilityDataAsync and CheckForShiftShortagesAsync concurrently
        //        var updateTask = UpdateAvailabilityDataAsync();
        //        var shortageTask = CheckForShiftShortagesAsync();
        //        await Task.WhenAll(updateTask, shortageTask);
        //    }
        //    else if (rbGenerateWeekSchedule.Checked)
        //    {
        //        DateTime startDate;

        //        if (DateTime.Today <= GetLastMonday(calendar.SelectionStart))
        //        {
        //            startDate = GetLastMonday(calendar.SelectionStart);
        //        }
        //        else
        //        {
        //            startDate = DateTime.Today.AddDays(1);
        //        }
        //        DateTime upcomingSunday = GetUpcomingSunday(calendar.SelectionStart);

        //        DialogResult result = ConfirmationBox(ref userResponse, selectedDepartment, startDate, upcomingSunday, rolesForDepartment, out changeForm);
        //        if (result == DialogResult.Yes)
        //        {
        //            changesForNumOfEmployees = changeForm.changes;
        //        }
        //        else if (result == DialogResult.Cancel)
        //        {
        //            return;
        //        }

        //        GenerateWeekScheduleForACertainRole2(selected_role, startDate, upcomingSunday);
        //        // Run UpdateAvailabilityDataAsync and CheckForShiftShortagesAsync concurrently
        //        var updateTask = UpdateAvailabilityDataAsync();
        //        var shortageTask = CheckForShiftShortagesAsync();
        //        await Task.WhenAll(updateTask, shortageTask);
        //    }
        //    else if (rbWeekForWholeDepartment.Checked)
        //    {
        //        DateTime startDate;
        //        btnGenerateSchedule.Click -= btnGenerateSchedule_Click;

        //        if (DateTime.Today <= GetLastMonday(calendar.SelectionStart))
        //        {
        //            startDate = GetLastMonday(calendar.SelectionStart);
        //        }
        //        else
        //        {
        //            startDate = DateTime.Today.AddDays(1);
        //        }
        //        int numOfWeeks = Convert.ToInt16(cbWeeksRange.SelectedItem);
        //        DateTime upcomingSunday = GetUpcomingSunday(calendar.SelectionStart).AddDays(numOfWeeks * 7);

        //        DialogResult result = ConfirmationBox(ref userResponse, selectedDepartment, startDate, upcomingSunday, rolesForDepartment, out changeForm);

        //        if (result == DialogResult.Yes)
        //        {
        //            changesForNumOfEmployees = changeForm.changes;
        //        }
        //        else if (result == DialogResult.Cancel)
        //        {
        //            return;
        //        }

        //        foreach (var item in cbRole.Items)
        //        {
        //            Role selectedRole = (Role)Enum.Parse(typeof(Role), item.ToString());
        //            GenerateWeekScheduleForACertainRole2(selectedRole, startDate, upcomingSunday);
        //        }
        //        // Run UpdateAvailabilityDataAsync and CheckForShiftShortagesAsync concurrently
        //        var updateTask = UpdateAvailabilityDataAsync();
        //        var shortageTask = CheckForShiftShortagesAsync();
        //        await Task.WhenAll(updateTask, shortageTask);
        //    }
        //}

        private void AnyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close_application)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbDepartment.SelectedItem.ToString() == Department.Sales.ToString())
                {
                    cbRole.Items.Clear();
                    cbRole.Items.Add(Role.Floor_Consultant);
                    cbRole.Items.Add(Role.Cashier);
                    cbRole.Items.Add(Role.Security);
                    cbRole.Items.Add(Role.Manager);
                }
                else if (cbDepartment.SelectedItem.ToString() == Department.Products.ToString())
                {
                    cbRole.Items.Clear();
                    cbRole.Items.Add(Role.Manager);
                    cbRole.Items.Add(Role.Floor_Consultant);
                }
                else if (cbDepartment.SelectedItem.ToString() == Department.Depo.ToString())
                {
                    cbRole.Items.Clear();
                    cbRole.Items.Add(Role.Manager);
                    cbRole.Items.Add(Role.Floor_Consultant);
                }
                cbRole.SelectedIndex = 0;
                UpdateAvailabilityData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateAvailabilityData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                close_application = false;
                this.Close();
                managerManageShdeule.updateData();
                managerManageShdeule.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManagerSchedulePlanner_Load(object sender, EventArgs e)
        {

        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                if (calendar.SelectionStart != calendar.SelectionEnd)
                {
                    calendar.SelectionStart = calendar.SelectionEnd;
                }
                UpdateAvailabilityData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbWeeksRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            numOfWeeks = Convert.ToInt32(cbWeeksRange.SelectedItem);
        }



        //Drag & Drop Functionalitites
        private void lbDayPlannerFirstShift_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(string)))
                {
                    string item = (string)e.Data.GetData(typeof(string));
                    ListBox lb = (ListBox)sender;
                    lb.Items.Add(item);
                    availabilitySQL.ChangeIsTaken(selectedAvailability, selected_personDrag.GetId(), calendar.SelectionStart, AvailabilityForTheDay.FirstShift);

                    UpdateAvailabilityData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lbDayPlannerFirstShift_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(string)))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbAvailableMemebersFirstShift_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (lbAvailableMemebersFirstShift.SelectedItem != null)
                {
                    selected_personDrag = peopleManager.FindConcretePerson(lbAvailableMemebersFirstShift.SelectedItem.ToString());

                    selectedAvailability = availabilitySQL.FindAvailability(selected_personDrag, calendar.SelectionStart.Date, AvailabilityForTheDay.FirstShift);

                    if (e.Button == MouseButtons.Left)
                    {
                        ListBox lb = (ListBox)sender;
                        if (lb.SelectedItem != null)
                        {
                            lb.DoDragDrop(lb.SelectedItem, DragDropEffects.Copy);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lbDayPlannerSecondShift_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(string)))
                {
                    string item = (string)e.Data.GetData(typeof(string));
                    ListBox lb = (ListBox)sender;
                    lb.Items.Add(item);
                    availabilitySQL.ChangeIsTaken(selectedAvailability, selected_personDrag.GetId(), calendar.SelectionStart, AvailabilityForTheDay.SecondShift);

                    UpdateAvailabilityData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbDayPlannerSecondShift_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(string)))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbAvailableMembersSecondShift_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (lbAvailableMembersSecondShift.SelectedItem != null)
                {
                    selected_personDrag = peopleManager.FindConcretePerson(lbAvailableMembersSecondShift.SelectedItem.ToString());

                    selectedAvailability = availabilitySQL.FindAvailability(selected_personDrag, calendar.SelectionStart.Date, AvailabilityForTheDay.SecondShift);

                    if (e.Button == MouseButtons.Left)
                    {
                        ListBox lb = (ListBox)sender;
                        if (lb.SelectedItem != null)
                        {
                            lb.DoDragDrop(lb.SelectedItem, DragDropEffects.Copy);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //--------------------------------------
        private void lbAvailableMembersThirdShift_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (lbAvailableMembersThirdShift.SelectedItem != null)
                {
                    selected_personDrag = peopleManager.FindConcretePerson(lbAvailableMembersThirdShift.SelectedItem.ToString());

                    selectedAvailability = availabilitySQL.FindAvailability(selected_personDrag, calendar.SelectionStart.Date, AvailabilityForTheDay.ThirdShift);

                    if (e.Button == MouseButtons.Left)
                    {
                        ListBox lb = (ListBox)sender;
                        if (lb.SelectedItem != null)
                        {
                            lb.DoDragDrop(lb.SelectedItem, DragDropEffects.Copy);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbDayPlannerThirdShift_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(string)))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbDayPlannerThirdShift_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(string)))
                {
                    string item = (string)e.Data.GetData(typeof(string));
                    ListBox lb = (ListBox)sender;
                    lb.Items.Add(item);
                    availabilitySQL.ChangeIsTaken(selectedAvailability, selected_personDrag.GetId(), calendar.SelectionStart, AvailabilityForTheDay.ThirdShift);

                    UpdateAvailabilityData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //--------------------------------------
        //private void lbDayPlannerSecondShift_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (lbDayPlannerSecondShift.SelectedItem != null)
        //    {
        //        selected_personDrag = database.TakeAllCurrentlyWorkingPeople().FirstOrDefault(p => p.GetShortInfo().Equals(lbDayPlannerSecondShift.SelectedItem.ToString()));
        //        selectedAvailability = database.FindAvailability(selected_personDrag, calendar.SelectionStart.Date, AvailabilityForTheDay.SecondShift);

        //        if (e.Button == MouseButtons.Left)
        //        {
        //            ListBox lb = (ListBox)sender;
        //            if (lb.SelectedItem != null)
        //            {
        //                lb.DoDragDrop(lb.SelectedItem, DragDropEffects.Copy);
        //            }
        //        }
        //    }
        //}

        //private void lbAvailableMembersSecondShift_DragDrop(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(typeof(string)))
        //    {
        //        e.Effect = DragDropEffects.Copy;
        //    }
        //}

        //private void lbAvailableMembersSecondShift_DragEnter(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(typeof(string)))
        //    {
        //        e.Effect = DragDropEffects.Copy;
        //    }
        //}
    }
}