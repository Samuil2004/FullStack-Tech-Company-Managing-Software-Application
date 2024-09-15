using System;
using LogicLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkTasks_Individual_Kristof_Szabo;

namespace MediaBazaarApp
{
    public partial class ForgottenPassword : Form
    {
        private Person person;
        private loginForm loginForm;
        PeopleManagement peopleManagement;
        private bool close_application;

        public ForgottenPassword(loginForm loginForm, string emailInput)
        {
            try
            {
                InitializeComponent();
                this.loginForm = loginForm;
                peopleManagement = new PeopleManagement();
                tbxEmail.Text = emailInput;
                close_application = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmitSecret_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;
                Person foundPerson = peopleManagement.FindPerson(tbxEmail.Text);
                if (foundPerson != null)
                {
                    person = foundPerson;
                    found = true;
                }
                else
                {
                    MessageBox.Show("Person could not be found");
                }
                if (found)
                {
                    string secretQuestion = person.SecretQuestion;
                    string secretAnswer = person.SecretAnswer;
                    if (cmbSecretQuestion.Text == person.SecretQuestion && tbxSecretAnswer.Text == person.SecretAnswer)
                    {
                        lblEmail.Visible = false;
                        tbxEmail.Visible = false;
                        label1.Visible = false;
                        cmbSecretQuestion.Visible = false;
                        btnSubmitSecret.Visible = false;
                        label2.Visible = false;
                        tbxSecretAnswer.Visible = false;

                        lblNewPassword.Visible = true;
                        tbxNewPassword.Visible = true;
                        btnSubmitPassword.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid secret question and answer");
                    }
                }
            }
            catch(Exception ex)
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
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmitPassword_Click(object sender, EventArgs e)
        {
            try
            {
                string newPassword = tbxNewPassword.Text;
                if (!string.IsNullOrEmpty(newPassword))
                {
                    peopleManagement.ChangePassword(person.GetId(), newPassword);
                    MessageBox.Show("Password has been sucessfully saved");
                    close_application = false;

                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password must be inserted");
                }
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
                loginForm.Show();
            }
            else
            {
                return;
            }
        }
    }
}
