using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarApp
{
    public partial class Alert : Form
    {

        private string message;

        public Alert(string message)
        {
            try { 
            InitializeComponent();
            this.message = message;
            labelMessage.Text = message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAgree_Click(object sender, EventArgs e)
        {

        }
    }
}
