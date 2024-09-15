using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp
{
    public class Availability
    {
        private Person person;
        private DateTime date;
        private AvailabilityForTheDay available;
        private bool isTaken;
        private int id;

        public Availability(Person person, DateTime date, AvailabilityForTheDay available, bool isTaken = false)
        {
            this.person = person;
            this.date = date;
            this.available = available;
            this.isTaken = isTaken;
        }
        public Availability(int id, DateTime date, AvailabilityForTheDay available, bool isTaken = false)
        {
            this.id = id;
            this.date = date;
            this.available = available;
            this.isTaken = isTaken;
        }

        public Availability(DateTime date, AvailabilityForTheDay available, bool isTaken = false) 
        {
            this.date = date;
            this.available = available;
            this.isTaken = isTaken;
        }
        public AvailabilityForTheDay GetAvailability()
        {
            return available;
        }
        public Person getPerson()
        {
            return person;
        }
        public DateTime getTimeSlot()
        {
            return date;
        }
        public bool isPersonTaken()
        {
            return isTaken;
        }
        public void ChangeIsTaken()
        {
            isTaken = isTaken ? false : true;
        }
        public int GetId
        {
            get { return id; }
        }
    }
}
