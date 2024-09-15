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
    public class AvailabilityManager
    {
        AvailabilitySQL AvailabilitySQL = new AvailabilitySQL();
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
