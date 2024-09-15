using MediaBazaarApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class EmployeeNumberChange
    {
        private Role selectedRole;
        private DateTime selectedDate;
        private AvailabilityForTheDay selectedShift;
        private int numOfEmployees;

        public EmployeeNumberChange(Role selectedRole, DateTime selectedDate,AvailabilityForTheDay shift, int numOfEmployees)
        {
            this.selectedRole = selectedRole;
            this.selectedDate = selectedDate;
            this.selectedShift = shift;
            this.numOfEmployees = numOfEmployees;
        }

        public Role GetSelectedRole
        {
            get { return selectedRole; }
        }

        public DateTime GetSelectedDate
        { 
            get { return selectedDate; } 
        }

        public int GetNumOfEmployees
        {
            get { return numOfEmployees; }
        }
        public AvailabilityForTheDay GetSelectedShift
        {
            get { return selectedShift; }
        }
    }
}
