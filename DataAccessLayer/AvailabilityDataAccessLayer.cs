using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using MediaBazaarApp;

namespace DataAccessLayer
{

    /// <summary>
    /// This class is responsible for establishing the communication between the code and the database for all availability related data
    /// </summary>
    public class AvailabilityDataAccessLayer
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi527531_mediashop;User Id=dbi527531_mediashop;Password=mediashop123; TrustServerCertificate=True";


        /// <summary>
        /// Retrieves a list of availability records for employees between two given dates, 
        /// filtered by the specified shift, department, and role. 
        /// </summary>
        /// <param name="date1">The start date of the range for which availability is to be retrieved.</param>
        /// <param name="date2">The end date of the range for which availability is to be retrieved.</param>
        /// <param name="shift">The shift for which availability is to be checked.</param>
        /// <param name="selectedDepartment">The department of employees whose availability is to be retrieved.</param>
        /// <param name="selectedRole">The role of employees whose availability is to be retrieved.</param>
        /// <returns>A list of <see cref="Availability"/> objects representing the availability of employees.</returns>
        /// <exception cref="Exception">Thrown when there is an issue with retrieving the data from the database.</exception>        public List<Availability> TakeAllCorrespondingAvailability(DateTime date1, DateTime date2, AvailabilityForTheDay shift, Department selectedDepartment, Role selectedRole)
        public List<Availability> TakeAllCorrespondingAvailability(DateTime date1, DateTime date2, AvailabilityForTheDay shift, Department selectedDepartment, Role selectedRole)
        {
            string query = "SELECT p.id, p.email,p.firstName, p.lastName, p.gender, p.phoneNumber, p.startingDate, p.manager_id, p.department, " +
                "p._role, p.stillWorking, p.Wage, p._floor, a._date, a.availabilityForTheDay, a.isTaken " +
                "FROM Person p " +
                "JOIN Availabilty a ON p.id = a.person_id " +
                "WHERE a._date BETWEEN @date1 AND @date2 " +
                "and a.availabilityForTheDay = @shift " +
                "and p.stillWorking = 1 " +
                "and p.department = @department " +
                "and p._role = @role " +
                "and a.isTaken = 1";

            List<Availability> allAvailability = new List<Availability>();
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date1", date1.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@date2", date2.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@shift", shift.ToString());
                command.Parameters.AddWithValue("@department", selectedDepartment.ToString());
                command.Parameters.AddWithValue("@role", selectedRole.ToString());

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string email = reader["email"].ToString();
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    string gender = reader["gender"].ToString();
                    string phoneNumber = reader["phoneNumber"].ToString();
                    DateTime startingDate = Convert.ToDateTime(reader["startingDate"]);
                    int manager_id = Convert.ToInt32(reader["manager_id"]);
                    string department = reader["department"].ToString();
                    string role = reader["_role"].ToString();
                    Role selected_role = (Role)Enum.Parse(typeof(Role), role);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    DateTime date = Convert.ToDateTime(reader["_date"]);
                    string availability = reader["availabilityForTheDay"].ToString();
                    AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);
                    bool isTaken = Convert.ToBoolean(reader["isTaken"]);
                    double wage = Convert.ToDouble(reader["Wage"]);
                    int floor = Convert.ToInt32(reader["_floor"]);

                    Person newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor);
                    newPerson.PhoneNumber = phoneNumber;
                    Availability availability1 = new Availability(newPerson, date, selected_availability, isTaken);
                    allAvailability.Add(availability1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Getting availability data failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }
            return allAvailability;
        }


        /// <summary>
        /// Retrieves the availability records for a specific user between two dates, 
        /// excluding any records marked as 'Unavailable'.
        /// </summary>
        /// <param name="date1">The start date of the range for which the user's availability is to be retrieved.</param>
        /// <param name="date2">The end date of the range for which the user's availability is to be retrieved.</param>
        /// <param name="id">The ID of the user whose availability is to be retrieved.</param>
        /// <returns>A list of <see cref="Availability"/> objects representing the user's availability.</returns>
        /// <exception cref="Exception">Thrown when there is an issue with retrieving the data from the database.</exception>
        public List<Availability> TakeUserAvailability(DateOnly date1, DateTime date2, int id)
        {
            string query = "SELECT _date, availabilityForTheDay, isTaken FROM Availabilty " +
                "WHERE person_id=@id AND _date BETWEEN @date1 AND @date2 and availabilityForTheDay != 'Unavailable'; ";

            List<Availability> allAvailability = new List<Availability>();
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@date1", date1.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@date2", date2.ToString("yyyy-MM-dd"));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime date = Convert.ToDateTime(reader["_date"]);
                    string availability = reader["availabilityForTheDay"].ToString();
                    AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);
                    bool isTaken = Convert.ToBoolean(reader["isTaken"]);

                    Availability availability1 = new Availability(date, selected_availability, isTaken);
                    allAvailability.Add(availability1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Taking user availability data failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }
            return allAvailability;
        }


        /// <summary>
        /// Retrieves the availability for a specific user on a specific date.
        /// </summary>
        /// <param name="date1">The date for which the user's availability is to be retrieved.</param>
        /// <param name="id">The ID of the user whose availability is to be retrieved.</param>
        /// <returns>An <see cref="Availability"/> object representing the user's availability for the specified date, or null if no availability record is found.</returns>
        /// <exception cref="Exception">Thrown when there is an issue with retrieving the data from the database.</exception>
        public Availability TakeDayUserAvailability(DateOnly date1, int id)
        {
            string query = "SELECT _date, availabilityForTheDay, isTaken FROM Availabilty " +
                "WHERE person_id=@id AND _date = @date1";

            Availability availability1 = null;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@date1", date1.ToString("yyyy-MM-dd"));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime date = Convert.ToDateTime(reader["_date"]);
                    string availability = reader["availabilityForTheDay"].ToString();
                    AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);
                    bool isTaken = Convert.ToBoolean(reader["isTaken"]);

                    availability1 = new Availability(date, selected_availability, isTaken);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Taking user availability data failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }
            return availability1;
        }



        /// <summary>
        /// Updates the availability status (isTaken) for a user on a specific date and shift.
        /// </summary>
        /// <param name="availability">The <see cref="Availability"/> object representing the availability to be updated.</param>
        /// <param name="id">The ID of the user whose availability is being updated.</param>
        /// <param name="selected_date">The date for which the availability status is being updated.</param>
        /// <param name="selectedShift">The shift for which the availability status is being updated.</param>
        /// <exception cref="Exception">Thrown when there is an issue with updating the availability status in the database.</exception>
        public void ChangeIsTaken(Availability availability, int id, DateTime selected_date, AvailabilityForTheDay selectedShift)
        {
            string query = "UPDATE Availabilty SET isTaken = @availability WHERE person_id = @id AND _date = @date and availabilityForTheDay = @selectedShift;";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@availability", availability.isPersonTaken() ? 0 : 1);
                command.Parameters.AddWithValue("@id", availability.getPerson() != null ? availability.getPerson().GetId() : id);
                command.Parameters.AddWithValue("@date", selected_date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@selectedShift", selectedShift.ToString());

                int rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Marking availability failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }
        }



        /// <summary>
        /// Retrieves specific availability details for a user based on their ID, date, and shift.
        /// </summary>
        /// <param name="selected_person">The <see cref="Person"/> object representing the user whose availability is being retrieved.</param>
        /// <param name="selected_date">The date for which availability details are to be retrieved.</param>
        /// <param name="selectedAvailability">The shift for which availability details are being retrieved.</param>
        /// <returns>An <see cref="Availability"/> object representing the availability details for the specified user, date, and shift, or null if no record is found.</returns>
        /// <exception cref="Exception">Thrown when there is an issue with retrieving the availability details from the database.</exception>
        public Availability FindAvailability(Person selected_person, DateTime selected_date, AvailabilityForTheDay selectedAvailability)
        {
            string query = "SELECT * from Availabilty WHERE person_id = @id AND _date = @date and availabilityForTheDay = @selectedAvailability ;";
            Availability newAvailability = null;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", selected_person.GetId());
                command.Parameters.AddWithValue("@date", selected_date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@selectedAvailability", selectedAvailability.ToString());

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["person_id"]);
                    DateTime date = Convert.ToDateTime(reader["_date"]);
                    string availability = reader["availabilityForTheDay"].ToString();
                    AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);
                    bool isTaken = Convert.ToBoolean(reader["isTaken"]);

                    newAvailability = new Availability(selected_person, date, selected_availability, isTaken);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Finding availability failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }
            return newAvailability;
        }





        /// <summary>
        /// Inserts a new availability record into the database for a specified person.
        /// </summary>
        /// <param name="person_id">The ID of the person for whom the availability is being added.</param>
        /// <param name="availabilityForTheDay">The shift for which the availability is being added.</param>
        /// <param name="_date">The date for which the availability is being added.</param>
        /// <param name="isTaken">A boolean indicating whether the shift is taken (true) or not (false).</param>
        /// <exception cref="Exception">Thrown when there is an issue with inserting the availability record into the database.</exception>
        public void AddAvailability(int person_id, AvailabilityForTheDay availabilityForTheDay, DateTime _date, bool isTaken)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"INSERT INTO Availabilty (person_id, _date, availabilityForTheDay, isTaken) VALUES (@person_id, @_date, @availabilityForTheDay, @isTaken)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@person_id", person_id);
                cmd.Parameters.AddWithValue("@availabilityForTheDay", availabilityForTheDay.ToString());
                cmd.Parameters.AddWithValue("@_date", _date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@isTaken", isTaken);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Adding availability failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }

        }


        /// <summary>
        /// Retrieves a list of available people who can be scheduled for work 
        /// based on the given date, role, and department.
        /// </summary>
        /// <param name="givenDate">The date to filter availability.</param>
        /// <param name="givenRole">The role to filter employees by.</param>
        /// <param name="givenDepartment">The department to filter employees by.</param>
        /// <returns>A list of available employees with their availability details.</returns>
        public List<Availability> GetAvailabilityForScheduleGenerator(DateTime givenDate, Role givenRole, Department givenDepartment)
        {
            string query = "SELECT p.id, p.email,p.firstName, p.lastName, p.gender, p.phoneNumber, p.startingDate, " +
                "p.manager_id, p.department, p._role, p.stillWorking,p.Wage, p._floor, a._date, a.availabilityForTheDay, a.isTaken " +
                "FROM Person p " +
                "JOIN Availabilty a ON p.id = a.person_id " +
                "WHERE a._date = @date and p.stillWorking = 1 and a.availabilityForTheDay != 'Unavailable' " +
                "and p._role = @role and p.department = @department and a.isTaken = 0;";
            List<Availability> allAvailability = new List<Availability>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@date", givenDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@role", givenRole.ToString());
                command.Parameters.AddWithValue("@department", givenDepartment.ToString());

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string email = reader["email"].ToString();
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    string gender = reader["gender"].ToString();
                    string phoneNumber = reader["phoneNumber"].ToString();
                    DateTime startingDate = Convert.ToDateTime(reader["startingDate"]);
                    int manager_id = Convert.ToInt32(reader["manager_id"]);
                    string department = reader["department"].ToString();
                    string role = reader["_role"].ToString();
                    Role selected_role = (Role)Enum.Parse(typeof(Role), role);
                    int stillWorking = Convert.ToInt32(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    DateTime date = Convert.ToDateTime(reader["_date"]);
                    string availability = reader["availabilityForTheDay"].ToString();
                    AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);
                    bool isTaken = Convert.ToBoolean(reader["isTaken"]);
                    bool selected_stilWorking;
                    double wage = Convert.ToDouble(reader["Wage"]);
                    int floor = Convert.ToInt32(reader["_floor"]);


                    Person newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor);
                    newPerson.PhoneNumber = phoneNumber;
                    Availability availability1 = new Availability(newPerson, date, selected_availability, isTaken);
                    allAvailability.Add(availability1);
                }
                return allAvailability;
            }
            catch (Exception ex)
            {
                throw new Exception("Generating schedule failed due to database issues. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }


        /// <summary>
        /// Resets the schedule by marking all shifts as not taken for a specified date.
        /// </summary>
        /// <param name="selected_date">The date for which the schedule will be cleared.</param>
        public void ClearSchedule(DateTime selected_date)
        {
            string query = "UPDATE Availabilty SET isTaken = 0 WHERE  _date = @date;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                string formattedDate = selected_date.ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@date", formattedDate);
                int rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Clearing schedule failed due to database issues. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Deletes the availability of a specific person from the database.
        /// </summary>
        /// <param name="person_id">The ID of the person whose availability is to be deleted.</param>
        public void DeleteAvailability(int person_id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"Delete from Availabilty where person_id = @person_id";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@person_id", person_id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Deleting availability of selected person failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Checks if a worker has been assigned any shifts for a given date.
        /// </summary>
        /// <param name="selectedDate">The date to check for assigned shifts.</param>
        /// <param name="personid">The ID of the person to check shifts for.</param>
        /// <returns>True if shifts are assigned, otherwise false.</returns>
        public bool GetShiftsAssignedPerWorker(DateTime selectedDate, int personid)
        {
            string query = $"SELECT person_id, COUNT(*) AS row_count FROM Availabilty WHERE _date = @date AND person_id = @person_id GROUP BY person_id;";

            SqlConnection connection = new SqlConnection(connectionString);

            int result = 0;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@person_id", personid);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = (int)reader["row_count"];
                }

            }
            catch (Exception e)
            {
                throw new Exception("An issue occured in the database and password could not be found. \nTry again later!");

            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
            return result != 0;
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
            string query = $"SELECT Count(*) as 'alreadyAssigned' " +
                $"FROM Person p JOIN Availabilty a ON p.id = a.person_id " +
                $"where p._role = @role " +
                $"and p.department = @department " +
                $"and p.stillWorking = 1 " +
                $"and a._date = @date " +
                $"and a.availabilityForTheDay = @shift " +
                $"and a.isTaken = 1";

            Dictionary<int, int> contrainer = new Dictionary<int, int>();
            SqlConnection connection = new SqlConnection(connectionString);


            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@role", selectedRole.ToString());
                command.Parameters.AddWithValue("@department", selectedDepartment.ToString());
                command.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@shift", shift.ToString());

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int number = (int)reader["alreadyAssigned"];
                    return number;
                }
                throw new Exception("An issue reading assigned people for the shift. \nTry again later!");
            }
            catch (Exception e)
            {
                throw new Exception("An issue reading assigned people for the shift. \nTry again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
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
            string query = "SELECT TOP (@num) p.id, p.email, p.firstName, p.lastName, p.gender, " +
                "p.phoneNumber, p.startingDate, p.manager_id, p.department, p._role, " +
                "p.stillWorking, p.Wage, p._floor, a._date, a.availabilityForTheDay, a.isTaken " +
                "FROM Person p " +
                "JOIN Availabilty a ON p.id = a.person_id " +
                "WHERE p._role = @role " +
                "AND p.department = @department " +
                "AND p.stillWorking = 1" +
                "AND a._date = @date " +
                "AND a.availabilityForTheDay = @availabilityForTheDay " +
                "AND " +
                "   ((a.availabilityForTheDay = 'FirstShift' AND NOT EXISTS ( " +
                "       SELECT 1 " +
                "       FROM Availabilty a2 " +
                "       WHERE a2.person_id = p.id " +
                "       AND a2._date = a._date " +
                "       AND a2.availabilityForTheDay = 'ThirdShift' " +
                "       AND a2.isTaken = 1 )) " +
                "   OR " +
                "   (a.availabilityForTheDay = 'ThirdShift' AND NOT EXISTS ( " +
                "       SELECT 1 " +
                "       FROM Availabilty a2 " +
                "       WHERE a2.person_id = p.id " +
                "       AND a2._date = a._date " +
                "       AND a2.availabilityForTheDay = 'FirstShift' " +
                "       AND a2.isTaken = 1 )) " +
                "   OR @availabilityForTheDay = 'SecondShift' ) " +
                "AND a.isTaken = 0;";

            List<Availability> allAvailability = new List<Availability>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@num", number);
                command.Parameters.AddWithValue("@role", selectedRole.ToString());
                command.Parameters.AddWithValue("@department", selectedDepartment.ToString());
                command.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@availabilityForTheDay", shift.ToString());

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string email = reader["email"].ToString();
                    //string password = reader["_password"].ToString();
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    string gender = reader["gender"].ToString();
                    string phoneNumber = reader["phoneNumber"].ToString();
                    DateTime startingDate = Convert.ToDateTime(reader["startingDate"]);
                    int manager_id = Convert.ToInt32(reader["manager_id"]);
                    string department = reader["department"].ToString();
                    string role = reader["_role"].ToString();
                    Role selected_role = (Role)Enum.Parse(typeof(Role), role);
                    int stillWorking = Convert.ToInt32(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    DateTime date = Convert.ToDateTime(reader["_date"]);
                    string availability = reader["availabilityForTheDay"].ToString();
                    AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);
                    bool isTaken = Convert.ToBoolean(reader["isTaken"]);
                    bool selected_stilWorking;
                    double wage = Convert.ToDouble(reader["Wage"]);
                    int floor = Convert.ToInt32(reader["_floor"]);


                    Person newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor);
                    newPerson.PhoneNumber = phoneNumber;
                    Availability availability1 = new Availability(newPerson, date, selected_availability, isTaken);
                    allAvailability.Add(availability1);
                }
                return allAvailability;
            }
            catch (Exception ex)
            {
                throw new Exception("Generating schedule failed due to database issues. \nPlease try again later!");

            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }



        /// <summary>
        /// Records changes to shifts, such as newly assigned employees, into the ShiftChanges table.
        /// </summary>
        /// <param name="date">The date of the shift change.</param>
        /// <param name="department">The department associated with the shift change.</param>
        /// <param name="role">The role associated with the shift change.</param>
        /// <param name="availabilityForTheDay">The shift availability being changed.</param>
        /// <param name="numOfEmployees">The number of employees affected by the shift change.</param>
        public void AddShiftChange(DateTime date, Department department, Role role, AvailabilityForTheDay availabilityForTheDay, int numOfEmployees)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"INSERT into ShiftChanges(_date,department,_role,availabilityForTheDay,numOfEmployees)values(@date,@department,@role,@availabilityForTheDay,@numOfEmployees)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@department", department.ToString());
                cmd.Parameters.AddWithValue("@role", role.ToString());
                cmd.Parameters.AddWithValue("@availabilityForTheDay", availabilityForTheDay.ToString());
                cmd.Parameters.AddWithValue("@numOfEmployees", numOfEmployees);
                DeleteDuplicateShiftChanges(date, department, role, availabilityForTheDay);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Adding shift change failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }

        }


        /// <summary>
        /// Removes duplicate shift change entries for a specific date, department, role, and shift.
        /// </summary>
        /// <param name="date">The date of the shift change to check for duplicates.</param>
        /// <param name="department">The department associated with the shift change.</param>
        /// <param name="role">The role associated with the shift change.</param>
        /// <param name="availabilityForTheDay">The shift to check for duplicates.</param>
        public void DeleteDuplicateShiftChanges(DateTime date, Department department, Role role, AvailabilityForTheDay availabilityForTheDay)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"delete from ShiftChanges where _date = @date and department = @department and _role = @role and availabilityForTheDay = @availabilityForTheDay";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@department", department.ToString());
                cmd.Parameters.AddWithValue("@role", role.ToString());
                cmd.Parameters.AddWithValue("@availabilityForTheDay", availabilityForTheDay.ToString());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Deleting duplicate shifts failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }

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
            string query = "SELECT numOfEmployees from ShiftChanges where _date = @date and department = @department and _role = @role and availabilityForTheDay = @availabilityForTheDay";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@department", department.ToString());
                command.Parameters.AddWithValue("@role", role.ToString());
                command.Parameters.AddWithValue("@availabilityForTheDay", availabilityForTheDay.ToString());


                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["numOfEmployees"] != DBNull.Value)
                    {
                        return Convert.ToInt32(reader["numOfEmployees"]);
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading special shift failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
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
            string query = "SELECT p.id, p.email,p.firstName, p.lastName, p.gender, p.phoneNumber, p.startingDate, " +
                "p.manager_id, p.department, p._role, p.stillWorking,p.Wage, p._floor, a._date, a.availabilityForTheDay, " +
                "a.isTaken " +
                "FROM Person p " +
                "JOIN Availabilty a ON p.id = a.person_id " +
                "WHERE a._date = @date and p.stillWorking = 1 and a.availabilityForTheDay != 'Unavailable' " +
                "and p._role = @role and p.department = @department;";
            List<Availability> allAvailability = new List<Availability>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@date", givenDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@role", givenRole.ToString());
                command.Parameters.AddWithValue("@department", givenDepartment.ToString());

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string email = reader["email"].ToString();
                    //string password = reader["_password"].ToString();
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    string gender = reader["gender"].ToString();
                    string phoneNumber = reader["phoneNumber"].ToString();
                    DateTime startingDate = Convert.ToDateTime(reader["startingDate"]);
                    int manager_id = Convert.ToInt32(reader["manager_id"]);
                    string department = reader["department"].ToString();
                    string role = reader["_role"].ToString();
                    Role selected_role = (Role)Enum.Parse(typeof(Role), role);
                    int stillWorking = Convert.ToInt32(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    DateTime date = Convert.ToDateTime(reader["_date"]);
                    string availability = reader["availabilityForTheDay"].ToString();
                    AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);
                    bool isTaken = Convert.ToBoolean(reader["isTaken"]);
                    bool selected_stilWorking;
                    double wage = Convert.ToDouble(reader["Wage"]);
                    int floor = Convert.ToInt32(reader["_floor"]);


                    Person newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor);
                    newPerson.PhoneNumber = phoneNumber;
                    Availability availability1 = new Availability(newPerson, date, selected_availability, isTaken);
                    allAvailability.Add(availability1);
                }
                return allAvailability;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading people for planer page failed due to database issues. \nPlease try again later!");

            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }



        /// <summary>
        /// Retrieves all shift transfer requests for a given department where the request has not been approved.
        /// </summary>
        /// <param name="givenDepartment">The department to filter shift transfer requests by.</param>
        /// <returns>A list of shift transfer requests, including employee and shift details.</returns>
        public List<ShiftExchange> ReadShifTransferRequests(Department givenDepartment)
        {
            string query = "SELECT s.personId, s.selectedDate, s.selectedShift,s.reason, p.email, p.firstName, p.lastName, p.gender, " +
                "p.phoneNumber, p.startingDate, p.manager_id, p.department, p._role, p.stillWorking,p.Wage, p._floor " +
                "from shiftTransfers s " +
                "join Person p on s.personId = p.id " +
                "where p.department = @department and s.approved = 0";
            List<ShiftExchange> allAvailability = new List<ShiftExchange>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@department", givenDepartment.ToString());

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["personId"]);
                    string email = reader["email"].ToString();
                    //string password = reader["_password"].ToString();
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    string gender = reader["gender"].ToString();
                    string phoneNumber = reader["phoneNumber"].ToString();
                    DateTime startingDate = Convert.ToDateTime(reader["startingDate"]);
                    int manager_id = Convert.ToInt32(reader["manager_id"]);
                    string department = reader["department"].ToString();
                    string role = reader["_role"].ToString();
                    Role selected_role = (Role)Enum.Parse(typeof(Role), role);
                    int stillWorking = Convert.ToInt32(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    DateTime date = Convert.ToDateTime(reader["selectedDate"]);
                    string availability = reader["selectedShift"].ToString();
                    AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);
                    bool isTaken = true;
                    bool selected_stilWorking;
                    double wage = Convert.ToDouble(reader["Wage"]);
                    int floor = Convert.ToInt32(reader["_floor"]);
                    string reason = reader["reason"].ToString();


                    Person newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor);
                    newPerson.PhoneNumber = phoneNumber;
                    Availability availability1 = new Availability(newPerson, date, selected_availability, isTaken);
                    allAvailability.Add(new ShiftExchange(availability1,reason));
                }
                return allAvailability;
            }
            catch (SqlException ex)
            {
                throw new Exception("Reading shift transfer requests. \nPlease try again later!");

            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
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
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"SELECT COUNT(*) FROM shiftTransfers WHERE personId = @personId AND selectedDate = @selectedDate AND selectedShift = @selectedShift";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@personId", person_id);
                command.Parameters.AddWithValue("@selectedDate", _date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@selectedShift", availabilityForTheDay.ToString());

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking existing request. \nPlease try again later!", ex);
            }
            finally
            {
                connection.Close();
            }
        }



        /// <summary>
        /// Inserts a new shift transfer request for a specific person, shift, and date.
        /// </summary>
        /// <param name="person_id">The ID of the person requesting the transfer.</param>
        /// <param name="availabilityForTheDay">The availability status of the shift to transfer.</param>
        /// <param name="_date">The date of the shift to transfer.</param>
        /// <param name="reason">The reason for requesting the transfer.</param>
        public void RequestTransfer(int person_id, AvailabilityForTheDay availabilityForTheDay, DateTime _date, string reason)
        {
            bool isTaken = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"INSERT into shiftTransfers(personId,selectedDate,selectedShift, reason) values(@personId, @selectedDate, @selectedShift, @reason)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@personId", person_id);
                cmd.Parameters.AddWithValue("@selectedDate", _date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@selectedShift", availabilityForTheDay.ToString());
                cmd.Parameters.AddWithValue("@reason", reason.ToString());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Shift transger request failed. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }

        }


        /// <summary>
        /// Deletes an existing shift transfer request for a specific person, shift, and date.
        /// </summary>
        /// <param name="personId">The ID of the person whose request is being deleted.</param>
        /// <param name="selectedDate">The date of the shift transfer request.</param>
        /// <param name="availabilityForTheDay">The availability status of the shift being deleted.</param>
        public void DeleteShiftTransferRequest(int personId, DateTime selectedDate, AvailabilityForTheDay availabilityForTheDay)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"Delete from shiftTransfers where personId = @personId and selectedDate = @selectedDate and selectedShift=@selectedShift";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@personId", personId);
                cmd.Parameters.AddWithValue("@selectedDate", selectedDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@selectedShift", availabilityForTheDay.ToString());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Deleting shift request failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Retrieves a specific shift transfer request based on a detailed string description.
        /// </summary>
        /// <param name="givenInfo">A string containing the concatenated information about the transfer request.</param>
        /// <returns>A ShiftExchange object representing the detailed shift transfer request.</returns>
        public ShiftExchange FindConcreteAvailability(string givenInfo)
        {
            string query = "select s.personId, s.selectedDate, s.selectedShift, s.reason, p.email, p.firstName, p.lastName, " +
            "p.gender, p.phoneNumber, p.startingDate, p.manager_id, p.department, p._role, p.stillWorking,p.Wage, p._floor " +
            "from shiftTransfers s " +
            "join Person p on s.personId = p.id " +
            "WHERE CONCAT(s.personId, ' - ', p.firstName, ' ', p.lastName, ' - (', p._floor, ') - ',s.selectedDate,' - ',s.selectedShift,' - ',s.reason) = @givenInfo;";
            ShiftExchange newShiftExchange = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@givenInfo", givenInfo);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["personId"]);
                    string email = reader["email"].ToString();
                    //string password = reader["_password"].ToString();
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    string gender = reader["gender"].ToString();
                    string phoneNumber = reader["phoneNumber"].ToString();
                    DateTime startingDate = Convert.ToDateTime(reader["startingDate"]);
                    int manager_id = Convert.ToInt32(reader["manager_id"]);
                    string department = reader["department"].ToString();
                    string role = reader["_role"].ToString();
                    Role selected_role = (Role)Enum.Parse(typeof(Role), role);
                    int stillWorking = Convert.ToInt32(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    DateTime date = Convert.ToDateTime(reader["selectedDate"]);
                    string availability = reader["selectedShift"].ToString();
                    AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);
                    bool isTaken = true;
                    bool selected_stilWorking;
                    double wage = Convert.ToDouble(reader["Wage"]);
                    int floor = Convert.ToInt32(reader["_floor"]);
                    string reason = reader["reason"].ToString();


                    Person newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor);
                    newPerson.PhoneNumber = phoneNumber;
                    newShiftExchange = new ShiftExchange(new Availability(newPerson, date, selected_availability, isTaken),reason);
                }
                return newShiftExchange;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading shift transfer requests. \nPlease try again later!");

            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }


        /// <summary>
        /// Updates a shift transfer request's status to approved for a specific person, shift, and date.
        /// </summary>
        /// <param name="person_id">The ID of the person whose request is being updated.</param>
        /// <param name="availabilityForTheDay">The availability status of the shift being approved.</param>
        /// <param name="_date">The date of the shift being approved.</param>
        public void UpdateShiftRequestStatus(int person_id, AvailabilityForTheDay availabilityForTheDay, DateTime _date)
        {
            bool isTaken = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"update shiftTransfers set approved = 1 where personId = @personId and selectedDate = @selectedDate and selectedShift=@selectedShift";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@personId", person_id);
                cmd.Parameters.AddWithValue("@selectedDate", _date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@selectedShift", availabilityForTheDay.ToString());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Shift transger request failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }

        }

        /// <summary>
        /// Retrieves a list of possible shift changes for a specific person, 
        /// checking other approved transfers and finding compatible shifts for swapping.
        /// </summary>
        /// <param name="personId">The ID of the person requesting possible shift changes.</param>
        /// <returns>A list of tuples containing the email, date, and shift of potential shifts available for transfer.</returns>
        public List<Tuple<string, DateTime, AvailabilityForTheDay>> GetPossibleShiftChanges(int personId)
        {
            string query = "WITH PersonSchedule AS ( SELECT person_id, _date, availabilityForTheDay\r\n    FROM Availabilty\r\n    WHERE person_id = @personId\r\n    AND isTaken = 1\r\n),\r\nCancelledShifts AS (\r\n    SELECT s.personId, s.selectedDate, s.selectedShift\r\n    FROM shiftTransfers s\r\n    JOIN Person p ON s.personId = p.id\r\n    WHERE s.approved = 1\r\n\tand personId != @personId\r\n\tAND p.department = (SELECT department FROM Person WHERE id = @personId)\r\n    AND p._role = (SELECT _role FROM Person WHERE id = @personId)\r\n\tAND s.selectedDate > GETDATE()\r\n),\r\nOwnCancelledShifts AS (\r\n    SELECT selectedDate, selectedShift\r\n    FROM shiftTransfers\r\n    WHERE personId = @personId\r\n)\r\nSELECT distinct cs.personId AS FriendId,p.email, cs.selectedDate, cs.selectedShift\r\nFROM CancelledShifts cs\r\nLEFT JOIN PersonSchedule ps\r\n    ON cs.selectedDate = ps._date\r\nLEFT JOIN OwnCancelledShifts ocs\r\n    ON cs.selectedDate = ocs.selectedDate\r\n    AND cs.selectedShift = ocs.selectedShift\r\njoin Person p on p.id = cs.personId\r\nAND ocs.selectedShift IS NULL\r\nAND NOT EXISTS (\r\n    SELECT 1\r\n    FROM PersonSchedule ps2\r\n    WHERE ps2.person_id = @personId\r\n    AND ps2._date = cs.selectedDate\r\n    AND ps2.availabilityForTheDay = cs.selectedShift\r\n)\r\nAND (\r\n    (cs.selectedShift = 'FirstShift' AND (ps.availabilityForTheDay = 'SecondShift' OR ps.availabilityForTheDay IS NULL))\r\n    OR (cs.selectedShift = 'SecondShift' AND (ps.availabilityForTheDay IN ('FirstShift', 'ThirdShift') OR ps.availabilityForTheDay IS NULL))\r\n    OR (cs.selectedShift = 'ThirdShift' AND (ps.availabilityForTheDay = 'SecondShift' OR ps.availabilityForTheDay IS NULL))\r\n)\r\nAND NOT EXISTS (\r\n    SELECT 1\r\n    FROM PersonSchedule ps2\r\n    WHERE ps2.person_id = @personId\r\n    AND ps2._date = cs.selectedDate\r\n    AND (\r\n        (cs.selectedShift = 'FirstShift' AND ps2.availabilityForTheDay = 'ThirdShift')\r\n        OR (cs.selectedShift = 'ThirdShift' AND ps2.availabilityForTheDay = 'FirstShift')\r\n    )\r\n)ORDER BY cs.selectedDate\r\n;";
            List<Tuple<string, DateTime, AvailabilityForTheDay>> possibleTransfers = new List<Tuple<string, DateTime, AvailabilityForTheDay>>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@personId", personId);
               
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string email = reader["email"].ToString();
                    DateTime date = Convert.ToDateTime(reader["selectedDate"]);
                    string availability = reader["selectedShift"].ToString();
                    AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);

                    Tuple<string,DateTime,AvailabilityForTheDay> newShiftExchange = Tuple.Create(email,date, selected_availability);
                    possibleTransfers.Add(newShiftExchange);
                }
                return possibleTransfers;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading possible transfers failed. \nPlease try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }

        /// <summary>
        /// Marks person as unavailable for the selectedDates.
        /// </summary>
        /// <param name="person_id">The ID of the person whose availability will be removed.</param>
        /// <param name="selectedDates">The list of dates to remove.</param>
        public void RemoveAvailability(int person_id, List<DateTime> selectedDates)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Availabilty WHERE person_id = @person_id AND _date = @_date";

                try
                {
                    connection.Open();
                    foreach (var date in selectedDates)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@person_id", person_id);
                            command.Parameters.AddWithValue("@_date", date);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while removing availability.", ex);
                }
            }
        }



        /// <summary>
        /// Marks person as available for the selected timeslot
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="date">The date of the availability.</param>
        /// <param name="shift">The shift availability for the day.</param>
        public void AddAvailability(int personId, DateTime date, AvailabilityForTheDay shift)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"INSERT INTO Availabilty (person_id, _date, availabilityForTheDay, IsTaken) VALUES (@PersonId, @Date, @Shift, {0})";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonId", personId);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@Shift", shift.ToString());

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Adding availability failed.");
                }
            }
        }


        /// <summary>
        /// Checks if a specific date exists for a person.
        /// </summary>
        /// <param name="person_id">The ID of the person.</param>
        /// <param name="selectedDate">The selected date.</param>
        /// <returns>True if the date exists, otherwise false.</returns>
        public bool IsDateExist(int person_id, DateTime selectedDate)
        {
            bool isShiftSelected = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT COUNT(*) FROM Availabilty WHERE person_id = @person_id AND _date = @_date";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@person_id", person_id);
                command.Parameters.AddWithValue("@_date", selectedDate);

                int count = (int)command.ExecuteScalar();
                isShiftSelected = count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Checking date failed.");
            }
            finally
            {
                connection.Close();
            }

            return isShiftSelected;
        }






    }
}
