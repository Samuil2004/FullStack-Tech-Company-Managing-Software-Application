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
    public class AvailabilitySQL
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi527531_mediashop;User Id=dbi527531_mediashop;Password=mediashop123; TrustServerCertificate=True";

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

        public void ChangeIsTaken(Availability availability, int id, DateTime selected_date, AvailabilityForTheDay selectedShift)
        {
            string query = "UPDATE Availabilty SET isTaken = @availability WHERE person_id = @id AND _date = @date and availabilityForTheDay = @selectedShift;";
            //Person person = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (availability.isPersonTaken())
                {
                    command.Parameters.AddWithValue("@availability", 0);
                }
                if (!availability.isPersonTaken())
                {
                    command.Parameters.AddWithValue("@availability", 1);
                }
                if (availability.getPerson() == null)
                {
                    command.Parameters.AddWithValue("@id", id);
                }
                if (availability.getPerson() != null)
                {
                    command.Parameters.AddWithValue("@id", availability.getPerson().GetId());
                }
                string formattedDate = selected_date.ToString("yyyy-MM-dd");

                command.Parameters.AddWithValue("@date", formattedDate);
                command.Parameters.AddWithValue("@selectedShift", selectedShift.ToString());

                int rowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                ////MessageBox.Show(ex.Message);
                //if (string.IsNullOrEmpty(givenUsername) || string.IsNullOrEmpty(givenPassword))
                //{
                //    return false;
                //}
                throw new Exception("Marking availability failed. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }
            //return person;
        }
        public Availability FindAvailability(Person selected_person, DateTime selected_date, AvailabilityForTheDay selectedAvailability)
        {
            string query = "SELECT * from Availabilty WHERE person_id = @id AND _date = @date and availabilityForTheDay = @selectedAvailability ;";
            Availability newAvailability = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                //MessageBox.Show($"{selected_person.GetId()}");
                //MessageBox.Show($"{selected_date.Date}");
                //DateTime dateTimeValue = DateTime.Parse("03/03/2024 12:00:00 AM");
                //string formattedDate = selected_date.ToString();
                //string cutted = formattedDate.Substring(12);
                //Date dateTimeValue = Date.Parse(cutted);
                string formattedDate = selected_date.ToString("yyyy-MM-dd");

                //MessageBox.Show($"{dateTimeValue}");

                command.Parameters.AddWithValue("@id", selected_person.GetId());
                command.Parameters.AddWithValue("@date", formattedDate);
                command.Parameters.AddWithValue("@selectedAvailability", selectedAvailability.ToString());

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["person_id"]);
                    DateTime date = Convert.ToDateTime(reader["_date"]);
                    string availability = reader["availabilityForTheDay"].ToString();
                    AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);
                    bool isTaken = Convert.ToBoolean(reader["isTaken"]);

                    newAvailability = new Availability(id, date, selected_availability, isTaken);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //if (string.IsNullOrEmpty(givenUsername) || string.IsNullOrEmpty(givenPassword))
                //{
                //    return false;
                //}
                throw new Exception("Finding availability failed. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }
            return newAvailability;
        }
        public List<Availability> GetAvailabilityForRoleAndDate(Role Role, DateTime selectedTime)
        {
            //string query = "SELECT p.id, p.email,p.firstName, p.lastName, p.gender, p.phoneNumber, p.startingDate, p.manager_id, p.department, p._role, p.stillWorking, a._date, a.availabilityForTheDay, a.isTaken FROM Person p JOIN Availabilty a ON p.id = a.person_id WHERE a.isTaken = 0;";
            string query = "SELECT p.id, p.email,p.firstName, p.lastName, p.gender, " +
                "p.phoneNumber, p.startingDate, p.manager_id, p.department, p._role, " +
                "p.stillWorking,p.Wage, p._floor, a._date, a.availabilityForTheDay, a.isTaken " +
                "FROM Person p JOIN Availabilty a ON p.id = a.person_id where p._role = @role and a._date = @date";

            List<Availability> allAvailability = new List<Availability>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@role", Role.ToString());
                command.Parameters.AddWithValue("@date", selectedTime.ToString("yyyy-MM-dd"));
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
                    //fetchedPeople.Add(newPerson);

                }
                return allAvailability;

            }
            catch (Exception ex)
            {
                throw new Exception("Finding availability for selected date failed. \nPlease try again later!");

                ////MessageBox.Show(ex.Message);
                //if (string.IsNullOrEmpty(givenUsername) || string.IsNullOrEmpty(givenPassword))
                //{
                //    return false;

            }
            finally
            {
                connection.Close();
            }
        }
        public void AddAvailability(int person_id, AvailabilityForTheDay availabilityForTheDay, DateTime _date, bool isTaken)
        {
            //bool isTaken = false;
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
                //MessageBox.Show(ex.Message);
                throw new Exception("Adding availability failed. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }

        }

        public void AddAvailabilityForWeek(int person_id, DateTime selectedDate)
        {
            //DateTime startDate = selectedDate.AddDays(-(int)selectedDate.DayOfWeek);
            DateTime startDate = GetLastMonday(selectedDate);

            //DateTime endDate = startDate.AddDays(6);
            DateTime endDate = GetUpcomingSunday(startDate);

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                //if (date != selectedDate)
                //{
                AddAvailability(person_id, AvailabilityForTheDay.FirstShift, date,false);
                AddAvailability(person_id, AvailabilityForTheDay.SecondShift, date, false);
                AddAvailability(person_id, AvailabilityForTheDay.ThirdShift, date, false);
                //}
            }
        }
        static DateTime GetUpcomingSunday(DateTime dateOfReference)
        {
            int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)dateOfReference.DayOfWeek + 7) % 7;
            return dateOfReference.AddDays(daysUntilSunday);
        }
        static DateTime GetLastMonday(DateTime dateOfReference)
        {
            int daysUntilMonday = ((int)dateOfReference.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            return dateOfReference.AddDays(-daysUntilMonday);
        }

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
        public void ClearSchedule(DateTime selected_date)
        {
            string query = "UPDATE Availabilty SET isTaken = 0 WHERE  _date = @date;";
            //Person person = null;
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
                //MessageBox.Show(ex.Message);
                //if (string.IsNullOrEmpty(givenUsername) || string.IsNullOrEmpty(givenPassword))
                //{
                //    return false;
                //}
                throw new Exception("Clearing schedule failed due to database issues. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }
            //return person;
        }
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

        public Dictionary<int, int> GetShiftsAssignedPerDay(DateTime selectedDate)
        {
            string query = $"SELECT person_id, COUNT(*) AS row_count FROM Availabilty WHERE _date = @date AND isTaken = 1 GROUP BY person_id;";

            Dictionary<int, int> contrainer = new Dictionary<int, int>();
            SqlConnection connection = new SqlConnection(connectionString);


            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    contrainer.Add((int)reader["person_id"], (int)reader["row_count"]);
                    //hashSalt.Add("salt", (string)reader["passwordSalt"]);
                    //return hashSalt;
                }
                return contrainer;

                //throw new Exception("An issue occured in the database and password could not be found. \nTry again later!");
            }
            catch (Exception e)
            {
                //throw;
                throw new Exception("An issue occured in the database and password could not be found. \nTry again later!");

            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
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
                    //hashSalt.Add("salt", (string)reader["passwordSalt"]);
                    //return hashSalt;
                }

                //throw new Exception("An issue occured in the database and password could not be found. \nTry again later!");
            }
            catch (Exception e)
            {
                //throw;
                throw new Exception("An issue occured in the database and password could not be found. \nTry again later!");

            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
            return result != 0;
        }
        public AvailabilityForTheDay GetAssignedShift(int person_id, DateTime selectedDate)
        {
            string query = $"Select availabilityForTheDay " +
                $"from Availabilty " +
                $"where person_id = @person_id and _date = @date and isTaken = 1 ";

            Dictionary<int, int> contrainer = new Dictionary<int, int>();
            SqlConnection connection = new SqlConnection(connectionString);

            AvailabilityForTheDay selected_availability;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@person_id", person_id);

                command.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"));

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //if (!reader.IsDBNull(column))
                    string shift = reader["availabilityForTheDay"].ToString();
                    selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), shift);
                    return selected_availability;

                    //if (!reader.IsDBNull(reader.GetOrdinal("availabilityForTheDay")))
                    //{
                    //    string shift = reader["availabilityForTheDay"].ToString();
                    //    //AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), shift);
                    //    //return selected_availability;
                    //    return shift;
                    //}
                    //else
                    //{
                    //    return null;
                    //    // Handle the case when the value is null
                    //}
                    //contrainer.Add((int)reader["person_id"], (int)reader["row_count"]);
                    //hashSalt.Add("salt", (string)reader["passwordSalt"]);
                    //return hashSalt;
                }
                //return contrainer;
                //return selected_availability;

                throw new Exception("An issue occured in the database and shifts could not ve retrieved \nTry again later!");
            }
            catch (Exception ex)
            {
                //throw;
                throw new Exception(ex.Message);

            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }













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
                    //contrainer.Add((int)reader["person_id"], (int)reader["row_count"]);
                    //hashSalt.Add("salt", (string)reader["passwordSalt"]);
                    //return hashSalt;
                    return number;
                }
                //return contrainer;

                throw new Exception("An issue reading assigned people for the shift. \nTry again later!");
            }
            catch (Exception e)
            {
                //throw;
                throw new Exception("An issue reading assigned people for the shift. \nTry again later!");

            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
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
                //MessageBox.Show(ex.Message);
                throw new Exception("Adding shift change failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }

        }

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
                //MessageBox.Show(ex.Message);
                throw new Exception("Deleting duplicate shifts failed. \nPlease try again later!");
            }
            finally
            {
                connection.Close();
            }

        }

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

        //public void RequestTransfer(int person_id, AvailabilityForTheDay availabilityForTheDay, DateTime _date)
        //{
        //    bool isTaken = false;
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = $"INSERT into shiftTransfers(personId,selectedDate,selectedShift) values(@personId, @selectedDate, @selectedShift)";
        //    try
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(query, connection);
        //        SqlCommand cmd = new SqlCommand(query, connection);
        //        cmd.Parameters.AddWithValue("@personId", person_id);
        //        cmd.Parameters.AddWithValue("@selectedDate", _date.ToString("yyyy-MM-dd"));
        //        cmd.Parameters.AddWithValue("@selectedShift", availabilityForTheDay.ToString());

        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        throw new Exception("Shift transger request failed. \nPlease try again later!");

        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //}
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
                //MessageBox.Show(ex.Message);
                throw new Exception("Shift transger request failed. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }

        }
        //public List<Availability> ReadShifTransferRequests(Department givenDepartment)
        //{
        //    string query = "SELECT s.personId, s.selectedDate, s.selectedShift, p.email, p.firstName, p.lastName, p.gender, " +
        //        "p.phoneNumber, p.startingDate, p.manager_id, p.department, p._role, p.stillWorking,p.Wage, p._floor " +
        //        "from shiftTransfers s " +
        //        "join Person p on s.personId = p.id " +
        //        "where p.department = @department";
        //    List<Availability> allAvailability = new List<Availability>();
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    try
        //    {

        //        connection.Open();
        //        SqlCommand command = new SqlCommand(query, connection);

        //        command.Parameters.AddWithValue("@department", givenDepartment.ToString());

        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            int id = Convert.ToInt32(reader["personId"]);
        //            string email = reader["email"].ToString();
        //            //string password = reader["_password"].ToString();
        //            string firstName = reader["firstName"].ToString();
        //            string lastName = reader["lastName"].ToString();
        //            string gender = reader["gender"].ToString();
        //            string phoneNumber = reader["phoneNumber"].ToString();
        //            DateTime startingDate = Convert.ToDateTime(reader["startingDate"]);
        //            int manager_id = Convert.ToInt32(reader["manager_id"]);
        //            string department = reader["department"].ToString();
        //            string role = reader["_role"].ToString();
        //            Role selected_role = (Role)Enum.Parse(typeof(Role), role);
        //            int stillWorking = Convert.ToInt32(reader["stillWorking"]);
        //            Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
        //            Department selected_department = (Department)Enum.Parse(typeof(Department), department);
        //            DateTime date = Convert.ToDateTime(reader["selectedDate"]);
        //            string availability = reader["selectedShift"].ToString();
        //            AvailabilityForTheDay selected_availability = (AvailabilityForTheDay)Enum.Parse(typeof(AvailabilityForTheDay), availability);
        //            bool isTaken = true;
        //            bool selected_stilWorking;
        //            double wage = Convert.ToDouble(reader["Wage"]);
        //            int floor = Convert.ToInt32(reader["_floor"]);


        //            Person newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor);
        //            newPerson.PhoneNumber = phoneNumber;
        //            Availability availability1 = new Availability(newPerson, date, selected_availability, isTaken);
        //            allAvailability.Add(availability1);
        //        }
        //        return allAvailability;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("Reading shift transfer requests. \nPlease try again later!");

        //    }
        //    finally
        //    {
        //        if (connection != null && connection.State == ConnectionState.Open)
        //        { connection.Close(); }
        //    }
        //}
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
            //public bool CheckExistingRequest(int person_id, AvailabilityForTheDay availabilityForTheDay, DateTime _date)
            //{
            //    SqlConnection connection = new SqlConnection(connectionString);
            //    string query = $"SELECT COUNT(*) FROM shiftTransfers WHERE personId = @personId AND selectedDate = @selectedDate AND selectedShift = @selectedShift";

            //    try
            //    {
            //        connection.Open();
            //        SqlCommand command = new SqlCommand(query, connection);

            //        SqlCommand cmd = new SqlCommand(query, connection);

            //        command.Parameters.AddWithValue("@personId", person_id);
            //        command.Parameters.AddWithValue("@selectedDate", _date.ToString("yyyy-MM-dd"));
            //        command.Parameters.AddWithValue("@selectedShift", availabilityForTheDay.ToString());

            //        int count = (int)command.ExecuteScalar();
            //        return count > 0;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Error checking existing request. \nPlease try again later!", ex);
            //    }

            //    finally
            //    {
            //        connection.Close();
            //    }

            //}



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
                //MessageBox.Show(ex.Message);
                throw new Exception("Shift transger request failed. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }

        }

        public List<Tuple<string,DateTime,AvailabilityForTheDay>> GetPossibleShiftChanges(int personId)
        {

            string query = "WITH PersonSchedule AS (\r\n    SELECT person_id, _date, availabilityForTheDay\r\n    FROM Availabilty\r\n    WHERE person_id = @personId\r\n    AND isTaken = 1\r\n),\r\nCancelledShifts AS (\r\n    SELECT s.personId, s.selectedDate, s.selectedShift\r\n    FROM shiftTransfers s\r\n    JOIN Person p ON s.personId = p.id\r\n    WHERE s.approved = 1\r\n\tand personId != @personId\r\n\tAND p.department = (SELECT department FROM Person WHERE id = @personId)\r\n    AND p._role = (SELECT _role FROM Person WHERE id = @personId)\r\n\tAND s.selectedDate > GETDATE()\r\n),\r\nOwnCancelledShifts AS (\r\n    SELECT selectedDate, selectedShift\r\n    FROM shiftTransfers\r\n    WHERE personId = @personId\r\n)\r\nSELECT distinct cs.personId AS FriendId,p.email, cs.selectedDate, cs.selectedShift\r\nFROM CancelledShifts cs\r\nLEFT JOIN PersonSchedule ps\r\n    ON cs.selectedDate = ps._date\r\nLEFT JOIN OwnCancelledShifts ocs\r\n    ON cs.selectedDate = ocs.selectedDate\r\n    AND cs.selectedShift = ocs.selectedShift\r\njoin Person p on p.id = cs.personId\r\nAND ocs.selectedShift IS NULL\r\nAND NOT EXISTS (\r\n    SELECT 1\r\n    FROM PersonSchedule ps2\r\n    WHERE ps2.person_id = @personId\r\n    AND ps2._date = cs.selectedDate\r\n    AND ps2.availabilityForTheDay = cs.selectedShift\r\n)\r\nAND (\r\n    (cs.selectedShift = 'FirstShift' AND (ps.availabilityForTheDay = 'SecondShift' OR ps.availabilityForTheDay IS NULL))\r\n    OR (cs.selectedShift = 'SecondShift' AND (ps.availabilityForTheDay IN ('FirstShift', 'ThirdShift') OR ps.availabilityForTheDay IS NULL))\r\n    OR (cs.selectedShift = 'ThirdShift' AND (ps.availabilityForTheDay = 'SecondShift' OR ps.availabilityForTheDay IS NULL))\r\n)\r\nAND NOT EXISTS (\r\n    SELECT 1\r\n    FROM PersonSchedule ps2\r\n    WHERE ps2.person_id = @personId\r\n    AND ps2._date = cs.selectedDate\r\n    AND (\r\n        (cs.selectedShift = 'FirstShift' AND ps2.availabilityForTheDay = 'ThirdShift')\r\n        OR (cs.selectedShift = 'ThirdShift' AND ps2.availabilityForTheDay = 'FirstShift')\r\n    )\r\n)ORDER BY cs.selectedDate\r\n;";
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
    }
}
