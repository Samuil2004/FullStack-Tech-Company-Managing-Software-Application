using MediaBazaarApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Represents an item within an order, including a product and its quantity.
    /// </summary>
    public class OrderItem
    {

        public Product product;
        public int Quantity;

        public OrderItem(Product prod, int quantity)
        {
            this.product = prod;
            this.Quantity = quantity;
        }

        /// <summary>
        /// Returns a string representation of the order item, including the product name and quantity.
        /// </summary>
        /// <returns>A string that represents the order item in the format "ProductName (Quantity units)".</returns>
        public string GetOrderItemString()
        {
            string orderItemString = $"{product.Name} ({Quantity} units)";
            return orderItemString;
        }

    }
}
