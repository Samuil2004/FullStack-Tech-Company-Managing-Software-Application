using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using LogicLayer;

namespace MediaBazaarApp
{
    public partial class StockManagerForm : Form
    {
        ProductManager productManager;
        Product selectedProduct;

        ManagerMenu managerMenu;
        bool close_application;
        public StockManagerForm(ManagerMenu managerMenu)
        {
            try
            {
                this.managerMenu = managerMenu;
                close_application = true;
                productManager = new ProductManager();
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = tbxProductName.Text;
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
                int minStock = Convert.ToInt32(nudMinPrecent.Value);
                int maxStock = Convert.ToInt32(nudMaxPrecent.Value);

                List<Product> filteredProducts = productManager.getAllProducts()
                    .Where(p =>
                    (string.IsNullOrEmpty(productName) || p.Name.StartsWith(productName)) &&
                    (string.IsNullOrEmpty(category) || p.getCategory().ToString().StartsWith(category)) &&
                    (year == 0 || p.Year == year) &&
                    (p.QuantityinStock >= minStock && p.QuantityinStock <= maxStock) &&
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

        private void btnCreateNewProduct_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrEditProduct addProduct = new AddOrEditProduct(this, productManager, lbxProducts);
                addProduct.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrEditProduct editForm = new AddOrEditProduct(this, productManager, selectedProduct, lbxProducts);
                editForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStockProgressBar()
        {
            try
            {
                if (selectedProduct != null)
                {
                    int currentStock = selectedProduct.QuantityinStock;
                    int maxStock = selectedProduct.getMaxCapacity();

                    int stockPercentage = (int)((double)currentStock / maxStock * 100);

                    pgbStock.Value = stockPercentage;
                    lblStockPercentage.Text = stockPercentage.ToString() + "%";
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
                    if (selectedProduct.QuantityinStock > 0)
                    {
                        UpdateStockProgressBar();
                    }

                    // Set the visibility of the labels to true
                    lblSelectedProduct.Visible = true;
                    lblYear.Visible = true;
                    lblProductNumber.Visible = true;
                    lblProductDescription.Visible = true;
                    lblPrice.Visible = true;
                    lblMaxStockCapacity.Visible = true;
                    lblCategory.Visible = true;

                    // Assign values to the labels
                    lblSelectedProduct.Text = name;
                    lblYear.Text = year.ToString();
                    lblProductNumber.Text = id.ToString();
                    lblProductDescription.Text = description;
                    lblPrice.Text = price.ToString();
                    lblMaxStockCapacity.Text = maxStock.ToString();
                    lblCategory.Text = category.ToString();

                }

                // Set the visibility of the other labels to true
                lblStockPercentage.Visible = true;
                lblS.Visible = true;
                lblP.Visible = true;
                lblC.Visible = true;
                lblY.Visible = true;
                lblProductDescriptionLabel.Visible = true;
                lblProductDescription.Visible = true;
                lblPr.Visible = true;
                lblMaxS.Visible = true;
                lblStck.Visible = true;
                pgbStock.Visible = true;
                btnEditDetails.Visible = true;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                close_application = false;
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
