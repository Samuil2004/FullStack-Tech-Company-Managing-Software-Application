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

namespace MediaBazaarApp
{
    public partial class FloorWorkersMenu : Form
    {
        PeopleManagement dataManager;
        Person loggedInUser;
        ProductsDataAccessLayer sql;
        loginForm logInPage;
        private bool close_application;
        public FloorWorkersMenu(loginForm logInPage, Person loggedInUser, ProductsDataAccessLayer sql)
        {
            try
            {
                InitializeComponent();
                this.WindowState = FormWindowState.Maximized;
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
        }
        private void CheckLoggedInUser()
        {
            try
            {
                if (loggedInUser.GetRole == Role.Floor_Consultant && loggedInUser.GetDepartment == Department.Depo)
                {
                    pbDepo.Visible = true;
                    btnManageDepo.Visible = true;
                }
                if (loggedInUser.GetRole == Role.Floor_Consultant && loggedInUser.GetDepartment == Department.Sales)
                {
                    pbDepo.Visible = true;
                    ManageStoreButton.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FloorWorkersMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnManageDepo_Click(object sender, EventArgs e)
        {
            try
            {
                DepotWorkerForm depoWorkerForm = new DepotWorkerForm(this, loggedInUser, sql);
                this.Hide();
                depoWorkerForm.Show();
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
                logInPage.Show();
                this.Hide();
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

        private void ManageStoreButton_Click(object sender, EventArgs e)
        {
            try
            {
                SalesRepresentative salesRepresentative = new SalesRepresentative(loggedInUser);
                salesRepresentative.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
