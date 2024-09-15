using MediaBazaarApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
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
