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

namespace MediaBazaarApp
{
    public partial class ChangePriceForm : Form
    {
        Product product;
        SalesMenu salesManager;
        ProductManager productManager;
        public ChangePriceForm(SalesMenu salesManagerForm, ProductManager productmanager, Product selectedProduct)
        {
            try
            {
                this.salesManager = salesManagerForm;
                InitializeComponent();
                this.product = selectedProduct;
                this.productManager = productmanager;
                nudPrice.Value = Convert.ToDecimal(product.getPrice());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangePriceForm_Load(object sender, EventArgs e)
        {
            lblProduct.Text = product.Name;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                double price = Convert.ToDouble(nudPrice.Value);
                productManager.ModifyPrice(product, price);
                salesManager.UpdatePriceInListBox();
                this.Close();
                salesManager.Show();
                MessageBox.Show("Product price has been successfully changed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pbPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                salesManager.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
