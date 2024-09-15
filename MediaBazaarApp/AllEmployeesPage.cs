using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using DataAccessLayer;
using LogicLayer;
using OxyPlot.Axes;

namespace MediaBazaarApp
{
    public partial class AllEmployeesPage : Form
    {
        ManagerMenu managerMenu;
        PeopleManagement peopleManager;
        ShiftManager shiftManager = new ShiftManager();
        Person loggedInUser;
        ProductsDataAccessLayer database;
        AvailabilityManager availabilityManager = new AvailabilityManager();

        private bool close_application;
        private List<Person> listToUse;
        private List<Person> peopleForPage;
        private string filteringCriteria;

        private int counter;

        public AllEmployeesPage(ManagerMenu managerMenu, PeopleManagement dataManager, Person loggedInUser, ProductsDataAccessLayer database)
        {
            try
            {
                this.managerMenu = managerMenu;
                this.peopleManager = dataManager;
                this.loggedInUser = loggedInUser;
                close_application = true;
                InitializeComponent();
                this.database = database;
                tbSelectedUserInfo.ReadOnly = true;
                this.counter = 1;
                rbEmployees.Checked = true;
                btnRemoveEmployee.Visible = false;
                btnChangeWage.Visible = false;
                btnPrevPage.Visible = false;
                CheckLoggedInUser();
                ListPeople();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
		}

        private void CheckLoggedInUser()
        {
            if (loggedInUser.GetRole == Role.Manager)
            {
                rbEmployees.Checked = true;
                rbManagers.Visible = false;
                rbEmployees.Visible = false;
                btnAddNewEmployee.Visible = false;
                btnRemoveEmployee.Visible = false;
                btnChangeWage.Visible = false;
            }
        }
        public void ReloadList()
        {
            try
            {
                Updatelist();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListPeople()
        {
           
            try
            {
                lbEmployeesList.Items.Clear();
                if (loggedInUser.GetRole == Role.Manager)
                {
                    peopleForPage = peopleManager.ReadPeopleForSelectedPageDifferentFromManagers(loggedInUser.GetDepartment, true, counter, filteringCriteria);
                }
                else
                {
                    if (rbManagers.Checked)
                    {
                        peopleForPage = peopleManager.ReadPeopleForSelectedPage(null, Role.Manager, true, counter, filteringCriteria);
                    }
                    else if (rbEmployees.Checked)
                    {
                        peopleForPage = peopleManager.ReadPeopleForSelectedPageDifferentFromManagers(null, true, counter, filteringCriteria);
                    }
                    else
                    {
                        peopleForPage = peopleManager.ReadPeopleForSelectedPage(null, null, true, counter, filteringCriteria);
                    }
                }
                listToUse = peopleForPage.Take(15).ToList();

                foreach (Person person in listToUse)
                {
                    if (person.getEmail().Equals(loggedInUser.getEmail()))
                    {
                        continue;
                    }
                    lbEmployeesList.Items.Add(person.GetInfo());
                }
                if (lbEmployeesList.Items.Count > 0)
                {
                    lbEmployeesList.SelectedIndex = 0;
                }
                labelPageNum.Text = $"{counter}";
                CheckForNavigationhiding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Updatelist()
        {
            try
            {
                this.counter = 1;
                filteringCriteria = null;
                ListPeople();
                tbSearchInput.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void lbEmployeesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbEmployeesList.SelectedItem != null)
                {
                    tbSelectedUserInfo.ResetText();
                    Person person = listToUse.FirstOrDefault(p => p.GetInfo().Equals(lbEmployeesList.SelectedItem.ToString()));
                    tbSelectedUserInfo.Text = person.PersonDetailedInfo;
                    btnRemoveEmployee.Visible = true;
                    btnChangeWage.Visible = true;

                    var model = new PlotModel
                    {
                        Title = "Hours worked",
					};

					var s1 = new BarSeries { Title = "Hours worked", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
                    for (int i = 0; i < 12; i++)
                    {
						s1.Items.Add(new BarItem { Value = shiftManager.GetEmployeeWorkTimeMonth(person.ID, i) });
					}

					var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
                    for (int i = 0; i < 12; i++)
                    {
						categoryAxis.Labels.Add(DateTime.Now.AddMonths(-i).Year.ToString() + "/" + DateTime.Now.AddMonths(-i).Month.ToString());
					}
					var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
					model.Series.Add(s1);
					model.Axes.Add(categoryAxis);
					model.Axes.Add(valueAxis);
					this.WorkHoursGraph.Model = model;
				}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewEmployeePage addNewEmployeePage = new AddNewEmployeePage(this, loggedInUser, peopleManager, database);
                this.Hide();
                addNewEmployeePage.Show();
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

        private void rbManagers_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                counter = 1;
                ListPeople();
                btnRemoveEmployee.Visible = false;
                btnChangeWage.Visible = false;
                btnPrevPage.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbEmployees_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                counter = 1;
                ListPeople();
                btnRemoveEmployee.Visible = false;
                btnChangeWage.Visible = false;
                btnPrevPage.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult[] results = { DialogResult.Yes, DialogResult.Cancel };
                string userResponse = "";
                string message = "Are you sure you want to remove this employee?";
                if (results.Contains(ConfirmationBox(ref userResponse, message)))
                {
                    if (userResponse.Equals("Yes"))
                    {
                        Person person = listToUse.FirstOrDefault(p => p.GetInfo().Equals(lbEmployeesList.SelectedItem.ToString()));
                        peopleManager.ChangeWorkingStatus(person);
                        availabilityManager.DeleteAvailability(person.GetId());
                        MessageBox.Show("Employee has been removed from the planning system. Removed person data will be kept in the Media Bazaar Archive for 7 years!");
                        tbSelectedUserInfo.ResetText();
                        Updatelist();
                        CheckForNavigationhiding();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DialogResult ConfirmationBox(ref string userResponse, string message)
        {
            Alert aletPage = new Alert(message);
            DialogResult dialogResult = aletPage.ShowDialog();
            if (dialogResult == DialogResult.Yes)
            {
                userResponse = "Yes";
            }

            if (dialogResult == DialogResult.Cancel)
            {
                userResponse = "Cancel";
            }

            return dialogResult;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Person person = listToUse.FirstOrDefault(p => p.GetInfo().Equals(lbEmployeesList.SelectedItem.ToString()));
                UpdateSalary updateSalaryPage = new UpdateSalary(person, peopleManager, this);
                updateSalaryPage.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            try
            {
                close_application = false;
                this.Close();
                managerMenu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                counter++;
                ListPeople();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                counter--;
                ListPeople();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckForNavigationhiding()
        {
            if (counter == 1)
            {
                btnPrevPage.Visible = false;
            }
            else
            {
                btnPrevPage.Visible = true;
            }

            if (peopleForPage.Count() > 15)
            {
                btnNextPage.Visible = true;
            }
            else
            {
                btnNextPage.Visible = false;
            }
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                counter = 1;
                if (string.IsNullOrEmpty(tbSearchInput.Text.Trim()))
                {
                    filteringCriteria = null;
                }
                else if (!string.IsNullOrEmpty(tbSearchInput.Text))
                {
                    filteringCriteria = tbSearchInput.Text.Trim();
                }
                ListPeople();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
