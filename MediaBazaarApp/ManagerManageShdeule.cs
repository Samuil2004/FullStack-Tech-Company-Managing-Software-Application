using LogicLayer;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using DataAccessLayer;
using ClassLibrary;

namespace MediaBazaarApp
{
    public partial class ManagerManageShdeule : Form
    {
        PeopleManagement dataManager;
        ManagerMenu managerMenu;
        Person loggedInUser;
        SQLDatabase database;
        AvailabilityDataAccessLayer availabilitySQL;
        private bool close_application;
        public ManagerManageShdeule(ManagerMenu managerMenu, PeopleManagement dataManager, Person loggedInUser, SQLDatabase database)
        {
            try
            {
                this.managerMenu = managerMenu;
                this.dataManager = dataManager;
                this.loggedInUser = loggedInUser;
                InitializeComponent();
                DateTime lastMonday = GetLastMonday(DateTime.Today);
                DateTime upcommingSuday = GetUpcomingSunday(DateTime.Today);
                int num = 0;


                cbRole.Visible = false;
                labelRole.Visible = false;

                close_application = true;
                this.database = database;
                CheckLoggedInUser();
                cbDepartment.SelectedIndex = 0;
                availabilitySQL = new AvailabilityDataAccessLayer();
                updateData();
                UpdateShiftRequests();
                if(loggedInUser.GetRole == Role.CEO)
                {
                    lbShiftChange.Visible = false;
                    btnApproveShift.Visible = false;
                    btnDecline.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void CheckLoggedInUser()
        {
            try
            {
                if (loggedInUser.GetRole == Role.CEO)
                {
                    btnOpenPlanner.Visible = false;
                    foreach (Department department in Enum.GetValues(typeof(Department)))
                    {
                        if (department != Department.Owners)
                        {
                            cbDepartment.Items.Add(department);
                        }
                    }
                }
                if (loggedInUser.GetRole == Role.Manager)
                {
                    cbDepartment.Items.Add(loggedInUser.GetDepartment);
                    cbDepartment.SelectedIndex = 0;
                    cbDepartment.Enabled = false;
                    cbRole.Visible = true;
                    labelRole.Visible = true;
                    cbDepartment.Visible = false;
                    labelDepartment.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void updateData()
        {
            try
            {
                lbMondayFS.Items.Clear();
                lbMondaySS.Items.Clear();
                lbMondayTS.Items.Clear();

                lbTuesdayFS.Items.Clear();
                lbTuesdaySS.Items.Clear();
                lbTuesdayTS.Items.Clear();

                lbWednesdayFS.Items.Clear();
                lbWednesdaySS.Items.Clear();
                lbWednesdayTS.Items.Clear();

                lbThursdayFS.Items.Clear();
                lbThursdaySS.Items.Clear();
                lbThursdayTS.Items.Clear();

                lbFridayFS.Items.Clear();
                lbFridaySS.Items.Clear();
                lbFridayTS.Items.Clear();

                lbSaturdayFS.Items.Clear();
                lbSaturadaySS.Items.Clear();
                lbSaturdayTS.Items.Clear();

                lbSundayFS.Items.Clear();
                lbSundaySS.Items.Clear();
                lbSundayTS.Items.Clear();


                DateTime sundayOfTheWeek = GetUpcomingSunday(calendar.SelectionStart);
                DateTime lastMondayOfTheWeek = GetLastMonday(calendar.SelectionEnd);
                labelMonday.Text = $"{lastMondayOfTheWeek.ToString("dd/MM/yy")}";
                labelTuesday.Text = $"{lastMondayOfTheWeek.AddDays(1).ToString("dd/MM/yy")}";
                labelWednesday.Text = $"{lastMondayOfTheWeek.AddDays(2).ToString("dd/MM/yy")}";
                labelThursday.Text = $"{lastMondayOfTheWeek.AddDays(3).ToString("dd/MM/yy")}";
                labelFriday.Text = $"{lastMondayOfTheWeek.AddDays(4).ToString("dd/MM/yy")}";
                labelSaturday.Text = $"{lastMondayOfTheWeek.AddDays(5).ToString("dd/MM/yy")}";
                labelSunday.Text = $"{sundayOfTheWeek.ToString("dd/MM/yy")}";
                ArrowsDate.Text = $"{lastMondayOfTheWeek.ToString("dd/MM")} - {sundayOfTheWeek.ToString("dd/MM")}";
                List<Availability> first;
                List<Availability> second;
                List<Availability> third;
                Department seleced_department = (Department)Enum.Parse(typeof(Department), cbDepartment.SelectedItem.ToString());
                Role selected_role;
                if (!string.IsNullOrEmpty(cbRole.SelectedItem.ToString()))
                {
                    selected_role = (Role)Enum.Parse(typeof(Role), cbRole.SelectedItem.ToString());
                }
                else
                {
                    selected_role = Role.Floor_Consultant;
                }
                first = dataManager.GetAllAvailability(lastMondayOfTheWeek, sundayOfTheWeek, AvailabilityForTheDay.FirstShift, seleced_department, selected_role);
                second = dataManager.GetAllAvailability(lastMondayOfTheWeek, sundayOfTheWeek, AvailabilityForTheDay.SecondShift, seleced_department, selected_role);
                third = dataManager.GetAllAvailability(lastMondayOfTheWeek, sundayOfTheWeek, AvailabilityForTheDay.ThirdShift, seleced_department, selected_role);

                foreach (Availability availability in first)
                {
                    if (availability.isPersonTaken())
                    {

                        switch (availability.getTimeSlot().DayOfWeek)
                        {
                            case DayOfWeek.Monday:
                                lbMondayFS.Items.Add(availability.getPerson().GetShortInfo());
                                break;
                            case DayOfWeek.Tuesday:
                                lbTuesdayFS.Items.Add(availability.getPerson().GetShortInfo());
                                break;
                            case DayOfWeek.Wednesday:
                                lbWednesdayFS.Items.Add(availability.getPerson().GetShortInfo());
                                break;
                            case DayOfWeek.Thursday:
                                lbThursdayFS.Items.Add(availability.getPerson().GetShortInfo());
                                break;
                            case DayOfWeek.Friday:
                                lbFridayFS.Items.Add(availability.getPerson().GetShortInfo());
                                break;
                            case DayOfWeek.Saturday:
                                lbSaturdayFS.Items.Add(availability.getPerson().GetShortInfo());
                                break;
                            case DayOfWeek.Sunday:
                                lbSundayFS.Items.Add(availability.getPerson().GetShortInfo());
                                break;
                        }
                    }

                }

                foreach (Availability availability in second)
                {
                    if (availability.isPersonTaken())
                    {
                        if (lastMondayOfTheWeek <= availability.getTimeSlot() && availability.getTimeSlot() <= sundayOfTheWeek)
                        {

                            switch (availability.getTimeSlot().DayOfWeek)
                            {
                                case DayOfWeek.Monday:
                                    lbMondaySS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Tuesday:
                                    lbTuesdaySS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Wednesday:
                                    lbWednesdaySS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Thursday:
                                    lbThursdaySS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Friday:
                                    lbFridaySS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Saturday:
                                    lbSaturadaySS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Sunday:
                                    lbSundaySS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                            }
                        }
                    }

                }


                foreach (Availability availability in third)
                {
                    if (availability.isPersonTaken())
                    {
                        if (lastMondayOfTheWeek <= availability.getTimeSlot() && availability.getTimeSlot() <= sundayOfTheWeek)
                        {

                            switch (availability.getTimeSlot().DayOfWeek)
                            {
                                case DayOfWeek.Monday:
                                    lbMondayTS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Tuesday:
                                    lbTuesdayTS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Wednesday:
                                    lbWednesdayTS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Thursday:
                                    lbThursdayTS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Friday:
                                    lbFridayTS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Saturday:
                                    lbSaturdayTS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
                                case DayOfWeek.Sunday:
                                    lbSundayTS.Items.Add(availability.getPerson().GetShortInfo());
                                    break;
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

        private void btnOpenPlanner_Click(object sender, EventArgs e)
        {
            ManagerSchedulePlanner planner = new ManagerSchedulePlanner(dataManager, this, loggedInUser, database);
            this.Hide();
            planner.Show();
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

                    cbRole.Visible = true;
                    labelRole.Visible = true;
                    cbRole.Items.Clear();
                    cbRole.Items.Add(Role.Manager);
                    cbRole.Items.Add(Role.Floor_Consultant);
                    cbRole.Items.Add(Role.Cashier);
                    cbRole.Items.Add(Role.Security);
                }
                else if (cbDepartment.SelectedItem.ToString() == Department.Products.ToString())
                {
                    cbRole.Visible = true;
                    labelRole.Visible = true;
                    cbRole.Items.Clear();
                    cbRole.Items.Add(Role.Floor_Consultant);
                    cbRole.Items.Add(Role.Manager);
                }
                else if (cbDepartment.SelectedItem.ToString() == Department.Depo.ToString())
                {
                    cbRole.Visible = true;
                    labelRole.Visible = true;
                    cbRole.Items.Clear();
                    cbRole.Items.Add(Role.Manager);
                    cbRole.Items.Add(Role.Floor_Consultant);
                }
                cbRole.SelectedIndex = 0;
                updateData();
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
                Department seleced_department = (Department)Enum.Parse(typeof(Department), cbDepartment.SelectedItem.ToString());
                updateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            close_application = false;
            this.Close();
            managerMenu.Show();
        }

        private void lbShiftChange_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                calendar.DateChanged -= calendar_DateChanged;

                if (calendar.SelectionStart != calendar.SelectionEnd)
                {
                    calendar.SelectionStart = calendar.SelectionEnd;
                }

                calendar.SetDate(GetLastMonday(calendar.SelectionEnd));
                calendar.SetSelectionRange(GetLastMonday(calendar.SelectionEnd), GetUpcomingSunday(calendar.SelectionEnd));
                updateData();

                calendar.DateChanged += calendar_DateChanged;
                if (calendar.SelectionEnd < DateTime.Today)
                {
                    btnOpenPlanner.Enabled = false;
                }
                else
                {
                    btnOpenPlanner.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void labelMonday_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevWeek_Click(object sender, EventArgs e)
        {
            try
            {
                calendar.SetSelectionRange(GetLastMonday(calendar.SelectionEnd.AddDays(-7)), GetUpcomingSunday(calendar.SelectionEnd.AddDays(-7)));
                updateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                calendar.SetSelectionRange(GetLastMonday(calendar.SelectionEnd.AddDays(7)), GetUpcomingSunday(calendar.SelectionEnd.AddDays(7)));
                updateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnApproveShift_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbShiftChange.SelectedItem != null)
                {
                    ShiftExchange selectedShiftExchange = availabilitySQL.FindConcreteAvailability(lbShiftChange.SelectedItem.ToString());

                    availabilitySQL.ChangeIsTaken(selectedShiftExchange.GetAvailability, selectedShiftExchange.GetAvailability.getPerson().GetId(), selectedShiftExchange.GetAvailability.getTimeSlot(), selectedShiftExchange.GetAvailability.GetAvailability());
                    availabilitySQL.UpdateShiftRequestStatus(selectedShiftExchange.GetAvailability.getPerson().GetId(), selectedShiftExchange.GetAvailability.GetAvailability(), selectedShiftExchange.GetAvailability.getTimeSlot());
                    UpdateShiftRequests();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateShiftRequests()
        {
            try
            {
                lbShiftChange.Items.Clear();
                foreach (ShiftExchange se in availabilitySQL.ReadShifTransferRequests(loggedInUser.GetDepartment))
                {
                    lbShiftChange.Items.Add($"{se.GetAvailability.getPerson().GetShortInfo()} - {se.GetAvailability.getTimeSlot().ToString("yyyy-MM-dd")} - {se.GetAvailability.GetAvailability().ToString()} - {se.GetReason}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbShiftChange.SelectedItem != null)
                {
                    ShiftExchange selectedShiftExchange = availabilitySQL.FindConcreteAvailability(lbShiftChange.SelectedItem.ToString());
                    availabilitySQL.DeleteShiftTransferRequest(selectedShiftExchange.GetAvailability.getPerson().GetId(), selectedShiftExchange.GetAvailability.getTimeSlot(), selectedShiftExchange.GetAvailability.GetAvailability());
                    UpdateShiftRequests();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
