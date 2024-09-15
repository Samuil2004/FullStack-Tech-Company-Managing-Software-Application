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
        PeopleManagement dataManager;
        ShiftManager shiftManager = new ShiftManager();
        Person loggedInUser;
        SQLDatabase database;
        AvailabilityManager availabilityManager = new AvailabilityManager();

        private bool close_application;
        private List<Person> listToUse;
        private List<Person> peopleForPage;
        private string filteringCriteria;

        //private IEnumerable<Person> allPeople;
        //private IEnumerable<Person> selectedRole;

        private int counter;

        public AllEmployeesPage(ManagerMenu managerMenu, PeopleManagement dataManager, Person loggedInUser, SQLDatabase database)
        {
            try
            {
                this.managerMenu = managerMenu;
                this.dataManager = dataManager;
                this.loggedInUser = loggedInUser;
                close_application = true;
                InitializeComponent();
                //ReloadList();
                this.database = database;
                tbSelectedUserInfo.ReadOnly = true;
                this.counter = 1;
                rbEmployees.Checked = true;
                btnRemoveEmployee.Visible = false;
                btnChangeWage.Visible = false;
                btnPrevPage.Visible = false;
                CheckLoggedInUser();
                ListPeople();
                //if (loggedInUser.GetRole == Role.Manager)
                //{
                //    this.allPeople =
                //                from person in dataManager.getAllPeople()
                //                where person != loggedInUser && person.GetStillWorking == true && person.GetDepartment == loggedInUser.GetDepartment
                //                select person;
                //}
                //else
                //{
                //    this.allPeople =
                //                from person in dataManager.getAllPeople()
                //                where person != loggedInUser && person.GetStillWorking == true
                //                select person;
                //}
                //this.selectedRole = allPeople;
                //ListPeople(0, 10, selectedRole);
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

        //public void listEverybodyFromTheCompany()
        //{
        //IEnumerable<Person> allPeople;


        //foreach (Person person in allPeople)
        //{
        //    string personInfo = person.GetInfo();
        //    if (!string.IsNullOrEmpty(personInfo))
        //    {
        //        lbEmployeesList.Items.Add(personInfo);
        //    }
        //}
        //}
        private void ListPeople()
        {
            //lbEmployeesList.Items.Clear();
            //if (endIndex >= selectedRole.Count()-15)
            //{
            //    foreach (Person person in listToUse.Skip(startIndex).Take(selectedRole.Count() - startIndex).ToList())
            //    {
            //        lbEmployeesList.Items.Add(person.GetInfo());
            //    }
            //}
            //else
            //{
            //    foreach (Person person in selectedRole.Skip(startIndex).Take(15).ToList())
            //    {
            //        lbEmployeesList.Items.Add(person.GetInfo());
            //    }
            //}
            //if (lbEmployeesList.Items.Count > 0)
            //{
            //    lbEmployeesList.SelectedIndex = 0;
            //}
            //int wholeNum = selectedRole.Count() % 15;
            //int maxPages = 0;
            //if (wholeNum == 0)
            //{
            //    maxPages = selectedRole.Count() / 15;
            //}
            //else
            //{
            //    maxPages = (selectedRole.Count() / 15) + 1;
            //}
            //labelPageNum.Text = $"{counter + 1}/{maxPages}";
            try
            {
                lbEmployeesList.Items.Clear();
                if (loggedInUser.GetRole == Role.Manager)
                {
                    //peopleForPage = database.ReadPeopleForSelectedPage(loggedInUser.GetDepartment,loggedInUser.GetRole,true, counter);
                    peopleForPage = database.ReadPeopleForSelectedPageDifferentFromManagers(loggedInUser.GetDepartment, true, counter, filteringCriteria);
                    //listToUse = peopleForPage.Take(15).ToList();
                }
                else
                {
                    if (rbManagers.Checked)
                    {
                        peopleForPage = database.ReadPeopleForSelectedPage(null, Role.Manager, true, counter, filteringCriteria);
                    }
                    else if (rbEmployees.Checked)
                    {
                        peopleForPage = database.ReadPeopleForSelectedPageDifferentFromManagers(null, true, counter, filteringCriteria);
                    }
                    else
                    {
                        peopleForPage = database.ReadPeopleForSelectedPage(null, null, true, counter, filteringCriteria);
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
            //tbSelectedUserInfo.ResetText();
            //lbEmployeesList.Items.Clear();
            //if (string.IsNullOrEmpty(tbSearchInput.Text))
            //{
            //    if (!rbManagers.Checked && !rbEmployees.Checked)
            //    {
            //        this.counter = 0;
            //        this.selectedRole = allPeople;
            //        ListPeople(0,15, selectedRole);
            //    }
            //    else if (rbManagers.Checked)
            //    {
            //        printAllManagers();
            //    }
            //    else if (rbEmployees.Checked)
            //    {
            //        printAllEmployees();
            //    }
            //}
            //else if (!string.IsNullOrEmpty(tbSearchInput.Text))
            //{
            //    if (!rbEmployees.Checked && !rbManagers.Checked)
            //    {
            //        IEnumerable<Person> possibleSearches;
            //        if (loggedInUser.GetRole == Role.Manager)
            //        {
            //            possibleSearches =
            //            from person in dataManager.getAllPeople()
            //            where person.GetInfo().ToUpper().Contains(tbSearchInput.Text.ToUpper()) && person != loggedInUser && person.GetStillWorking == true && person.GetDepartment == loggedInUser.GetDepartment
            //            select person;
            //        }
            //        else
            //        {
            //            possibleSearches =
            //            from person in dataManager.getAllPeople()
            //            where person.GetInfo().ToUpper().Contains(tbSearchInput.Text.ToUpper()) && person != loggedInUser && person.GetStillWorking == true
            //            select person;
            //        }
            //        this.counter = 0;
            //        this.selectedRole = possibleSearches;
            //        ListPeople(0,15, selectedRole);
            //        CheckForNavigationhiding();
            //    }

            //    if (rbManagers.Checked)
            //    {
            //        //lbEmployeesList.Items.Clear();
            //        var managerResults =
            //                from person in dataManager.getAllPeople()
            //                where person.GetRole == Role.Manager && person.GetInfo().ToUpper().Contains(tbSearchInput.Text.ToUpper()) && person.GetStillWorking == true
            //                select person;
            //        //foreach (Person person in managerResults)
            //        //{
            //        //    lbEmployeesList.Items.Add(person.GetInfo());
            //        //}
            //        this.counter = 0;
            //        this.selectedRole = managerResults;
            //        ListPeople(0, 15, selectedRole);
            //        CheckForNavigationhiding();

            //    }
            //    else if (rbEmployees.Checked)
            //    {
            //        IEnumerable<Person> employeeResults;
            //        if (loggedInUser.GetRole == Role.Manager)
            //        {
            //            employeeResults =
            //                from person in dataManager.getAllPeople()
            //                where person.GetRole != Role.Manager && person.GetRole != Role.CEO && person.GetInfo().ToUpper().Contains(tbSearchInput.Text.ToUpper()) && person.GetStillWorking == true && person.GetDepartment == loggedInUser.GetDepartment
            //                select person;
            //        }
            //        else
            //        {
            //            employeeResults =
            //                from person in dataManager.getAllPeople()
            //                where person.GetRole != Role.Manager && person.GetRole != Role.CEO && person.GetInfo().ToUpper().Contains(tbSearchInput.Text.ToUpper()) && person.GetStillWorking == true
            //                select person;
            //        }
            //        //lbEmployeesList.Items.Clear();
            //        //var employeeResults =
            //        //        from person in dataManager.getAllPeople()
            //        //        where person.GetRole == Role.Floor_Consultant && person.GetInfo().ToUpper().Contains(tbSearchInput.Text.ToUpper()) && person.GetStillWorking == true
            //        //        select person;
            //        //foreach (Person person in employeeResults)
            //        //{
            //        //    lbEmployeesList.Items.Add(person.GetInfo());
            //        //}
            //        this.counter = 0;
            //        this.selectedRole = employeeResults;
            //        ListPeople(0, 15, selectedRole);
            //        CheckForNavigationhiding();

            //    }
            //}

        }
        private void lbEmployeesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbEmployeesList.SelectedItem != null)
                {
                    tbSelectedUserInfo.ResetText();
                    //Person person = dataManager.FindPerson(lbEmployeesList.SelectedItem.ToString());
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
            //CheckLoggedInUser();
        }
        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewEmployeePage addNewEmployeePage = new AddNewEmployeePage(this, loggedInUser, dataManager, database);
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
        //private void printAllEmployees()
        //{
        //    IEnumerable<Person> allEmployees;
        //    if (loggedInUser.GetRole == Role.Manager)
        //    {
        //        allEmployees =
        //            from person in dataManager.getAllPeople()
        //            where person.GetRole != Role.Manager && person.GetRole != Role.CEO && person.GetStillWorking == true && person.GetDepartment == loggedInUser.GetDepartment
        //            select person;
        //    }
        //    else
        //    {
        //        allEmployees =
        //            from person in dataManager.getAllPeople()
        //            where person.GetRole != Role.Manager && person.GetRole != Role.CEO && person.GetStillWorking == true
        //            select person;
        //    }
        //    this.selectedRole = allEmployees;
        //    this.counter = 0;
        //    ListPeople(0, 15, selectedRole);
        //    CheckForNavigationhiding();
        //}

        //private void printAllManagers()
        //{
        //    var allCEOAndManagers =
        //            from person in dataManager.getAllPeople()
        //            where person.GetRole == Role.Manager && person.GetStillWorking == true
        //            select person;
        //    this.selectedRole = allCEOAndManagers;
        //    this.counter = 0;
        //    ListPeople(0, 15, selectedRole);
        //    CheckForNavigationhiding();
        //}

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
                        //Person person = dataManager.FindPerson(lbEmployeesList.SelectedItem.ToString());
                        Person person = listToUse.FirstOrDefault(p => p.GetInfo().Equals(lbEmployeesList.SelectedItem.ToString()));
                        database.ChangeWorkingStatus(person);
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
                //Person person = dataManager.FindPerson(lbEmployeesList.SelectedItem.ToString());
                Person person = listToUse.FirstOrDefault(p => p.GetInfo().Equals(lbEmployeesList.SelectedItem.ToString()));
                UpdateSalary updateSalaryPage = new UpdateSalary(person, database, this);
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
            //if (selectedRole.Count() <= (counter + 2) * 15)
            //{
            //    btnNextPage.Visible = false;
            //}
            //else
            //{
            //    btnNextPage.Visible = true;
            //}
            //lbEmployeesList.Items.Clear();
            //counter++;
            //ListPeople(15 * counter, 15 * counter, selectedRole);
            //btnPrevPage.Visible = true;
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
            //if (counter - 1 == 0)
            //{
            //    btnPrevPage.Visible = false;
            //}
            //else
            //{
            //    btnPrevPage.Visible = true;
            //}
            //lbEmployeesList.Items.Clear();
            //counter--;
            //if (counter == 0)
            //{
            //    ListPeople(15 * counter, 15, selectedRole);
            //}
            //else
            //{
            //    ListPeople(15 * counter, 15 * counter, selectedRole);
            //}
            //btnNextPage.Visible = true;
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
            //    btnPrevPage.Visible = false;
            //    if (selectedRole.Count() <= (counter + 2) * 15)
            //    {
            //        btnNextPage.Visible = false;
            //        btnPrevPage.Visible = false;

            //    }
            //    else
            //    {
            //        btnNextPage.Visible = true;

            //    }
            //}
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
