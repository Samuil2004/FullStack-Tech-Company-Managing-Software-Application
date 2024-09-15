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
        private AvailabilityDataAccessLayer availabilitySql;
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
                availabilitySql = new AvailabilityDataAccessLayer();
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
                if (nmNumOfEmployees.Value != defaultNumOfEmployees)
                {
                    Role selected_role = (Role)Enum.Parse(typeof(Role), cbRoles.SelectedItem.ToString());
                    AvailabilityForTheDay selectedShift = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), cbShift.SelectedItem.ToString());

                    availabilitySql.AddShiftChange(calendar.SelectionStart, selectedDepartment, selected_role, selectedShift, Convert.ToInt32(nmNumOfEmployees.Value));
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
