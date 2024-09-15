using MediaBazaarApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Represents an order containing a list of order items, along with details such as order dates and status.
    /// </summary>
    public class Order
    {
        
        public int OrderId { get; private set; }
        public string status {  get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime ArrivalDate { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }

        public Order() 
        {
            OrderItems = new List<OrderItem>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class with the specified details.
        /// </summary>
        /// <param name="Id">The unique identifier for the order.</param>
        /// <param name="OrderDate">The date when the order was placed.</param>
        /// <param name="ArrivalDate">The expected or actual date when the order will arrive.</param>
        /// <param name="status">The status of the order.</param>
        /// <param name="orderItems">The list of items included in the order.</param>
        public Order(int Id, DateTime OrderDate, DateTime ArrivalDate, string status, List<OrderItem> orderItems) 
        {
            this.OrderId = Id;
            this.OrderDate = OrderDate;
            this.ArrivalDate = ArrivalDate;
            this.status = status;

            this.OrderItems = orderItems;
        }
        
    }
}
