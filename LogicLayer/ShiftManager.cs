using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{

    /// <summary>
    /// Manages employee shifts, including clocking in/out and calculating work time for a month.
    /// </summary>
    public class ShiftManager
	{
		SQLDatabase database;

		public ShiftManager()
		{
			database = new SQLDatabase();
		}

        /// <summary>
        /// Clocks an employee in or out based on their current status and returns a message about the action.
        /// </summary>
        /// <param name="employeeID">The ID of the employee clocking in or out.</param>
        /// <returns>A message indicating whether the employee clocked in, clocked out, or needs to wait before clocking in/out again.</returns>
        public string ClockInOrOut(int employeeID)
		{
			string message = ", welcome!";
			DateTime time = DateTime.Now;
			if (database.CheckIfJustClocked(employeeID, time))
			{
				message = ", you just clocked in/out, please wait before doing it again";
			}
			else if (database.CheckIfClockedIn(employeeID, time))
			{
				TimeSpan timeWorked = database.ClockOut(employeeID, time);
				database.ClockingIn(employeeID, time);
				message = ", you worked for " + timeWorked.ToString(@"hh\:mm") + ". Goodbye!";
			}
			else
			{
				database.ClockingIn(employeeID, time);
			}
			return message;
		}


        /// <summary>
        /// Calculates the total number of hours an employee worked in a specific month.
        /// </summary>
        /// <param name="employeeID">The ID of the employee whose work time is being calculated.</param>
        /// <param name="month">The number of months back from the current date to calculate work time.</param>
        /// <returns>The total number of hours worked by the employee in the specified month.</returns>
        public int GetEmployeeWorkTimeMonth(int employeeID, int month)
		{
			TimeSpan workTimeWeek = TimeSpan.Zero;
			List<DateTime> shifts = database.GetWorkTimeMonth(employeeID, DateTime.Now.AddMonths(-month));
			DateTime clockIn = DateTime.MinValue;
			for (int i = 0; i < shifts.Count; i++)
			{
				if (i % 2 == 0)
				{
					clockIn = shifts[i];
				}
				else
				{
					workTimeWeek += shifts[i] - clockIn;
				}
			}
			return workTimeWeek.Hours;
		}
	}
}
