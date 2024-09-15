using LogicLayer;
using MediaBazaarApp;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Reflection;
using DataAccessLayer;

namespace WorkTasks_Individual_Kristof_Szabo
{
    public partial class loginForm : Form
    {
        PeopleManagement peopleManager = new PeopleManagement();
        ProductsDataAccessLayer productManager = new ProductsDataAccessLayer();
        Person loggedInUser;
        UserManager userManager = new UserManager();
        private bool close_application;
        private int counter;

        public loginForm()
        {
            InitializeComponent();
            close_application = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = textBoxUsername.Text;
                string password = textBoxPassword.Text;
                if (userManager.CheckUser(email, password))
                {
                    loggedInUser = peopleManager.ReadPerson(email);
                    if (loggedInUser.GetRole == Role.Manager || loggedInUser.GetRole == Role.CEO)
                    {
                        this.Hide();
                        ManagerMenu managerMenu = new ManagerMenu(this, loggedInUser, productManager);
                        managerMenu.Show();
                    }
                    else
                    {
                        this.Hide();
                        FloorWorkersMenu floorWorkers = new FloorWorkersMenu(this, loggedInUser, productManager);
                        floorWorkers.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid credentials");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database is not repsonding at the moment. \n Please, try again later!");
            }
        }

        private void buttonForgetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBoxUsername.Text))
                {
                    ForgottenPassword forgottenPassword = new ForgottenPassword(this, textBoxUsername.Text);
                    forgottenPassword.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please input username first");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            //HR MANAGER
            //textBoxUsername.Text = "hrManager@gmail.com";
            //textBoxPassword.Text = "password0";

            //PRODUCT MANAGER
            //textBoxUsername.Text = "productManager@example.com";
            //textBoxPassword.Text = "password31";

            //JR PRODUCT MANAGER
            //textBoxUsername.Text = "c.ronaldo@gmail.com";
            //textBoxPassword.Text = "Cristiano";

            //SALES MANAGER
            textBoxUsername.Text = "alice.smith@example.com";
            textBoxPassword.Text = "password111";

            //JR SALES MANAGER
            //textBoxUsername.Text = "l.messi@gmail.com";
            //textBoxPassword.Text = "Lionel";

            //DEPO MANAGER
            //textBoxUsername.Text = "depoManager@gmail.com";
            //textBoxPassword.Text = "password190";

            //JR DEPO MANAGER
            //textBoxUsername.Text = "h.stoichkov@gmail.com";
            //textBoxPassword.Text = "Hristo";

            //SALES REPRESENTATIVE
            //textBoxUsername.Text = "mary.jones@example.com";
            //textBoxPassword.Text = "password3";

            //DEPO WORKER
            //textBoxUsername.Text = "depoWorker@gmail.com";
            //textBoxPassword.Text = "password191";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            counter = 0;
            timer1.Start();
            pictureBox2.Visible = false;
        }



        private void CheckPassword()
        {
            if (counter < 30)
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
                timer1.Stop();
                counter = 0;
                pictureBox2.Visible = true;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckPassword();
            counter = counter + 1;
        }

        private void icon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}