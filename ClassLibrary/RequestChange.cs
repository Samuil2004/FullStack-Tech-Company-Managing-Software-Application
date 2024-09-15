using MediaBazaarApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp
{
    public class RequestChange
    {
        private Availability availability;
        private DateTime requestedDate;

        public RequestChange(Availability availability, DateTime requestedDate)
        {
            this.availability = availability;
            this.requestedDate = requestedDate;
        }

        public string GetRequestInfo
        {
            get { return $"{availability.getPerson().GetInfo()} - {availability.GetAvailability()} - {requestedDate.ToString("dd/MM/yy")}"; }
        }
    }
}
