using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
namespace MediaBazaarApp
{
    public partial class ArchivePage : Form
    {
        ManagerMenu managerMenu;
        PeopleManagement dataManager;
        Person loggedInUser;
        SQLDatabase database;

        private bool close_application;
        //private IEnumerable<Person> allPeople;
        private List<Person> listToUse;
        private List<Person> peopleForPage;
        private string filteringCriteria;
        private int counter;
        public ArchivePage(ManagerMenu managerMenu, PeopleManagement dataManager, Person loggedInUser, SQLDatabase database)
        {
            try
            {
                InitializeComponent();
                this.managerMenu = managerMenu;
                this.dataManager = dataManager;
                this.loggedInUser = loggedInUser;
                this.database = database;
                this.counter = 1;
                close_application = true;
                btnPrevPage.Visible = false;
                //this.allPeople = from person in dataManager.getAllPeople()
                //                 where person.GetId() != loggedInUser.GetId() && !person.GetStillWorking
                //                 select person;
                //listAllArchived();
                ListPeople();
                //CheckForNavigationhiding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //public void listAllArchived()
        //{
        //    lbEmployeesList.Items.Clear();
        //    var allNoLongerWorking =
        //                    from person in dataManager.getAllPeople()
        //                    where person.GetId() != loggedInUser.GetId() && !person.GetStillWorking
        //                    select person;
        //    foreach (Person person in allNoLongerWorking)
        //    {
        //        lbEmployeesList.Items.Add(person.GetInfo());
        //    }
        //}
        private void ListPeople()
        {
            //lbEmployeesList.Items.Clear();
            //if (endIndex >= allPeople.Count() - 15)
            //{
            //    foreach (Person person in listToUse.Skip(startIndex).Take(allPeople.Count() - startIndex).ToList())
            //    {
            //        lbEmployeesList.Items.Add(person.GetInfo());
            //    }
            //}
            //else
            //{
            //    foreach (Person person in allPeople.Skip(startIndex).Take(15).ToList())
            //    {
            //        lbEmployeesList.Items.Add(person.GetInfo());
            //    }
            //}
            //if (lbEmployeesList.Items.Count > 0)
            //{
            //    lbEmployeesList.SelectedIndex = 0;
            //}
            //int wholeNum = allPeople.Count() % 15;
            //int maxPages = 0;
            //if (wholeNum == 0)
            //{
            //    maxPages = allPeople.Count() / 15;
            //}
            //else
            //{
            //    maxPages = (allPeople.Count() / 15) + 1;
            //}
            //labelPageNum.Text = $"{counter + 1}/{maxPages}";

            //peopleForPage = database.ReadPeopleForSelectedPage(loggedInUser.GetDepartment,loggedInUser.GetRole,true, counter);
            try
            {
                lbEmployeesList.Items.Clear();
                peopleForPage = database.ReadPeopleForSelectedPage(null, null, false, counter, filteringCriteria);
                //listToUse = peopleForPage.Take(15).ToList();

                listToUse = peopleForPage.Take(15).ToList();

                foreach (Person person in listToUse)
                {
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
        //private void tbSearchInput_TextChanged(object sender, EventArgs e)
        //{
        //    lbEmployeesList.Items.Clear();
        //    if (string.IsNullOrEmpty(tbSearchInput.Text))
        //    {
        //        ListPeople(0, 15, allPeople);
        //    }
        //    else if (!string.IsNullOrEmpty(tbSearchInput.Text))
        //    {
        //        var possibleSearches =
        //            from person in dataManager.getAllPeople()
        //            where person.GetInfo().ToUpper().Contains(tbSearchInput.Text.ToUpper()) && !person.GetStillWorking
        //            select person;
        //        foreach (Person person in possibleSearches)
        //        {
        //            lbEmployeesList.Items.Add(person.GetInfo());
        //        }
        //    }


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

        private void btnRestoreEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult[] results = { DialogResult.Yes, DialogResult.Cancel };
                string userResponse = "";
                string message = "Are you sure you want to restore this employee?";
                if (results.Contains(ConfirmationBox(ref userResponse, message)))
                {
                    if (userResponse.Equals("Yes"))
                    {
                        //Person person = dataManager.FindPerson(lbEmployeesList.SelectedItem.ToString());
                        Person person = listToUse.FirstOrDefault(p => p.GetInfo().Equals(lbEmployeesList.SelectedItem.ToString()));
                        database.ChangeWorkingStatus(person);
                        MessageBox.Show("Employee has been restored!");
                        //this.allPeople = from p in dataManager.getAllPeople()
                        //                 where p.GetId() != loggedInUser.GetId() && !p.GetStillWorking
                        //                 select p;
                        tbSelectedUserInfo.ResetText();
                        ListPeople();
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

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void lbEmployeesList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (lbEmployeesList.SelectedItem != null)
                {
                    tbSelectedUserInfo.ResetText();
                    //Person person = dataManager.FindPerson(lbEmployeesList.SelectedItem.ToString());
                    Person person = listToUse.FirstOrDefault(p => p.GetInfo().Equals(lbEmployeesList.SelectedItem.ToString()));
                    tbSelectedUserInfo.Text = person.PersonDetailedInfo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
