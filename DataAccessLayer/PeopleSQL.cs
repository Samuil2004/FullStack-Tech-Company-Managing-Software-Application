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
    public class PeopleSQL
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi527531_mediashop;User Id=dbi527531_mediashop;Password=mediashop123; TrustServerCertificate=True";
        SQLDatabase sqlDatabase = new SQLDatabase();

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
                //return result == 1;
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

                //return Convert.ToInt32(command.ExecuteScalar());
                //return result == 1;
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
        public List<Person> FindFilteredPeople(Department selectedDepartment, int pageNum)
        {
            string query = "select * from Person " +
                "where department = @department " +
                "and stillWorking = 1 " +
                "ORDER BY id " +
                "OFFSET(@pageNum - 1) * 15 ROWS " +
                "FETCH NEXT 16 ROWS ONLY; ";
            List<Person> readPeople = new List<Person>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@department", selectedDepartment);
                command.Parameters.AddWithValue("@pageNum", pageNum);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
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
                    bool stillWorking = Convert.ToBoolean(reader["stillWorking"]);
                    Gender selected_gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    Department selected_department = (Department)Enum.Parse(typeof(Department), department);
                    double wage = Convert.ToDouble(reader["Wage"]);
                    string secretQuestion = reader["secretQuestion"].ToString();
                    string secretAnswer = reader["secretAnswer"].ToString();
                    int floor = Convert.ToInt32(reader["_floor"]);

                    Person newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                    newPerson.PhoneNumber = phoneNumber;
                    newPerson.setManager(sqlDatabase.ReadPersonById(manager_id));

                    readPeople.Add(newPerson);
                }
                return readPeople;
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
