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
        SQLDatabase sqlDatabase = new SQLDatabase();

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
                    readPerson.setManager(sqlDatabase.ReadPersonById(manager_id));
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

    }
}
