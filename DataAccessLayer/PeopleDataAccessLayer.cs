using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using MediaBazaarApp;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    /// <summary>
    /// Provides methods for interacting with the Person table in the database,
    /// including checking user login status, retrieving user IDs, updating login status,
    /// and finding specific person records.
    /// </summary>
    public class PeopleDataAccessLayer
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi527531_mediashop;User Id=dbi527531_mediashop;Password=mediashop123; TrustServerCertificate=True";
        //SQLDatabase sqlDatabase = new SQLDatabase();

        /// <summary>
        /// Checks if a user is logging in for the first time based on their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns><c>true</c> if the user is logging in for the first time; otherwise, <c>false</c>.</returns>
        /// <exception cref="Exception">Thrown when there is an issue with retrieving the user's first login status from the database.</exception>
        public bool IsUserLoggingINFortheFirstTime(string email)
        {
            string query = $"Select isFirstLogIn from Person where email = @email";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                int result = Convert.ToInt32(command.ExecuteScalar());
                return result == 1;
            }
            catch (Exception e)
            {
                throw new Exception("An issue occured in the database and user activity history could not be found \nPlease,try again later!");

            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }

        /// <summary>
        /// Retrieves the ID of a user based on their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>The ID of the user.</returns>
        /// <exception cref="Exception">Thrown when there is an issue with finding the user ID in the database.</exception>
        public int GetUserId(string email)
        {
            string query = $"Select id from Person where email = @email";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception("An issue occured in the database and finding user failed \nPlease,try again later!");

            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }

        /// <summary>
        /// Marks a user's login as successful by updating their login status.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <exception cref="Exception">Thrown when there is an issue with marking the login activity in the database.</exception>
        public void MarkSuccessfullLogIn(string email)
        {
            string query = $"Update Person set isFirstLogIn = 0 where email = @email";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("An marking login activity \nPlease,try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }

        /// <summary>
        /// Finds a specific person based on a concatenated string of their information.
        /// </summary>
        /// <param name="givenInfo">A string containing concatenated person information (ID, name, and floor).</param>
        /// <returns>A <see cref="Person"/> object representing the found person, or <c>null</c> if no matching person is found.</returns>
        /// <exception cref="Exception">Thrown when there is an issue with retrieving the person data from the database.</exception>
        public Person FindConcretePerson(string givenInfo)
        {
            string query = "SELECT * FROM Person " +
                "WHERE CONCAT(id, ' - ', firstName, ' ', lastName, ' - (', _floor, ')') = @givenInfo;";
            Person readPerson = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@givenInfo", givenInfo);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
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
                    bool stillWorking = Convert.ToBoolean(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    double wage = Convert.ToDouble(reader["Wage"]);
                    string secretQuestion = reader["secretQuestion"].ToString();
                    string secretAnswer = reader["secretAnswer"].ToString();
                    int floor = Convert.ToInt32(reader["_floor"]);

                    readPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                    readPerson.PhoneNumber = phoneNumber;
                    readPerson.setManager(ReadPersonById(manager_id));
                }
                return readPerson;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading employee failed");
            }
            finally
            {
                connection.Close();
            }
        }



        /// <summary>
        /// Reads a list of people based on the provided filters, department, and role for the selected page.
        /// </summary>
        /// <param name="selectedDepartment">The department filter.</param>
        /// <param name="selectedRole">The role filter.</param>
        /// <param name="StillWorking">Indicates whether the person is still working or not.</param>
        /// <param name="pageNum">The page number to retrieve.</param>
        /// <param name="filteringCriteria">The search criteria to filter people by.</param>
        /// <returns>A list of <see cref="Person"/> objects for the selected page.</returns>
        public List<Person> ReadPeopleForSelectedPage(Department? selectedDepartment, Role? selectedRole, bool StillWorking, int pageNum, string filteringCriteria)
        {
            string query = "select * from Person where stillWorking = @stillWorking ";

            if (!string.IsNullOrEmpty(selectedDepartment.ToString()))
            {
                query += "and department = @department ";
            }
            if (!string.IsNullOrEmpty(selectedRole.ToString()))
            {
                query += "and _role = @role ";
            }
            if (!string.IsNullOrEmpty(filteringCriteria))
            {
                query += "and (firstName LIKE '%' + @filteringCriteria + '%' " +
                    "OR lastName LIKE '%' + @filteringCriteria + '%' " +
                    "OR email LIKE '%' + @filteringCriteria + '%' " +
                    "OR id LIKE '%' + @filteringCriteria + '%') ";
            }
            query += "ORDER BY id " +
                "OFFSET (@pageNum - 1) * 15 ROWS " +
                "FETCH NEXT 16 ROWS ONLY;";
            List<Person> fetchedPeople = new List<Person>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (!string.IsNullOrEmpty(selectedDepartment.ToString()))
                {
                    command.Parameters.AddWithValue("@department", selectedDepartment.ToString());
                }
                if (!string.IsNullOrEmpty(selectedRole.ToString()))
                {
                    command.Parameters.AddWithValue("@role", selectedRole.ToString());
                }
                if (StillWorking)
                {
                    command.Parameters.AddWithValue("@stillWorking", 1);
                }
                else
                {
                    command.Parameters.AddWithValue("@stillWorking", 0);
                }
                if (!string.IsNullOrEmpty(filteringCriteria))
                {
                    command.Parameters.AddWithValue("@filteringCriteria", filteringCriteria);
                }
                command.Parameters.AddWithValue("@pageNum", pageNum);

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
                    bool stillWorking = Convert.ToBoolean(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    double wage = Convert.ToDouble(reader["Wage"]);
                    string secretQuestion = reader["secretQuestion"].ToString();
                    string secretAnswer = reader["secretAnswer"].ToString();
                    int floor = Convert.ToInt32(reader["_floor"]);

                    Person newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                    newPerson.PhoneNumber = phoneNumber;
                    newPerson.setManager(ReadPersonById(manager_id));
                    fetchedPeople.Add(newPerson);
                }
                return fetchedPeople;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading employees failed");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Reads a list of people excluding managers based on the provided filters, department, and whether they are still working.
        /// </summary>
        /// <param name="selectedDepartment">The department filter.</param>
        /// <param name="StillWorking">Indicates whether the person is still working or not.</param>
        /// <param name="pageNum">The page number to retrieve.</param>
        /// <param name="filteringCriteria">The search criteria to filter people by.</param>
        /// <returns>A list of <see cref="Person"/> objects excluding managers.</returns>
        public List<Person> ReadPeopleForSelectedPageDifferentFromManagers(Department? selectedDepartment, bool StillWorking, int pageNum, string filteringCriteria)
        {
            string query = "select * from Person where stillWorking = @stillWorking and _role != 'Manager' ";

            if (!string.IsNullOrEmpty(selectedDepartment.ToString()))
            {
                query += "and department = @department ";
            }
            if (!string.IsNullOrEmpty(filteringCriteria))
            {
                query += "and (firstName LIKE '%' + @filteringCriteria + '%' " +
                    "OR lastName LIKE '%' + @filteringCriteria + '%' " +
                    "OR email LIKE '%' + @filteringCriteria + '%' " +
                    "OR id LIKE '%' + @filteringCriteria + '%') ";
            }
            query += "ORDER BY id " +
                "OFFSET (@pageNum - 1) * 15 ROWS " +
                "FETCH NEXT 16 ROWS ONLY;";
            List<Person> fetchedPeople = new List<Person>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (!string.IsNullOrEmpty(selectedDepartment.ToString()))
                {
                    command.Parameters.AddWithValue("@department", selectedDepartment.ToString());
                }
                if (StillWorking)
                {
                    command.Parameters.AddWithValue("@stillWorking", 1);
                }
                else
                {
                    command.Parameters.AddWithValue("@stillWorking", 0);
                }
                if (!string.IsNullOrEmpty(filteringCriteria))
                {
                    command.Parameters.AddWithValue("@filteringCriteria", filteringCriteria);
                }
                command.Parameters.AddWithValue("@pageNum", pageNum);

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
                    bool stillWorking = Convert.ToBoolean(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    double wage = Convert.ToDouble(reader["Wage"]);
                    string secretQuestion = reader["secretQuestion"].ToString();
                    string secretAnswer = reader["secretAnswer"].ToString();
                    int floor = Convert.ToInt32(reader["_floor"]);

                    Person newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                    newPerson.PhoneNumber = phoneNumber;
                    newPerson.setManager(ReadPersonById(manager_id));
                    fetchedPeople.Add(newPerson);
                }
                return fetchedPeople;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading employees failed");
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Reads a person's details by their ID.
        /// </summary>
        /// <param name="personId">The ID of the person to retrieve.</param>
        /// <returns>A <see cref="Person"/> object if found, otherwise null.</returns>
        public Person ReadPersonById(int personId)
        {
            string query = "SELECT * from Person where id = @id";
            SqlConnection connection = new SqlConnection(connectionString);

            Person newPerson = null;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", personId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
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
                    bool stillWorking = Convert.ToBoolean(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    double wage = Convert.ToDouble(reader["Wage"]);
                    string secretQuestion = reader["secretQuestion"].ToString();
                    string secretAnswer = reader["secretAnswer"].ToString();
                    int floor = Convert.ToInt32(reader["_floor"]);

                    newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                    newPerson.PhoneNumber = phoneNumber;
                }
                return newPerson;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading person failed");
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Finds the manager of a specified department.
        /// </summary>
        /// <param name="selectedDepartment">The department to find the manager for.</param>
        /// <returns>A <see cref="Person"/> representing the manager of the department.</returns>
        public Person FindDepartmentManager(Department selectedDepartment)
        {
            string query = "SELECT TOP 1 * from Person where department = @department and _role = 'Manager' and stillWorking = 1";
            SqlConnection connection = new SqlConnection(connectionString);

            Person newPerson = null;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@department", selectedDepartment.ToString());
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
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
                    bool stillWorking = Convert.ToBoolean(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    double wage = Convert.ToDouble(reader["Wage"]);
                    string secretQuestion = reader["secretQuestion"].ToString();
                    string secretAnswer = reader["secretAnswer"].ToString();
                    int floor = Convert.ToInt32(reader["_floor"]);

                    newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                    newPerson.PhoneNumber = phoneNumber;
                }
                return newPerson;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading manager failed");
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Adds a new person to the database.
        /// </summary>
        /// <param name="p">The <see cref="Person"/> object to add.</param>
        public void AddPerson(Person p)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"INSERT INTO Person (id, email,firstName, lastName, gender, phoneNumber, startingDate, manager_id, department, _role, stillWorking,Wage,_floor,isFirstLogIn) VALUES(@id,@email,@firstName,@lastName,@gender,@phoneNumber,@startingDate,@manager_id,@department,@_role,@stillWorking,@wage,@floor,@isFirstLogIn)";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", p.GetId());
                cmd.Parameters.AddWithValue("@email", p.getEmail());
                cmd.Parameters.AddWithValue("@firstName", p.FirstName);
                cmd.Parameters.AddWithValue("@lastName", p.LastName);
                cmd.Parameters.AddWithValue("@gender", Convert.ToString(p.GetGender));
                cmd.Parameters.AddWithValue("@phoneNumber", p.PhoneNumber);
                cmd.Parameters.AddWithValue("@startingDate", p.GetStartignDate);
                cmd.Parameters.AddWithValue("@manager_id", p.GetManagerId());
                cmd.Parameters.AddWithValue("@department", p.GetDepartment.ToString());
                cmd.Parameters.AddWithValue("@_role", p.GetRole.ToString());
                cmd.Parameters.AddWithValue("@stillWorking", 1);
                cmd.Parameters.AddWithValue("@wage", p.GetWage);
                cmd.Parameters.AddWithValue("@floor", p.GetFloor);
                cmd.Parameters.AddWithValue("@isFirstLogIn", true);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Adding person failed");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Gets the highest person ID from the database.
        /// </summary>
        /// <returns>An integer representing the highest person ID.</returns>
        public int GetTheHighestId()
        {
            int id = 0;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                string query = $"SELECT MAX(id) as MaxId FROM Person;";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["MaxId"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Getting Id failed");
            }
            finally
            {
                connection.Close();
            }
            return id + 1;
        }

        /// <summary>
        /// Finds a person by their username (email).
        /// </summary>
        /// <param name="username">The email of the person to find.</param>
        /// <returns>A <see cref="Person"/> object if found, otherwise null.</returns>
        public Person FindPerson(string username)
        {
            int floor;
            string query = "SELECT * from Person WHERE email = @username;";
            Person person = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
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
                    bool stillWorking = Convert.ToBoolean(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    double wage = Convert.ToDouble(reader["Wage"]);
                    string secretQuestion = reader["secretQuestion"].ToString();
                    string secretAnswer = reader["secretAnswer"].ToString();
                    if (reader["_floor"] != DBNull.Value)
                    {
                        floor = Convert.ToInt32(reader["_floor"]);
                    }
                    else
                    {
                        floor = 1;
                    }

                    if (reader["manager_id"] == DBNull.Value)
                    {
                        person = new Person(id, email, firstName, lastName, selected_gender, startingDate, 0, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                        person.setManager(ReadPersonById(manager_id));
                        person.PhoneNumber = phoneNumber;
                    }
                    else if (reader["manager_id"] != DBNull.Value)
                    {
                        person = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                        person.PhoneNumber = phoneNumber;
                        person.setManager(ReadPersonById(manager_id));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading person failed. \nPlease try again!");
            }
            finally
            {
                connection.Close();
            }
            return person;
        }


        /// <summary>
        /// Retrieves the full name of a person by their ID.
        /// </summary>
        /// <param name="id">The ID of the person.</param>
        /// <returns>The full name of the person.</returns>
        public string FindPersonName(int id)
        {
            string name = "";
            string query = "SELECT firstName, lastName from Person " +
                "WHERE id = @id";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    name = firstName + " " + lastName;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading person failed \nPlease try again");
            }

            finally
            {
                connection.Close();
            }
            return name;
        }

        /// <summary>
        /// Changes the working status of a person in the database.
        /// </summary>
        /// <param name="person">The person whose status will be updated.</param>
        public void ChangeWorkingStatus(Person person)
        {
            string query = "UPDATE Person SET stillWorking = @stillWorking WHERE id = @id;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (person.GetStillWorking)
                {
                    command.Parameters.AddWithValue("@stillWorking", 0);
                }
                if (!person.GetStillWorking)
                {
                    command.Parameters.AddWithValue("@stillWorking", 1);
                }
                command.Parameters.AddWithValue("@id", person.GetId());

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Chainging status failed due to database issues. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Sets a secret question and answer for a person.
        /// </summary>
        /// <param name="person">The person whose secret question will be set.</param>
        /// <param name="secretQuestion">The secret question.</param>
        /// <param name="secretAnswer">The secret answer.</param>
        public void SetSecretQuestion(Person person, string secretQuestion, string secretAnswer)
        {

            string query = "UPDATE person SET secretQuestion = @secretQuestion, secretAnswer = @secretAnswer WHERE id = @id;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", person.GetId());
                cmd.Parameters.AddWithValue("@secretQuestion", secretQuestion);
                cmd.Parameters.AddWithValue("@secretAnswer", secretAnswer);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Setting secret question failed due to database issues. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }
        }




        /// <summary>
        /// Updates the phone number for a person.
        /// </summary>
        /// <param name="person">The person whose phone number will be updated.</param>
        /// <param name="phoneNumber">The new phone number.</param>
        public void UpdateUserPhoneNumber(Person person, string phoneNumber)
        {
            string query = "Update Person set phoneNumber = @phoneNumber where id = @id";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@id", person.GetId());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Updating phone number failed due to database issues. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Updates the wage for a person.
        /// </summary>
        /// <param name="person">The person whose wage will be updated.</param>
        /// <param name="newWage">The new wage value.</param>
        public void UpdateWage(Person person, double newWage)
        {
            string query = "UPDATE Person SET Wage = @wage WHERE id = @id;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@wage", Convert.ToDecimal(newWage));

                command.Parameters.AddWithValue("@id", person.GetId());

                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new Exception("Updating wage failed due to database issues. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Checks if an email is available for registration.
        /// </summary>
        /// <param name="email">The email to check.</param>
        /// <returns>True if the email is available, otherwise false.</returns>
        public bool IsEmailAvailable(string email)
        {
            string query = "SELECT COUNT(*) AS email FROM Person WHERE email = @email;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;
                throw new Exception("Database is not working at the moment please try again later");
            }
            catch (Exception e)
            {
                throw new Exception("Database is not working at the moment please try again later");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Gets the ID of a person by their email.
        /// </summary>
        /// <param name="email">The email of the person.</param>
        /// <returns>The ID of the person.</returns>
        public int GetPersonId(string email)
        {
            string query = "select id from Person where email = @email;";
            SqlConnection connection = new SqlConnection(connectionString);
            int id = 0;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading person id failed.");
            }
            finally
            {
                connection.Close();
            }
            return id;
        }

        /// <summary>
        /// Reads the details of a person by their email.
        /// </summary>
        /// <param name="givenEmail">The email of the person.</param>
        /// <returns>A <see cref="Person"/> object.</returns>
        public Person ReadPerson(string givenEmail)
        {
            string query = "select * from Person where email = @email";
            Person p = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", givenEmail);
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
                    bool stillWorking = Convert.ToBoolean(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    double wage = Convert.ToDouble(reader["Wage"]);
                    string secretQuestion = reader["secretQuestion"].ToString();
                    string secretAnswer = reader["secretAnswer"].ToString();
                    int floor = Convert.ToInt32(reader["_floor"]);

                    p = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                    p.setManager(ReadPersonById(manager_id));
                    p.PhoneNumber = phoneNumber;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading person failed due to database issues. \nPlease try again later.");
            }
            finally
            {
                connection.Close();
            }
            return p;
        }

        /// <summary>
        /// Updates user details such as email, phone number, and security questions.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="email">The user's new email.</param>
        /// <param name="phoneNumber">The user's new phone number.</param>
        /// <param name="securityQuestion">The user's new security question.</param>
        /// <param name="securityAnswer">The user's new security answer.</param>
        public void UpdateUserDetails(int userId, string email, string phoneNumber, string securityQuestion, string securityAnswer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Person 
                         SET email = @Email, 
                             phoneNumber = @PhoneNumber, 
                             secretQuestion = @SecurityQuestion, 
                             secretAnswer = @SecurityAnswer 
                         WHERE id = @UserId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@SecurityQuestion", securityQuestion);
                command.Parameters.AddWithValue("@SecurityAnswer", securityAnswer);
                command.Parameters.AddWithValue("@UserId", userId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("User details updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to update user details.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Updating user details failed.");
                }
            }
        }


        /// <summary>
        /// Records the clocking-in time for an employee.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The clock-in time.</param>
        public void ClockingIn(int id, DateTime time)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Clocking (employeeID, time) VALUES (@employeeID, @time)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@employeeID", id);
                cmd.Parameters.AddWithValue("@time", time);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Clocking in failed.");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Retrieves the total work time for a month for an employee.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="month">The month to calculate the work time for.</param>
        /// <returns>A list of <see cref="DateTime"/> objects representing work shifts.</returns>
		public List<DateTime> GetWorkTimeMonth(int id, DateTime month)
        {
            List<DateTime> results = new List<DateTime>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * from Clocking " +
                "WHERE employeeID = @employeeID " +
                "AND DATEDIFF(month, time, @time) = 0";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@time", month);
                command.Parameters.AddWithValue("@employeeID", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(Convert.ToDateTime(reader["time"]));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Calculating work time failed.");
            }
            finally
            {
                connection.Close();
            }
            return results;
        }


        /// <summary>
        /// Records the clocking-out time and calculates time worked for an employee.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The clock-out time.</param>
        /// <returns>The total time worked.</returns>
        public TimeSpan ClockOut(int id, DateTime time)
        {
            TimeSpan timeWorked = time - time;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * from Clocking  " +
                "WHERE employeeID = @employeeID " +
                "AND DATEDIFF(day, time, @time) = 0 " +
                "ORDER BY time DESC";
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@employeeID", id);
                cmd.Parameters.AddWithValue("@time", time);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime clockInTime = Convert.ToDateTime(reader["time"]);
                    timeWorked = time - clockInTime;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Clocking out failed.");
            }
            finally
            {
                connection.Close();
            }

            return timeWorked;
        }


        /// <summary>
        /// Checks if an employee has already clocked in for a specific date.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The date to check for clock-in.</param>
        /// <returns>True if the employee has clocked in, otherwise false.</returns>
        public bool CheckIfClockedIn(int id, DateTime time)
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT COUNT(*) as count from Clocking  " +
                "WHERE employeeID = @employeeID " +
                "AND DATEDIFF(day, time, @time) = 0";
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@employeeID", id);
                cmd.Parameters.AddWithValue("@time", time);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = Convert.ToInt32(reader["count"]);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Checking clocking in failed.");
            }
            finally
            {
                connection.Close();
            }

            if (count % 2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if an employee has clocked in within the last 5 minutes.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The time to check.</param>
        /// <returns>True if the employee has clocked in recently, otherwise false.</returns>
        public bool CheckIfJustClocked(int id, DateTime time)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT COUNT(*) as count from Clocking  " +
                "WHERE employeeID = @employeeID " +
                "AND DATEDIFF(minute, time, @time) < 5";
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@employeeID", id);
                cmd.Parameters.AddWithValue("@time", time);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int count = Convert.ToInt32(reader["count"]);
                    if (count > 0)
                    {
                        result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Checking clock in failed.");
            }
            finally
            {
                connection.Close();
            }

            return result;
        }








    }
}
