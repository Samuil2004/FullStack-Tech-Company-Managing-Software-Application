using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp
{
    /// <summary>
    /// Represents the availability of a person for a specific time slot on a given date.
    /// </summary>
    public class Availability
    {
        private Person person;
        private DateTime date;
        private AvailabilityForTheDay available;
        private bool isTaken;
        private int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Availability"/> class with a person.
        /// </summary>
        /// <param name="person">The person associated with this availability.</param>
        /// <param name="date">The date of the availability.</param>
        /// <param name="available">The specific time slot or shift of availability.</param>
        /// <param name="isTaken">Indicates whether the availability is taken (default is false).</param>
        public Availability(Person person, DateTime date, AvailabilityForTheDay available, bool isTaken = false)
        {
            this.person = person;
            this.date = date;
            this.available = available;
            this.isTaken = isTaken;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Availability"/> class without a person.
        /// </summary>
        /// <param name="date">The date of the availability.</param>
        /// <param name="available">The specific time slot or shift of availability.</param>
        /// <param name="isTaken">Indicates whether the availability is taken (default is false).</param>
        public Availability(DateTime date, AvailabilityForTheDay available, bool isTaken = false)
        {
            this.date = date;
            this.available = available;
            this.isTaken = isTaken;
        }

        /// <summary>
        /// Gets the specific time slot or shift of availability.
        /// </summary>
        /// <returns>The <see cref="AvailabilityForTheDay"/> representing the time slot or shift.</returns>
        public AvailabilityForTheDay GetAvailability()
        {
            return available;
        }

        /// <summary>
        /// Gets the person associated with this availability.
        /// </summary>
        /// <returns>The <see cref="Person"/> associated with this availability.</returns>
        public Person getPerson()
        {
            return person;
        }

        /// <summary>
        /// Gets the date for which this availability is applicable.
        /// </summary>
        /// <returns>The <see cref="DateTime"/> representing the date of availability.</returns>
        public DateTime getTimeSlot()
        {
            return date;
        }

        /// <summary>
        /// Determines if the availability is taken or not.
        /// </summary>
        /// <returns><c>true</c> if the availability is taken; otherwise, <c>false</c>.</returns>
        public bool isPersonTaken()
        {
            return isTaken;
        }
    }
}
