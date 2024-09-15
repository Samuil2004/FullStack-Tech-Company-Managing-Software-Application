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

namespace MediaBazaarApp
{
    public partial class OrderHistoryPage : Form
    {
        ProductsDataAccessLayer db;

        public Order SelectedOrder;
        public OrderHistoryPage(ProductsDataAccessLayer DB)
        {
            try
            {
                InitializeComponent();
                db = DB;
                List<Order> orders = new List<Order>();
                foreach (Order order in db.GetAllOrders())
                {
                    if (order.status == "Delivered")
                    {
                        orders.Add(order);
                    }
                }
                UpdateOrdersListview(orders, "Delivered");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void UpdateOrdersListview(List<Order> orders, string status)
        {
            try
            {
                OrdersListView.Items.Clear();
                if (orders.Count != 0)
                {
                    panel1.Visible = true;
                    foreach (Order order in orders)
                    {
                        if (order.status == status)
                        {
                            string supplierName = db.GetSupplierNameByOrderID(order.OrderId);

                            if (supplierName != null)
                            {

                                ListViewItem item = new ListViewItem(new[]
                                    {order.OrderId.ToString(),
                                supplierName, order.status,
                                order.OrderDate.ToShortDateString(),
                                order.ArrivalDate.ToShortDateString()});

                                OrdersListView.Items.Add(item);
                            }
                            else { MessageBox.Show(" Trouble retrieving "); }
                        }
                    }
                }
                else
                {
                    label3.Text = $"No orders found with the {status} status";
                    panel1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OrdersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (OrdersListView.SelectedItems.Count > 0)
                {
                    ListViewItem selected = OrdersListView.SelectedItems[0];
                    foreach (Order order in db.GetAllOrders())
                    {
                        if (Convert.ToInt16(selected.SubItems[0].Text) == order.OrderId)
                        {
                            SelectedOrder = order;
                        }
                    }

                    UpdateOrderItemsListBox(SelectedOrder.OrderItems);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateOrderItemsListBox(List<OrderItem> orderItems)
        {
            try
            {
                OrderItemsListBox.Items.Clear();
                foreach (OrderItem item in orderItems)
                {
                    OrderItemsListBox.Items.Add($"{item.product.Name} - {item.Quantity} units");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OrderHistoryPage_Load(object sender, EventArgs e)
        {

        }

        private void DeliveredButton_Click(object sender, EventArgs e)
        {
            try
            {
                OrderItemsListBox.Items.Clear();
                DeliveredButton.BackColor = Color.Gainsboro;
                OnTheWayButton.BackColor = Color.White;

                List<Order> orders = new List<Order>();
                foreach (Order order in db.GetAllOrders())
                {
                    if (order.status == "Delivered")
                    {
                        orders.Add(order);
                    }
                }
                UpdateOrdersListview(orders, "Delivered");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnTheWayButton_Click(object sender, EventArgs e)
        {
            try
            {
                OrderItemsListBox.Items.Clear();
                DeliveredButton.BackColor = Color.White;
                OnTheWayButton.BackColor = Color.Gainsboro;

                List<Order> orders = new List<Order>();
                foreach (Order order in db.GetAllOrders())
                {
                    if (order.status == "On the way")
                    {
                        orders.Add(order);
                    }
                }
                UpdateOrdersListview(orders, "On the way");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
