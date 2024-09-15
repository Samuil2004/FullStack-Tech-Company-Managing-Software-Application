using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;
using MediaBazaarApp;

namespace ClockingIn
{
    public partial class ClockingIn : Form
    {
        ShiftManager shiftManager;
        PeopleManagement peopleManagement;
        int i;
        public ClockingIn()
        {
            InitializeComponent();
            shiftManager = new ShiftManager();
            peopleManagement = new PeopleManagement();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (i == 20)
            {
                lblWelcomeMessage.Text = "";
                timer.Enabled = false;
            }
            else
            {
                i++;
            }
        }

        private void tbxEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && timer.Enabled == false && tbxEmployeeID.Text != "")
            {
                int id = Convert.ToInt32(tbxEmployeeID.Text);
                string message = shiftManager.ClockInOrOut(id);
                tbxEmployeeID.Text = "";
                lblWelcomeMessage.Text = peopleManagement.FindPersonName(id) + message;
                i = 0;
                timer.Enabled = true;
            }
        }

        private void tbxEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
