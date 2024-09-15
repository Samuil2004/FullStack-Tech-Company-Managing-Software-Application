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
        public ManagerSchedulePlanner(PeopleManagement peopleManager, ManagerManageShdeule managerManageShdeule, Person loggedInUser, SQLDatabase database)
        {
            try
            {
                this.peopleManager = peopleManager;
                this.managerManageShdeule = managerManageShdeule;
                this.loggedInUser = loggedInUser;
                InitializeComponent();
                close_application = true;
                this.database = database;
                availabilitySQL = new AvailabilitySQL();
                rbGenerateDaySchedule.Checked = true;
                cbWeeksRange.SelectedIndex = 2;
                this.numOfWeeks = Convert.ToInt32(cbWeeksRange.SelectedItem);

                cbDepartment.Items.Add(loggedInUser.GetDepartment.ToString());
                calendar.MinDate = DateTime.Today;
                CheckLoggedInUser();
                btnGenerateSchedule.Visible = true;
                lbDayPlannerFirstShift.AllowDrop = true;
                lbDayPlannerFirstShift.DragDrop += lbDayPlannerFirstShift_DragDrop;
                lbDayPlannerFirstShift.DragEnter += lbDayPlannerFirstShift_DragEnter;

                lbAvailableMemebersFirstShift.AllowDrop = true;

                lbDayPlannerSecondShift.AllowDrop = true;
                lbDayPlannerSecondShift.DragDrop += lbDayPlannerSecondShift_DragDrop;
                lbDayPlannerSecondShift.DragEnter += lbDayPlannerSecondShift_DragEnter;

                lbAvailableMembersSecondShift.AllowDrop = true;

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
        }


        private void CheckLoggedInUser()
        {
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
        }
        
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
                    Person selected_person = peopleManager.FindConcretePerson(lbAvailableMemebersFirstShift.SelectedItem.ToString());
                    Availability av = availabilitySQL.FindAvailability(selected_person, calendar.SelectionStart.Date, AvailabilityForTheDay.FirstShift);
                    availabilitySQL.ChangeIsTaken(av, selected_person.GetId(), calendar.SelectionStart, AvailabilityForTheDay.FirstShift);
                }
                else if (lbAvailableMembersSecondShift.SelectedItem != null)
                {
                    Person selected_person = peopleManager.FindConcretePerson(lbAvailableMembersSecondShift.SelectedItem.ToString());
                    Availability av = availabilitySQL.FindAvailability(selected_person, calendar.SelectionStart.Date, AvailabilityForTheDay.SecondShift);
                    availabilitySQL.ChangeIsTaken(av, selected_person.GetId(), calendar.SelectionStart, AvailabilityForTheDay.SecondShift);
                }
                else if (lbAvailableMembersThirdShift.SelectedItem != null)
                {
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
                    Person selected_person = peopleManager.FindConcretePerson(lbDayPlannerFirstShift.SelectedItem.ToString());
                    Availability av = availabilitySQL.FindAvailability(selected_person, calendar.SelectionStart.Date, AvailabilityForTheDay.FirstShift);
                    availabilitySQL.ChangeIsTaken(av, selected_person.GetId(), calendar.SelectionStart, AvailabilityForTheDay.FirstShift);
                }
                else if (lbDayPlannerSecondShift.SelectedItem != null)
                {
                    Person selected_person = peopleManager.FindConcretePerson(lbDayPlannerSecondShift.SelectedItem.ToString());
                    Availability av = availabilitySQL.FindAvailability(selected_person, calendar.SelectionStart.Date, AvailabilityForTheDay.SecondShift);
                    availabilitySQL.ChangeIsTaken(av, selected_person.GetId(), calendar.SelectionStart, AvailabilityForTheDay.SecondShift);

                }
                else if (lbDayPlannerThirdShift.SelectedItem != null)
                {
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

                        foreach (var item in cbRole.Items)
                        {
                            Role selectedRole = (Role)Enum.Parse(typeof(Role), item.ToString());
                            GenerateWeekScheduleForACertainRole2(selectedRole, startDate, upcomingSunday);
                        }
                        UpdateAvailabilityData();
                    }
                }
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
    }
}