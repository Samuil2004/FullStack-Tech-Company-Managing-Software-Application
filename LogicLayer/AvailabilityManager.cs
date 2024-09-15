using DataAccessLayer;
using MediaBazaarApp;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
     /// <summary>
     /// Manages availability-related operations for employees.
     /// </summary>
    public class AvailabilityManager
    {
        AvailabilityDataAccessLayer AvailabilitySQL = new AvailabilityDataAccessLayer();

        /// <summary>
        /// Deletes the availability for a specific person based on their ID.
        /// </summary>
        /// <param name="person_id">The ID of the person whose availability is to be deleted.</param>
        /// <exception cref="ArgumentNullException">Thrown when the person_id is less than 1.</exception>
        public void DeleteAvailability(int person_id)
        {
            if(person_id < 1)
            {
                throw new ArgumentNullException("A null value has been passed to the system. \nPlease, try again later!");
            }
            AvailabilitySQL.DeleteAvailability(person_id);
        }
        
    }
}
