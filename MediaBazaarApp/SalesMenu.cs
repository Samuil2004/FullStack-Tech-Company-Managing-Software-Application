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
using LogicLayer;
using DataAccessLayer;

namespace MediaBazaarApp
{
    public partial class SalesMenu : Form
    {
        ProductManager productManager;
        Product selectedProduct;
        ManagerMenu managerMenu;
        Person loggedInUser;
        public SalesMenu(ManagerMenu managermenu, Person loggedinUser, SQLDatabase sql)
        {
            try
            {
                productManager = new ProductManager();
                this.managerMenu = managermenu;
                this.loggedInUser = loggedinUser;
                InitializeComponent();
                int count = 0;
                foreach (Product p in productManager.getAllProducts())
                {
                    lbxProducts.Items.Add(p.getInfo());
                    count++;
                }
                lblNumberOfResults.Text = count.ToString();
                cmbCategory.DataSource = Enum.GetValues(typeof(ProductCategory));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SalesMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnChangePrice_Click(object sender, EventArgs e)
        {
            try
            {
                ChangePriceForm addProduct = new ChangePriceForm(this, productManager, selectedProduct);
                addProduct.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdatePriceInListBox()
        {
            try
            {
                lbxProducts.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = tbxProductName.Text.ToUpper();
                string category = cmbCategory.Text;
                int year;
                if (tbxYear.Text != "")
                {
                    year = Convert.ToInt32(tbxYear.Text);
                }
                else
                {
                    year = 0;
                }
                double minPrice = Convert.ToDouble(nudMinPrice.Value);
                double maxPrice = Convert.ToDouble(nudMaxPrice.Value);

                List<Product> filteredProducts = productManager.getAllProducts()
                    .Where(p =>
                    (string.IsNullOrEmpty(productName) || p.Name.StartsWith(productName)) &&
                    (string.IsNullOrEmpty(category) || p.getCategory().ToString().StartsWith(category)) &&
                    (year == 0 || p.Year.ToString().StartsWith(year.ToString())) &&
                    (p.getPrice() >= minPrice && p.getPrice() <= maxPrice)
                    )
                    .OrderBy(p => p.Name)
                    .ThenBy(p => p.getCategory().ToString())
                    .ThenBy(p => p.Year)
                    .ThenBy(p => p.getPrice())
                    .ThenBy(p => p.QuantityinStock)
                    .ToList();

                lblNumberOfResults.Text = filteredProducts.Count.ToString();

                lbxProducts.Items.Clear();
                foreach (Product product in filteredProducts)
                {
                    lbxProducts.Items.Add(product.getInfo());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selected;
                if (lbxProducts.SelectedIndex >= 0 && lbxProducts.SelectedIndex < productManager.getAllProducts().Count)
                {
                    // Get the values from Product
                    selected = lbxProducts.SelectedItem.ToString();
                    foreach (Product p in productManager.getAllProducts())
                    {
                        if (selected.Contains("Id: " + p.getId() + ","))
                        {
                            selectedProduct = p;
                        }
                    }
                    string name = selectedProduct.Name.ToString();
                    int id = selectedProduct.getId();
                    string description = selectedProduct.Description;
                    int year = selectedProduct.Year;
                    double price = selectedProduct.getPrice();
                    int maxStock = selectedProduct.getMaxCapacity();
                    ProductCategory category = selectedProduct.getCategory();

                    panelProduct.Visible = true;

                    // Assign values to the labels
                    lblSelectedProduct.Text = name;
                    lblYear.Text = year.ToString();
                    lblProductNumber.Text = id.ToString();
                    lblPrice.Text = price.ToString();
                    lblCategory.Text = category.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                managerMenu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
