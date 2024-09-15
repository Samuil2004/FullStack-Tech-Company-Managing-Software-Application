using DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
	public class ShiftManager
	{
		SQLDatabase database;

		public ShiftManager()
		{
			database = new SQLDatabase();
		}

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
