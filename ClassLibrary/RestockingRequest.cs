using MediaBazaarApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Represents a restocking request when there is not enough of a product in the shop and more is needed from the depot
    /// </summary>
    public class RestockingRequest
    { 
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateOnly Date { get; set; }
        public string RequestFrom { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestockingRequest"/> class with specified details.
        /// </summary>
        public RestockingRequest(int ProductID, string productname, int Quantity, DateOnly Date, string RequestFrom) 
        {
            this.ProductID = ProductID;
            this.ProductName = productname;
            this.Quantity = Quantity;
            this.Date = Date;
            this.RequestFrom = RequestFrom;
        }

        /// <summary>
        /// Returns a string representation of the restocking request, including product name, date, and quantity.
        /// </summary>
        /// <returns>A string that represents the restocking request.</returns>
        public override string ToString()
        {
            return $"({ProductName} ({Date}) - {Quantity} units";
        }
    }
}
