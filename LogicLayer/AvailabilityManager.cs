using ClassLibrary;
using DataAccessLayer;
using MediaBazaarApp;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicLayer
{
    /// <summary>
    /// Manages availability-related operations for employees.
    /// </summary>
    public class AvailabilityManager
    {
        AvailabilityDataAccessLayer availabilitySQL = new AvailabilityDataAccessLayer();

        /// <summary>
        /// Deletes the availability for a specific person based on their ID.
        /// </summary>
        /// <param name="person_id">The ID of the person whose availability is to be deleted.</param>
        /// <exception cref="ArgumentNullException">Thrown when the person_id is less than 1.</exception>
        public void DeleteAvailability(int person_id)
        {
            if (person_id < 1)
            {
                throw new ArgumentNullException("A non existing id has been passed to the system. \nPlease, try again later!");
            }
            availabilitySQL.DeleteAvailability(person_id);
        }


        /// <summary>
        /// Marks person as unavailable for the selectedDates.
        /// </summary>
        /// <param name="person_id">The ID of the person whose availability will be removed.</param>
        /// <param name="selectedDates">The list of dates to remove.</param>
        public void RemoveAvailability(int person_id, List<DateTime> selectedDates)
        {
            if (person_id < 1 || selectedDates == null)
            {
                throw new ArgumentNullException("A non existing id has been passed to the system. \nPlease, try again later!");
            }
            availabilitySQL.RemoveAvailability(person_id, selectedDates);
        }

        /// <summary>
        /// Marks person as available for the selected timeslot
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="date">The date of the availability.</param>
        /// <param name="shift">The shift availability for the day.</param>
        public void AddAvailability(int personId, DateTime date, AvailabilityForTheDay shift)
        {
            if (personId < 1)
            {
                throw new ArgumentNullException("A non existing id value has been passed to the system. \nPlease, try again later!");
            }
            availabilitySQL.AddAvailability(personId, date, shift);
        }

        /// <summary>
        /// Retrieves a list of people who are eligible to be assigned to a particular shift on a given date,
        /// considering their current schedule and role restrictions.
        /// </summary>
        /// <param name="number">The number of people to retrieve.</param>
        /// <param name="selectedRole">The role to filter by.</param>
        /// <param name="selectedDepartment">The department to filter by.</param>
        /// <param name="selectedDate">The date to filter by.</param>
        /// <param name="shift">The shift to filter by.</param>
        /// <returns>A list of eligible people who can be assigned to the shift.</returns>
        public List<Availability> GetPossiblePeopleToBeAssigned(int number, Role selectedRole, Department selectedDepartment, DateTime selectedDate, AvailabilityForTheDay shift)
        {
            if (number < 1)
            {
                throw new ArgumentNullException("A null value has been passed to the system. \nPlease, try again later!");
            }
            return availabilitySQL.GetPossiblePeopleToBeAssigned(number, selectedRole, selectedDepartment, selectedDate, shift);
        }

        /// <summary>
        /// Retrieves a list of possible shift changes for a specific person, 
        /// checking other approved transfers and finding compatible shifts for swapping.
        /// </summary>
        /// <param name="personId">The ID of the person requesting possible shift changes.</param>
        /// <returns>A list of tuples containing the email, date, and shift of potential shifts available for transfer.</returns>
        public List<Tuple<string, DateTime, AvailabilityForTheDay>> GetPossibleShiftChanges(int personId)
        {
            if (personId < 1)
            {
                throw new ArgumentNullException("A null value has been passed to the system. \nPlease, try again later!");
            }
            return availabilitySQL.GetPossibleShiftChanges(personId);
        }

        /// <summary>
        /// Inserts a new availability record into the database for a specified person.
        /// </summary>
        /// <param name="person_id">The ID of the person for whom the availability is being added.</param>
        /// <param name="availabilityForTheDay">The shift for which the availability is being added.</param>
        /// <param name="_date">The date for which the availability is being added.</param>
        /// <param name="isTaken">A boolean indicating whether the shift is taken (true) or not (false).</param>
        /// <exception cref="ArgumentNullException">Thrown if a negative (invalid) id has been passed.</exception>
        public void AddAvailability(int person_id, AvailabilityForTheDay availabilityForTheDay, DateTime _date, bool isTaken)
        {
            if (person_id < 1)
            {
                throw new ArgumentNullException("A null value has been passed to the system. \nPlease, try again later!");
            }
            availabilitySQL.AddAvailability(person_id, availabilityForTheDay, _date, isTaken);
        }


        /// <summary>
        /// Deletes an existing shift transfer request for a specific person, shift, and date.
        /// </summary>
        /// <param name="personId">The ID of the person whose request is being deleted.</param>
        /// <param name="selectedDate">The date of the shift transfer request.</param>
        /// <param name="availabilityForTheDay">The availability status of the shift being deleted.</param>
        public void DeleteShiftTransferRequest(int personId, DateTime selectedDate, AvailabilityForTheDay availabilityForTheDay)
        {
            if (personId < 1)
            {
                throw new ArgumentNullException("A null value has been passed to the system. \nPlease, try again later!");
            }
            availabilitySQL.DeleteShiftTransferRequest(personId, selectedDate, availabilityForTheDay);
        }

        /// <summary>
        /// Checks if a specific person has already requested a shift transfer for a given date and shift.
        /// </summary>
        /// <param name="person_id">The ID of the person requesting the shift transfer.</param>
        /// <param name="availabilityForTheDay">The availability status for the requested shift.</param>
        /// <param name="_date">The date of the requested shift.</param>
        /// <returns>True if a request already exists, otherwise false.</returns>
        public bool CheckExistingRequest(int person_id, AvailabilityForTheDay availabilityForTheDay, DateTime _date)
        {
            if (person_id < 1)
            {
                throw new ArgumentNullException("A null value has been passed to the system. \nPlease, try again later!");
            }
            return availabilitySQL.CheckExistingRequest(person_id, availabilityForTheDay, _date);
        }


        /// <summary>
        /// Creates a new shift transfer request for a specific person, shift, and date.
        /// </summary>
        /// <param name="person_id">The ID of the person requesting the transfer.</param>
        /// <param name="availabilityForTheDay">The availability status of the shift to transfer.</param>
        /// <param name="_date">The date of the shift to transfer.</param>
        /// <param name="reason">The reason for requesting the transfer.</param>
        public void RequestTransfer(int person_id, AvailabilityForTheDay availabilityForTheDay, DateTime _date, string reason)
        {
            if (person_id < 1)
            {
                throw new ArgumentNullException("A null value has been passed to the system. \nPlease, try again later!");
            }
            availabilitySQL.RequestTransfer(person_id, availabilityForTheDay, _date, reason);
        }
        /// <summary>
        /// Retrieves a list of employees available for a specific day for shift planning.
        /// Filters employees by their role, department, and availability status.
        /// </summary>
        /// <param name="givenDate">The date for which to retrieve availability.</param>
        /// <param name="givenRole">The role to filter employees by.</param>
        /// <param name="givenDepartment">The department to filter employees by.</param>
        /// <returns>A list of available employees with their availability information.</returns>
        public List<Availability> GetAvailabilityForPlannerPage(DateTime givenDate, Role givenRole, Department givenDepartment)
        {
            return availabilitySQL.GetAvailabilityForPlannerPage(givenDate, givenRole, givenDepartment);
        }

        /// <summary>
        /// Retrieves specific availability details for a user based on their ID, date, and shift.
        /// </summary>
        /// <param name="selected_person">The <see cref="Person"/> object representing the user whose availability is being retrieved.</param>
        /// <param name="selected_date">The date for which availability details are to be retrieved.</param>
        /// <param name="selectedAvailability">The shift for which availability details are being retrieved.</param>
        /// <returns>An <see cref="Availability"/> object representing the availability details for the specified user, date, and shift, or null if no record is found.</returns>
        /// <exception cref="ArgumentNullException">Thrown if a null person object has been passed.</exception>
        public Availability FindAvailability(Person selected_person, DateTime selected_date, AvailabilityForTheDay selectedAvailability)
        {
            if (selected_person == null)
            {
                throw new ArgumentNullException("A null value has been passed to the system. \nPlease, try again later!");
            }
            return availabilitySQL.FindAvailability(selected_person, selected_date, selectedAvailability);
        }

        /// <summary>
        /// Updates the availability status (isTaken) for a user on a specific date and shift.
        /// </summary>
        /// <param name="availability">The <see cref="Availability"/> object representing the availability to be updated.</param>
        /// <param name="id">The ID of the user whose availability is being updated.</param>
        /// <param name="selected_date">The date for which the availability status is being updated.</param>
        /// <param name="selectedShift">The shift for which the availability status is being updated.</param>
        /// <exception cref="ArgumentNullException">Thrown if a negative (invalid) id has been passed.</exception>
        public void ChangeIsTaken(Availability availability, int id, DateTime selected_date, AvailabilityForTheDay selectedShift)
        {
            if (id < 1)
            {
                throw new ArgumentNullException("An invalid id value has been passed to the system. \nPlease, try again later!");
            }
            availabilitySQL.ChangeIsTaken(availability, id, selected_date, selectedShift);
        }


        /// <summary>
        /// Resets the schedule by marking all shifts as not taken for a specified date.
        /// </summary>
        /// <param name="selected_date">The date for which the schedule will be cleared.</param>
        public void ClearSchedule(DateTime selected_date)
        {
            availabilitySQL.ClearSchedule(selected_date);
        }

        /// <summary>
        /// Reads the number of employees available for special shifts on a specific date, 
        /// in a given department and role, with a specific availability status.
        /// </summary>
        /// <param name="date">The date for which to read special shifts.</param>
        /// <param name="department">The department to filter by.</param>
        /// <param name="role">The role to filter by.</param>
        /// <param name="availabilityForTheDay">The availability status to filter by.</param>
        /// <returns>The number of employees available for the special shift, or -1 if none found.</returns>
        public int ReadSpecialShiftsDays(DateTime date, Department department, Role role, AvailabilityForTheDay availabilityForTheDay)
        {
            return availabilitySQL.ReadSpecialShiftsDays(date, department, role, availabilityForTheDay);
        }

        /// <summary>
        /// Counts how many people have been assigned to a particular role, department, date, and shift.
        /// </summary>
        /// <param name="selectedRole">The role to filter employees by.</param>
        /// <param name="selectedDepartment">The department to filter employees by.</param>
        /// <param name="selectedDate">The date to filter shifts by.</param>
        /// <param name="shift">The shift to filter by.</param>
        /// <returns>The number of people assigned to the specified shift.</returns>
        public int GetNumOfAssignedShifts(Role selectedRole, Department selectedDepartment, DateTime selectedDate, AvailabilityForTheDay shift)
        {
            return availabilitySQL.GetNumOfAssignedShifts(selectedRole, selectedDepartment, selectedDate, shift);
        }


        /// <summary>
        /// Retrieves a specific shift transfer request based on a detailed string description.
        /// </summary>
        /// <param name="givenInfo">A string containing the concatenated information about the transfer request.</param>
        /// <returns>A ShiftExchange object representing the detailed shift transfer request.</returns>
        public ShiftExchange FindConcreteAvailability(string givenInfo)
        {
            if (string.IsNullOrEmpty(givenInfo))
            {
                throw new ArgumentNullException("A null value has been passed to the system. \nPlease, try again later!");
            }
            return availabilitySQL.FindConcreteAvailability(givenInfo);
        }

        /// <summary>
        /// Updates a shift transfer request's status to approved for a specific person, shift, and date.
        /// </summary>
        /// <param name="person_id">The ID of the person whose request is being updated.</param>
        /// <param name="availabilityForTheDay">The availability status of the shift being approved.</param>
        /// <param name="_date">The date of the shift being approved.</param>
        public void UpdateShiftRequestStatus(int person_id, AvailabilityForTheDay availabilityForTheDay, DateTime _date)
        {
            if (person_id < 1)
            {
                throw new ArgumentNullException("An invalid id value has been passed to the system. \nPlease, try again later!");
            }
            availabilitySQL.UpdateShiftRequestStatus(person_id, availabilityForTheDay, _date);
        }


        /// <summary>
        /// Retrieves all shift transfer requests for a given department where the request has not been approved.
        /// </summary>
        /// <param name="givenDepartment">The department to filter shift transfer requests by.</param>
        /// <returns>A list of shift transfer requests, including employee and shift details.</returns>
        public List<ShiftExchange> ReadShifTransferRequests(Department givenDepartment)
        {
            return availabilitySQL.ReadShifTransferRequests(givenDepartment);
        }

        /// <summary>
        /// Checks if a specific date exists for a person.
        /// </summary>
        /// <param name="person_id">The ID of the person.</param>
        /// <param name="selectedDate">The selected date.</param>
        /// <returns>True if the date exists, otherwise false.</returns>
        public bool IsDateExist(int person_id, DateTime selectedDate)
        {
            if (person_id < 1)
            {
                throw new ArgumentNullException("An invalid id value has been passed to the system. \nPlease, try again later!");
            }
            return availabilitySQL.IsDateExist(person_id, selectedDate);
        }
    }
}
