using MediaBazaarApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class RestockingRequest
    {
        
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateOnly Date { get; set; }
        public string RequestFrom { get; set; }

        public RestockingRequest(int ProductID, string productname, int Quantity, DateOnly Date, string RequestFrom) 
        {
            this.ProductID = ProductID;
            this.ProductName = productname;
            this.Quantity = Quantity;
            this.Date = Date;
            this.RequestFrom = RequestFrom;
        }

        public override string ToString()
        {
            return $"({ProductName} ({Date}) - {Quantity} units";
        }
    }
}
