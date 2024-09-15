using LogicLayer;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace MediaBazaarApp
{
    public partial class EditEmployeeInfo : Form
    {
        ManagerMenu managerMenu;
        PeopleManagement peopleManager;
        Person loggedInUser;
        ProductsDataAccessLayer database;
        private bool close_application;

        public EditEmployeeInfo(ManagerMenu managerMenu, PeopleManagement dataManager, Person loggedInUser, ProductsDataAccessLayer database)
        {
            try
            {
                this.managerMenu = managerMenu;
                this.peopleManager = dataManager;
                this.loggedInUser = loggedInUser;
                this.database = database;
                close_application = true;
                InitializeComponent();
                tbxPhoneNumber.Text = loggedInUser.PhoneNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string phoneNumber = tbxPhoneNumber.Text;
                string oldPassword = tbxPassword.Text;
                string newPassword = tbxNewPassword.Text;
                UserManager userManager = new UserManager();
                if (userManager.CheckUser(loggedInUser.getEmail(), oldPassword))
                {
                    if (cbxChangePassword.Checked)
                    {
                        peopleManager.ChangePassword(loggedInUser.GetId(), newPassword);
                    }
                    else
                    {
                        if (IsValidPhoneNumber(tbxPhoneNumber.Text))
                        {
                            peopleManager.UpdateUserPhoneNumber(loggedInUser, phoneNumber);
                        }
                        else
                        {
                            MessageBox.Show("Please input valid phone number");
                        }
                    }

                    if (cbxSecretQuestion.Checked)
                    {
                        peopleManager.SetSecretQuestion(loggedInUser, cmbSecretQuestion.Text, tbxSecretAnswer.Text);
                    }

                    MessageBox.Show("Changes have been saved");

                    close_application = false;
                    this.Close();
                    managerMenu.ShowLoginPage();
                }
                else
                {
                    MessageBox.Show("Wrong password");
                }
            }
            catch(Exception ex)
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

        private void cbxChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tbxNewPassword.Enabled = cbxChangePassword.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxSecretQuestion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tbxSecretAnswer.Enabled = cmbSecretQuestion.Enabled = cbxSecretQuestion.Checked;
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
                MessageBox.Show("No changes have been saved");
                close_application = false;
                this.Close();
                managerMenu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
                string pattern = @"^\+\d{1,3}\s?\d{10,}$";

                Match match = Regex.Match(phoneNumber, pattern);

                return match.Success;

        }
        private void tbxPhoneNumber_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(tbxPhoneNumber.Text))
            {
                if (IsValidPhoneNumber(tbxPhoneNumber.Text))
                {
                    tbxPhoneNumber.BackColor = Color.FromArgb(147, 255, 144);
                }
                else
                {
                    tbxPhoneNumber.BackColor = Color.FromArgb(252, 9, 35);
                }
            }
            else
            {
                tbxPhoneNumber.BackColor = Color.White;
            }
        }
    }
}
