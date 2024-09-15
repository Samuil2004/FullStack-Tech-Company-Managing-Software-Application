using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using LogicLayer;


namespace MediaBazaarApp
{
    public partial class AddOrEditProduct : Form
    {
        ListBox productList;
        ProductManager productManager;
        Product product;
        Product newProduct;

        StockManagerForm stockManagerForm;
        bool edit = false;

        bool close_application;
        public AddOrEditProduct(StockManagerForm stockManagerForm, ProductManager productManager, ListBox productList)
        {
            try
            {
                this.stockManagerForm = stockManagerForm;
                close_application = true;
                InitializeComponent();
                this.productList = productList;
                this.productManager = productManager;
                this.Text = "Add Product";
                cmbCategory.DataSource = Enum.GetValues(typeof(ProductCategory));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public AddOrEditProduct(StockManagerForm stockManagerForm, ProductManager productManager, Product selectedProduct, ListBox productList)
        {
            try
            {
                this.stockManagerForm = stockManagerForm;
                close_application = true;
                InitializeComponent();
                this.productList = productList;
                this.productManager = productManager;
                this.newProduct = selectedProduct;
                edit = true;
                this.Text = "Edit Product";

                cmbCategory.DataSource = Enum.GetValues(typeof(ProductCategory));
                cmbCategory.SelectedItem = newProduct.getCategory();

                tbxProductName.Text = newProduct.Name;
                nudYear.Value = newProduct.Year;
                tbxDescription.Text = newProduct.Description;
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
                if (edit == true)
                {
                    string name = tbxProductName.Text;
                    string description = tbxDescription.Text;
                    int year = Convert.ToInt32(nudYear.Value);
                    ProductCategory category = (ProductCategory)cmbCategory.SelectedItem;
                    productManager.ModifyProductVariables(newProduct, name, year, description, category);
                    productList.Items.Clear();

                    foreach (Product product in productManager.getAllProducts())
                    {
                        productList.Items.Add(product.getInfo());
                    }
                    this.Close();
                    stockManagerForm.Show();
                    MessageBox.Show("Product details have been successfully changed.");
                }
                else
                {
                    if (productList.Items.Count > 0)
                    {
                        productList.Items.Clear();
                    }
                    string name = tbxProductName.Text;
                    int year = Convert.ToInt32(nudYear.Text);
                    string description = tbxDescription.Text;
                    ProductCategory selectedCategory = (ProductCategory)cmbCategory.SelectedItem;
                    string barcode = tbxBarcode.Text;
                    int maxCapacity = Convert.ToInt32(nudMaxCapacity.Value);
                    productManager.addNewProduct(name, year, description, selectedCategory, barcode, maxCapacity);
                    foreach (Product product in productManager.getAllProducts())
                    {
                        productList.Items.Add(product.getInfo());
                    }
                    MessageBox.Show("Product has been successfully added");
                    this.Close();
                    stockManagerForm.Show();
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
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void pbPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("No changes have been saved");
                close_application = false;
                this.Close();
                stockManagerForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
