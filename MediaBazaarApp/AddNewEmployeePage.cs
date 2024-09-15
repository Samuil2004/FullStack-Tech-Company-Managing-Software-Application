using Microsoft.IdentityModel.Tokens;
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
using LogicLayer;
namespace MediaBazaarApp
{
    public partial class AddNewEmployeePage : Form
    {
        AllEmployeesPage allEmployeesPage;
        Person loggedInUser;
        PeopleManagement peopleManager;
        private bool close_application;
        ProductsDataAccessLayer database;


        public AddNewEmployeePage(AllEmployeesPage allEmployeesPage, Person loggedInUser, PeopleManagement dataManager, ProductsDataAccessLayer database)
        {
            this.allEmployeesPage = allEmployeesPage;
            this.loggedInUser = loggedInUser;
            this.peopleManager = dataManager;
            InitializeComponent();
            close_application = true;
            cbRole.Enabled = false;
            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            {
                cbGender.Items.Add(gender);
            }
            foreach (Department department in Enum.GetValues(typeof(Department)))
            {
                if (department != Department.Owners)
                {
                    cbDepartment.Items.Add(department);
                }
            }
            foreach (Role role in Enum.GetValues(typeof(Role)))
            {
                if (role != Role.CEO)
                {
                    cbRole.Items.Add(role);
                }
            }
            this.database = database;
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

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidEmail(tbEmail.Text))
                {
                    if (peopleManager.IsEmailAvailable(tbEmail.Text))
                    {
                        if (ContainsOnlyLetters(tbFirstName.Text))
                        {
                            if (ContainsOnlyLetters(tbLastName.Text))
                            {
                                if (IsValidPhoneNumber(tbPhoneNumber.Text))
                                {
                                    if (!string.IsNullOrEmpty(tbEmail.Text) && !string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbPhoneNumber.Text) && !string.IsNullOrEmpty(tbEmail.Text) && cbGender.SelectedItem != null && cbDepartment.SelectedItem != null && cbRole.SelectedItem != null && nmWage.Value != 0)
                                    {
                                        Gender selectedGender = (Gender)Enum.Parse(typeof(Gender), cbGender.SelectedItem.ToString());
                                        Department selectedDepartment = (Department)Enum.Parse(typeof(Department), cbDepartment.SelectedItem.ToString());
                                        Role selectedRole = (Role)Enum.Parse(typeof(Role), cbRole.SelectedItem.ToString());
                                        Person manager = peopleManager.FindDepartmentManager(selectedDepartment);
                                        int manager_id = manager.GetId();
                                        int floor = Convert.ToInt32(nmFloor.Value);
                                        int id = peopleManager.GetHighestId();
                                        peopleManager.addNewPerson(id, tbEmail.Text, tbFirstName.Text, tbLastName.Text, tbPhoneNumber.Text, selectedGender, DateTime.Today, manager_id, selectedDepartment, selectedRole, Convert.ToDouble(nmWage.Value), floor);
                                        PrintMessage($"Employee was sucessfully added. \nId: {id}");
                                        close_application = false;
                                        this.Close();
                                        allEmployeesPage.ReloadList();
                                        allEmployeesPage.Show();
                                    }
                                    else
                                    {
                                        PrintMessage("Please fill in all fields");
                                    }
                                }
                                else
                                {
                                    PrintMessage("Please input valid phone number");
                                }
                            }
                            else
                            {
                                PrintMessage("Please input valid last name");
                            }
                        }
                        else
                        {
                            PrintMessage("Please input valid first name");
                        }
                    }
                    else
                    {
                        PrintMessage("There email is already used");
                    }
                }
                else
                {
                    PrintMessage("Please input valid email");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PrintMessage(string message)
        {
            MessageBox.Show($"{message}");
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbEmail.Text))
                {

                    if (IsValidEmail(tbEmail.Text) && peopleManager.IsEmailAvailable(tbEmail.Text))
                    {
                        tbEmail.BackColor = Color.FromArgb(147, 255, 144);
                    }
                    else
                    {
                        tbEmail.BackColor = Color.FromArgb(252, 9, 35);
                    }
                }
                else
                {
                    tbEmail.BackColor = Color.White;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tbPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbPhoneNumber.Text))
                {
                    if (IsValidPhoneNumber(tbPhoneNumber.Text))
                    {
                        tbPhoneNumber.BackColor = Color.FromArgb(147, 255, 144);
                    }
                    else
                    {
                        tbPhoneNumber.BackColor = Color.FromArgb(252, 9, 35);
                    }
                }
                else
                {
                    tbPhoneNumber.BackColor = Color.White;
                }
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

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            Match match = Regex.Match(email, pattern);

            return match.Success;
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbRole.Enabled = true;
            cbRole.SelectedIndex = -1;
            cbRole.Items.Clear();
            if (cbDepartment.SelectedItem.ToString() == Department.Products.ToString() || cbDepartment.SelectedItem.ToString() == Department.Depo.ToString())
            {
                cbRole.Items.Add(Role.Floor_Consultant);
                cbRole.Items.Add(Role.Manager);
            }
            else if (cbDepartment.SelectedItem.ToString() == Department.Sales.ToString())
            {
                cbRole.Items.Add(Role.Floor_Consultant);
                cbRole.Items.Add(Role.Manager);
                cbRole.Items.Add(Role.Security);
                cbRole.Items.Add(Role.Cashier);
            }
        }

        private void tbFirstName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbFirstName.Text))
                {
                    if (ContainsOnlyLetters(tbFirstName.Text))
                    {
                        tbFirstName.BackColor = Color.FromArgb(147, 255, 144);
                    }
                    else
                    {
                        tbFirstName.BackColor = Color.FromArgb(252, 9, 35);
                    }
                }
                else
                {
                    tbFirstName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbLastName.Text))
            {
                if (ContainsOnlyLetters(tbLastName.Text))
                {
                    tbLastName.BackColor = Color.FromArgb(147, 255, 144);
                }
                else
                {
                    tbLastName.BackColor = Color.FromArgb(252, 9, 35);
                }
            }
            else
            {
                tbLastName.BackColor = Color.White;
            }
        }
        public static bool ContainsOnlyLetters(string input)
        {
            string pattern = @"^[a-zA-Z]+$";

            return Regex.IsMatch(input, pattern);
        }

        private void pbPrevPage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No changes have been saved");
            close_application = false;
            this.Close();
            allEmployeesPage.Show();
        }
    }
}
