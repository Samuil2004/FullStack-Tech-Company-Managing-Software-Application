using MediaBazaarApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Represents a shift exchange request where an employee requests to exchange their shift with another person, along with a reason for the request.
    /// </summary>
    public class ShiftExchange
    {
        public Availability availability;
        public string reason;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShiftExchange"/> class with specified availability and reason.
        /// </summary>
        public ShiftExchange(Availability _availability,string _reason) 
        { 
            this.availability = _availability;
            this.reason = _reason;
        }

        /// <summary>
        /// Gets the availability details of the shift exchange request.
        /// </summary>
        public Availability GetAvailability
        {
            get{ return this.availability; }
        }

        /// <summary>
        /// Gets the reason for the shift exchange request.
        /// </summary>
        public string GetReason
        {
            get { return this.reason; }
        }
    }
}
