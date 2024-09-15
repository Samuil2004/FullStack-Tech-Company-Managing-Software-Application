using ClassLibrary;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using DataAccessLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MediaBazaarApp
{
    public partial class ChangeEmployeesNum : Form
    {
        private Department selectedDepartment;
        private int defaultNumOfEmployees;
        private AvailabilitySQL availabilitySql;
        //public List<EmployeeNumberChange> changes { get; private set; } = new List<EmployeeNumberChange>();
        public ChangeEmployeesNum(DateTime startDate, DateTime endDate, List<Role> roles, Department department)
        {
            try 
            { 
                InitializeComponent();
                calendar.MinDate = startDate;
                calendar.MaxDate = endDate;
                this.selectedDepartment = department;
                btnAgree.Enabled = false;
                foreach (Role role in roles)
                {
                    cbRoles.Items.Add(role);
                }
                cbRoles.SelectedIndex = 0;
                cbShift.SelectedIndex = 0;
                calendar.MinDate = startDate;
                calendar.MaxDate = endDate;
                availabilitySql = new AvailabilitySQL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgree_Click(object sender, EventArgs e)
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
                checkFordefaultNumOfEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            { 
            checkFordefaultNumOfEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void checkFordefaultNumOfEmployees()
        {
            try
            {
                if (cbRoles.SelectedItem.ToString().Equals(Role.Floor_Consultant.ToString()) && selectedDepartment.Equals(Department.Sales))
                {
                    if (calendar.SelectionStart.DayOfWeek == DayOfWeek.Saturday || calendar.SelectionStart.DayOfWeek == DayOfWeek.Sunday)
                    {
                        defaultNumOfEmployees = 20;

                    }
                    else
                    {
                        defaultNumOfEmployees = 15;
                    }
                }
                else if (cbRoles.SelectedItem.ToString().Equals(Role.Manager.ToString()))
                {
                    defaultNumOfEmployees = 1;

                }
                else
                {
                    defaultNumOfEmployees = 3;

                }
                nmNumOfEmployees.Value = defaultNumOfEmployees;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeNumberChange enc;
                if (nmNumOfEmployees.Value != defaultNumOfEmployees)
                {
                    Role selected_role = (Role)Enum.Parse(typeof(Role), cbRoles.SelectedItem.ToString());
                    AvailabilityForTheDay selectedShift = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), cbShift.SelectedItem.ToString());
                    //enc = new EmployeeNumberChange(selected_role, calendar.SelectionStart, selectedShift, Convert.ToInt32(nmNumOfEmployees.Value));
                    //if(changes.Any(ch => ch.GetSelectedDate == calendar.SelectionStart && ch.GetSelectedRole == selected_role && ch.GetSelectedShift == selectedShift))
                    //{

                    //}
                    //changes.RemoveAll(ch => ch.GetSelectedDate == calendar.SelectionStart && ch.GetSelectedRole == selected_role && ch.GetSelectedShift == selectedShift);
                    //changes.Add(enc);

                    availabilitySql.AddShiftChange(calendar.SelectionStart, selectedDepartment, selected_role, selectedShift, Convert.ToInt32(nmNumOfEmployees.Value));
                    //insert the specias number of employees in the Specail days table in sql and then make the planner page first check if
                    //there is a special number for the selected date,
                    //department and role and if yes to use it, but if no to use the default ones

                    btnAgree.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No changes have been applied");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {

        }
    }
}
