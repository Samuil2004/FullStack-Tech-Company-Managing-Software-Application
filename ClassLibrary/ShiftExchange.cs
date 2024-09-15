using MediaBazaarApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ShiftExchange
    {
        public Availability availability;
        public string reason;

        public ShiftExchange(Availability _availability,string _reason) 
        { 
            this.availability = _availability;
            this.reason = _reason;
        }
        public Availability GetAvailability
        {
            get{ return this.availability; }
        }

        public string GetReason
        {
            get { return this.reason; }
        }
    }
}
