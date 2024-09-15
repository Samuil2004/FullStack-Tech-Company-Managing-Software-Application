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
    public partial class UpdateSalary : Form
    {
        Person selectedPerson;
        PeopleManagement peopleManager;
        AllEmployeesPage allEmployeesPage;
        public UpdateSalary(Person selectedPerson, PeopleManagement peopleManager, AllEmployeesPage allEmployeesPage)
        {
            try
            {
                InitializeComponent();
                this.selectedPerson = selectedPerson;
                this.peopleManager = peopleManager;
                this.allEmployeesPage = allEmployeesPage;
                labelCurrentSalary.Text = selectedPerson.GetWage.ToString();
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
                if (nmNewWage.Value != 0)
                {
                    peopleManager.UpdateWage(selectedPerson, Convert.ToDouble(nmNewWage.Value));
                    allEmployeesPage.Updatelist();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please input new wage");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbPrevPage_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("No changes have been saved");
        }

    }
}
