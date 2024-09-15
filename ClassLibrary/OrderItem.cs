using MediaBazaarApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class OrderItem
    {

        public Product product;
        public int Quantity;

        public OrderItem(Product prod, int quantity)
        {
            this.product = prod;
            this.Quantity = quantity;
        }

        public string GetOrderItemString()
        {
            string orderItemString = $"{product.Name} ({Quantity} units)";
            return orderItemString;
        }

    }
}
