using ClassLibrary;
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
using LogicLayer;

namespace MediaBazaarApp
{
    public partial class DepotWorkerForm : Form
    {
        ProductManager depotManager;
        FloorWorkersMenu floorWorkerMenu;
        bool close_application;
        Person loggedInUser;
        SQLDatabase db;

        // Store restocking 
        List<RestockingRequest> StoreRestockingRequests;
        public RestockingRequest SelectedRequest;

        // Depo restocking 

        Product selectedProduct;

        // ManagerMenu managerMenu;
        public DepotWorkerForm(FloorWorkersMenu floorworkerMenu, Person loggedinUser, SQLDatabase sql)
        {
            try
            {
                this.floorWorkerMenu = floorworkerMenu;
                close_application = true;
                depotManager = new ProductManager();
                // this.managerMenu = managerMenu;
                InitializeComponent();
                this.loggedInUser = loggedinUser;
                this.db = sql;
                UpdateRestockRequests();
                UpdateProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateRestockRequests()
        {
            try
            {
                StoreRestockingRequests = db.GetRequestsFromSalesRepresentative();

                StoreRestockinglistBox.Items.Clear();
                foreach (RestockingRequest r in StoreRestockingRequests)
                {
                    StoreRestockinglistBox.Items.Add(r);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateProductList()
        {
            try
            {
                int count = 0;
                foreach (Product p in depotManager.getDepotProducts())
                {
                    lbxDepoProducts.Items.Add(p.getInfo());
                    count++;
                }
                lblNumberOfResults.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DepoWorkerForm_Load(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = tbxProductName.Text;
                int stock = Convert.ToInt32(nudStock.Value);
                List<Product> filteredProducts = depotManager.getAllProducts()
                    .Where(p =>
                    (string.IsNullOrEmpty(productName) || p.Name.StartsWith(productName)) &&
                    (p.QuantityinStock >= stock))
                    .OrderBy(p => p.Name)
                    .ThenBy(p => p.QuantityinStock)
                    .ToList();

                lblNumberOfResults.Text = filteredProducts.Count.ToString();

                lbxDepoProducts.Items.Clear();
                foreach (Product product in filteredProducts)
                {
                    lbxDepoProducts.Items.Add(product.getInfo());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbxDepoProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selected;
                if (lbxDepoProducts.SelectedIndex >= 0 && lbxDepoProducts.SelectedIndex < depotManager.getAllProducts().Count)
                {
                    selected = lbxDepoProducts.SelectedItem.ToString();
                    foreach (Product p in depotManager.getAllProducts())
                    {
                        if (selected.Contains("Id: " + p.getId() + ","))
                        {
                            selectedProduct = p;
                        }
                    }
                    SelectedDepoProductLabel.Text = $" Selected product: {selectedProduct.Name} ({selectedProduct.Year})";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                floorWorkerMenu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void StoreRestockinglistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (StoreRestockinglistBox.SelectedIndex >= 0 && StoreRestockinglistBox.SelectedIndex < StoreRestockingRequests.Count())
                {
                    foreach (RestockingRequest r in StoreRestockingRequests)
                    {
                        if (r.ToString() == StoreRestockinglistBox.SelectedItem.ToString())
                        {
                            SelectedRequest = r;
                        }
                    }
                    lblProductName.Text = SelectedRequest.ProductName;
                    lblQuantity.Text = SelectedRequest.Quantity.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ReplenishStoreStockButton_Click(object sender, EventArgs e)
        {
            try
            {
                int QuantityInDepo = db.GetDepoProductQuantityByID(SelectedRequest.ProductID);
                if (QuantityInDepo >= SelectedRequest.Quantity)
                {
                    int QuantityLeftInDepo = QuantityInDepo - SelectedRequest.Quantity;
                    int NewStoreProductQuantity = db.GetStoreProductQuantityByID(SelectedRequest.ProductID) + SelectedRequest.Quantity;
                    db.UpdateStoreProductQuantity(SelectedRequest.ProductID, NewStoreProductQuantity);
                    db.DeleteRequest(SelectedRequest.ProductID, SelectedRequest.Quantity);
                    db.UpdateDepoProductQuantity(SelectedRequest.ProductID, QuantityLeftInDepo);
                    MessageBox.Show("Request succesfully completed!");
                    UpdateRestockRequests();
                }
                else
                {
                    MessageBox.Show(" Not enough stock in Depo ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RequestNewDepoStockButton_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity = db.GetDepoProductMaxQuantityByID(selectedProduct.getId()) - selectedProduct.QuantityinStock;
                if (quantity != 0)
                {
                    if (db.CheckRequestAlreadyExists(selectedProduct.getId(), "Depot worker") == false)
                    {
                        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
                        db.CreateNewRestockRequest(selectedProduct.getId(), selectedProduct.Name, quantity, currentDate, "Depot worker");
                        MessageBox.Show("Request sent");
                    }
                    else
                    {
                        MessageBox.Show("A restocking request for this product was already sent");
                    }
                }
                else { MessageBox.Show(""); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
