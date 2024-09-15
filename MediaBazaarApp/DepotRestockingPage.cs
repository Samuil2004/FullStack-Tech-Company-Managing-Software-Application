using ClassLibrary;
using LogicLayer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using WorkTasks_Individual_Kristof_Szabo;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MediaBazaarApp
{
    public partial class DepotRestockingPage : Form
    {
        DataAccessLayer.ProductsDataAccessLayer db;
        ManagerMenu managerMenu;
        Person loggedUser;

        Order order;

        OrderItem selectedCartItem;
        ProductManager depotManager;

        List<RestockingRequest> requests;
        List<RestockingRequest> filteredRequests;
        RestockingRequest selectedRequest;
        int currentRequestIndex;
        bool filterBySupplier;

        public DepotRestockingPage(ManagerMenu managerMenu, Person loggedInUser, DataAccessLayer.ProductsDataAccessLayer sql)
        {
            try
            {
                InitializeComponent();
                depotManager = new ProductManager();
                order = new Order();
                this.db = sql;
                this.managerMenu = managerMenu;
                this.loggedUser = loggedInUser;

                filterBySupplier = false;
                LoadRequests();

                SupplierComboBox.SelectionChangeCommitted += new EventHandler(SupplierComboBox_SelectionChangeCommitted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SupplierComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                FilterRequestsBySupplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadRequests()
        {
            try
            {
                requests = db.GetRequestsFromDepoWorker();
                filteredRequests = new List<RestockingRequest>(requests);

                LoadAllSuppliers();

                if (requests.Count == 0)
                {
                    RequestsPanel.Visible = false;
                    NoRequestsPanel.Visible = true;
                    SupplierLimitErrorPanel.Visible = false;
                }
                else
                {
                    PageNumberLabel.Text = $"{1}/{filteredRequests.Count}";
                    if (requests.Count > 1 && requests.IndexOf(selectedRequest) != filteredRequests.Count - 1)
                    {
                        NextRequestButton.Enabled = true;
                    }
                    currentRequestIndex = 0;
                    selectedRequest = filteredRequests[currentRequestIndex];
                    ShowSelectedRequest();
                    HighlightSupplierForSelectedRequest();
                    FilterRequestsBySupplier();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadAllSuppliers()
        {
            try
            {
                SupplierComboBox.Items.Clear();
                HashSet<string> allSuppliers = new HashSet<string>();

                foreach (var request in requests)
                {
                    var suppliers = db.GetSupplierNamesByProductID(request.ProductID);
                    foreach (var supplier in suppliers)
                    {
                        allSuppliers.Add(supplier);
                    }
                }

                foreach (var supplier in allSuppliers)
                {
                    SupplierComboBox.Items.Add(supplier);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            managerMenu.Show();
        }

        public OrderItem GetOrderItemByCartItemString(string s)
        {
            return order.OrderItems.FirstOrDefault(orderItem => orderItem.GetOrderItemString() == s);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (order.OrderItems.Count > 0)
                {
                    ProcessCheckout();
                }
                else
                {
                    MessageBox.Show("Add one or more products to your cart");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcessCheckout()
        {
            try
            {
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    var activeRequest = requests.FirstOrDefault(request => request.ProductID == orderItem.product.getId());
                    if (activeRequest != null)
                    {
                        db.DeleteRequest(activeRequest.ProductID, activeRequest.Quantity);
                        requests.Remove(activeRequest);
                    }
                }

                int orderId = db.GetOrderCount() + 1;
                string status = "On the way";
                db.CreateNewOrder(orderId, SupplierComboBox.Text, DateTime.Now.Date, DateTime.Now.Date.AddDays(2), status);

                foreach (OrderItem orderItem in order.OrderItems)
                {
                    db.ChangeProductQuantity(orderItem.product.getId(), orderItem.product.QuantityinStock + orderItem.Quantity);
                    db.CreateNewOrderItem(orderId, orderItem.product.getId(), orderItem.Quantity);
                }

                MessageBox.Show($"Your order has been sent. Estimated arrival time is {DateTime.Now.AddDays(3)}");
                ResetOrderState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetOrderState()
        {
            try
            {
                order.OrderItems.Clear();
                filterBySupplier = false;
                SupplierComboBox.Enabled = true;
                SupplierComboBox.Text = "";
                AddToBasketButton.Enabled = false;
                UpdateCart();
                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveFromBasket_Click(object sender, EventArgs e)
        {
            try
            {
                order.OrderItems.Remove(selectedCartItem);
                if (order.OrderItems.Count == 0)
                {
                    SupplierComboBox.Enabled = true;
                    filterBySupplier = false;
                    LoadRequests();
                }
                UpdateCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateCart()
        {
            try
            {
                lbxCart.Items.Clear();
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    lbxCart.Items.Add(orderItem.GetOrderItemString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OrderHistory_Click(object sender, EventArgs e)
        {
            try
            {
                OrderHistoryPage orderHistoryPage = new OrderHistoryPage(db);
                orderHistoryPage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbxCart.SelectedItem != null)
                {
                    EditQuantityPanel.Visible = false;
                    selectedCartItem = GetOrderItemByCartItemString(lbxCart.SelectedItem.ToString());
                    if (selectedCartItem != null)
                    {
                        panelCartItem.Visible = true;
                        nudQuantitySelected.Value = selectedCartItem.Quantity;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSetNewQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                EditQuantityPanel.Visible = false;
                var activeRequest = requests.FirstOrDefault(request => request.ProductID == selectedCartItem.product.getId());
                int maximumOrderQuantity = db.GetDepoProductMaxQuantityByID(selectedCartItem.product.getId()) - selectedCartItem.product.QuantityinStock;
                int newQuantity = Convert.ToInt32(nudQuantitySelected.Value);

                if (newQuantity < 10)
                {
                    MessageBox.Show("Selected quantity must be at least 10.");
                }
                else if (newQuantity > maximumOrderQuantity)
                {
                    MessageBox.Show("Selected quantity in addition to the existing stock would exceed the maximum capacity for this product.");
                }
                else
                {
                    if (activeRequest != null && activeRequest.Quantity > newQuantity)
                    {
                        MessageBox.Show("Selected quantity for this product is lower than the quantity requested in one of the restock requests.");
                    }
                    ChangeOrderItemQuantity();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeOrderItemQuantity()
        {
            try
            {
                selectedCartItem.Quantity = Convert.ToInt32(nudQuantitySelected.Value);
                UpdateCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                EditQuantityPanel.Visible = !EditQuantityPanel.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowSelectedRequest()
        {
            try
            {
                if (filteredRequests.Count > 0)
                {
                    Product product = db.GetProductByID(selectedRequest.ProductID);
                    RequestTextBox.Text = $"{product.Name} ({product.Year}) - {product.getCategory()}\r\n\r\n" +
                                          $"{product.Description}\r\n\r\n\r\n" +
                                          $"Quantity in stock: {product.QuantityinStock}\r\n" +
                                          $"Quantity requested: {selectedRequest.Quantity}\r\n\r\n" +
                                          $"Date: {selectedRequest.Date}";
                }
                else
                {
                    RequestTextBox.Text = "No requests available.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PreviousRequestButton_Click(object sender, EventArgs e)
        {
            try
            {
                NavigateRequests(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NextRequestButton_Click(object sender, EventArgs e)
        {
            try
            {
                NavigateRequests(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NavigateRequests(int direction)
        {
            try
            {
                if (filteredRequests.Count == 0)
                    return;

                currentRequestIndex = Math.Max(0, Math.Min(filteredRequests.Count - 1, currentRequestIndex + direction));
                selectedRequest = filteredRequests[currentRequestIndex];
                PageNumberLabel.Text = $"{currentRequestIndex + 1}/{filteredRequests.Count}";
                ShowSelectedRequest();

                HighlightSupplierForSelectedRequest();

                PreviousRequestButton.Enabled = currentRequestIndex > 0;
                NextRequestButton.Enabled = currentRequestIndex < filteredRequests.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HighlightSupplierForSelectedRequest()
        {
            try
            {
                var suppliers = db.GetSupplierNamesByProductID(selectedRequest.ProductID);
                if (suppliers.Count > 0)
                {
                    SupplierComboBox.SelectedItem = suppliers.First();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddToBasketButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AlreadyInCart())
                {
                    AddOrderItemToBasket();
                    UpdateUIAfterAddingItem();
                }
                else
                {
                    MessageBox.Show("This product is already in the cart.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool AlreadyInCart()
        {
                return order.OrderItems.Any(orderItem => orderItem.product.getId() == selectedRequest.ProductID);

        }

        private void AddOrderItemToBasket()
        {
            try
            {
                Product product = db.GetProductByID(selectedRequest.ProductID);
                OrderItem orderItem = new OrderItem(product, selectedRequest.Quantity);
                order.OrderItems.Add(orderItem);
                lbxCart.Items.Add(orderItem.GetOrderItemString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateUIAfterAddingItem()
        {
            try
            {
                if (order.OrderItems.Count > 0)
                {
                    btnCheckOut.Enabled = true;
                    SupplierComboBox.Enabled = false;
                    if (!filterBySupplier)
                    {
                        filterBySupplier = true;
                        FilterRequestsBySupplier();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FilterRequestsBySupplier()
        {
            try
            {
                if (!filterBySupplier)
                {
                    filteredRequests = new List<RestockingRequest>(requests);
                }
                else if (!string.IsNullOrEmpty(SupplierComboBox.Text))
                {
                    filteredRequests = requests.Where(request =>
                        db.GetSupplierNamesByProductID(request.ProductID).Contains(SupplierComboBox.Text)).ToList();
                }

                if (filteredRequests.Count == 0)
                {
                    RequestsPanel.Visible = false;
                    SupplierLimitErrorPanel.Visible = true;
                    NoRequestsPanel.Visible = false;
                    PageNumberLabel.Text = "0/0";
                    RequestTextBox.Text = "No requests available.";
                }
                else
                {
                    RequestsPanel.Visible = true;
                    SupplierLimitErrorPanel.Visible = false;
                    NoRequestsPanel.Visible = false;
                    currentRequestIndex = 0;
                    selectedRequest = filteredRequests[currentRequestIndex];
                    PageNumberLabel.Text = $"{1}/{filteredRequests.Count}";
                    ShowSelectedRequest();
                    PreviousRequestButton.Enabled = false;
                    NextRequestButton.Enabled = filteredRequests.Count > 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SupplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(SupplierComboBox.Text))
                {
                    AddToBasketButton.Enabled = selectedRequest != null;
                    filterBySupplier = true;
                    FilterRequestsBySupplier();
                }
                else
                {
                    filterBySupplier = false;
                    filteredRequests = new List<RestockingRequest>(requests);
                    currentRequestIndex = 0;
                    selectedRequest = filteredRequests[currentRequestIndex];
                    PageNumberLabel.Text = $"{1}/{filteredRequests.Count}";
                    ShowSelectedRequest();
                    PreviousRequestButton.Enabled = false;
                    NextRequestButton.Enabled = filteredRequests.Count > 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SupplierComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

