using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkTasks_Individual_Kristof_Szabo;
using DataAccessLayer;
using ClassLibrary;
using LogicLayer;


namespace MediaBazaarApp
{
    public partial class ManagerMenu : Form
    {
        PeopleManagement dataManager;
        Person loggedInUser;
        SQLDatabase sql;
        loginForm logInPage;
        private bool close_application;

        public ManagerMenu(loginForm logInPage, Person loggedInUser, SQLDatabase sql)
        {
            try
            {
                InitializeComponent();

                dataManager = new PeopleManagement();
                this.loggedInUser = loggedInUser;
                this.sql = sql;
                this.logInPage = logInPage;
                close_application = true;
                CheckLoggedInUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //if (loggedInUser.GetDepartment != Department.Floor_Workers)
            //{
            //    btnAllEmployeesManagerMenu.Visible = false;
            //    btnManageScheduleManagerMenu.Visible = false;
            //    btnArchive.Visible = false;
            //    pbCalendar.Visible = false;
            //    pbTeam.Visible = false;
            //    pbArchive.Visible = false;
            //}
            //else
            //{
            //    pbProduct.Visible = false;
            //    btnManageStock.Visible = false;
            //}

        }
        private void CheckLoggedInUser()
        {
            try
            {
                if (loggedInUser.GetRole == Role.CEO)
                {
                    pbProduct.Visible = false;
                    btnManageStock.Visible = false;
                    btnAllEmployeesManagerMenu.Text = "All Employees";
                }
                if (loggedInUser.GetRole == Role.Manager && loggedInUser.GetDepartment == Department.Products)
                {
                    pbProduct.Visible = true;
                    btnManageStock.Visible = true;
                    pbTeam.Visible = false;
                    btnAllEmployeesManagerMenu.Visible = false;
                    pbArchive.Visible = false;
                    btnArchive.Visible = false;
                }
                if (loggedInUser.GetRole == Role.Manager && loggedInUser.GetDepartment == Department.Sales)
                {
                    pbProduct.Visible = false;
                    btnManageStock.Visible = false;
                    pbTeam.Visible = true;
                    btnAllEmployeesManagerMenu.Visible = true;
                    pbArchive.Visible = false;
                    btnArchive.Visible = false;
                    btnManagePrice.Visible = true;
                    pbSalesMenu.Visible = true;
                    btnManagePrice.Visible = true;
                    pbSalesMenu.Visible = true;
                }
                if (loggedInUser.GetRole == Role.Manager && loggedInUser.GetDepartment == Department.Depo)
                {
                    pbProduct.Visible = false;
                    btnManageStock.Visible = false;
                    pbTeam.Visible = true;
                    btnAllEmployeesManagerMenu.Visible = true;
                    pbArchive.Visible = false;
                    btnArchive.Visible = false;
                    DepotRestockingButton.Visible = true;
                    pbDepoRestocking.Visible = true;
                }
                if (loggedInUser.GetRole == Role.Floor_Consultant && loggedInUser.GetDepartment == Department.Sales)
                {
                    pbProduct.Visible = false;
                    btnManageStock.Visible = false;
                    pbTeam.Visible = true;
                    btnAllEmployeesManagerMenu.Visible = true;
                    pbArchive.Visible = false;
                    btnArchive.Visible = false;
                    btnManagePrice.Visible = true;
                    pbSalesMenu.Visible = true;
                    btnManagePrice.Visible = true;
                    pbSalesMenu.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnManageScheduleManagerMenu_Click(object sender, EventArgs e)
        {
            try
            {
                ManagerManageShdeule manageSchdulePage = new ManagerManageShdeule(this, dataManager, loggedInUser, sql);
                this.Hide();
                manageSchdulePage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAllEmployeesManagerMenu_Click(object sender, EventArgs e)
        {
            try
            {
                AllEmployeesPage allEmployeesPage = new AllEmployeesPage(this, dataManager, loggedInUser, sql);
                this.Hide();
                allEmployeesPage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbAccountIcon_Click(object sender, EventArgs e)
        {
            try
            {
                EditEmployeeInfo editEmployeeInfo = new EditEmployeeInfo(this, dataManager, loggedInUser, sql);
                this.Hide();
                editEmployeeInfo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManagerMenu_FormClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnManageStock_Click(object sender, EventArgs e)
        {
            try
            {
                StockManagerForm stockManagerForm = new StockManagerForm(this);
                this.Hide();
                stockManagerForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            try
            {
                ArchivePage archivePage = new ArchivePage(this, dataManager, loggedInUser, sql);
                this.Hide();
                archivePage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult[] results = { DialogResult.Yes, DialogResult.Cancel };
                string userResponse = "";
                string message = "Are you sure you want to log out?";
                if (results.Contains(ConfirmationBox(ref userResponse, message)))
                {
                    if (userResponse.Equals("Yes"))
                    {
                        logInPage.Show();
                        this.Hide();
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
        public void ShowLoginPage()
        {
            try
            {
                logInPage.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnManagePrice_Click(object sender, EventArgs e)
        {
            try
            {
                SalesMenu salesMenu = new SalesMenu(this, loggedInUser, sql);
                this.Hide();
                salesMenu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DepotRestockingButton_Click(object sender, EventArgs e)
        {
            try
            {
                DepotRestockingPage depotRestockingPage = new DepotRestockingPage(this, loggedInUser, sql);
                this.Hide();
                depotRestockingPage.Show();

                SQLDatabase db = new SQLDatabase();
                foreach (Order order in db.GetAllOrders())
                {
                    if (DateTime.Now >= order.ArrivalDate && order.status == "On the way")
                    {
                        MessageBox.Show($"New delivery Arrived (Order number: 00{order.OrderId}) ");
                        db.ChangeOrderStatus(order.OrderId, "Delivered");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
