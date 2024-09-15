using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography.Xml;
using System.Collections;
using System.Linq.Expressions;
using System.Diagnostics.Metrics;
using System.Reflection;
using Azure.Core;
using Microsoft.VisualBasic;

namespace DataAccessLayer
{
    public class PasswordSQL
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi527531_mediashop;User Id=dbi527531_mediashop;Password=mediashop123; TrustServerCertificate=True";



        public Dictionary<string, string> GetUserHashSalt(int id)
        {
            string query = $"SELECT passwordHash, passwordSalt FROM Passwords WHERE person_id = @id";

            Dictionary<string, string> hashSalt = new Dictionary<string, string>();
            SqlConnection connection = new SqlConnection(connectionString);


            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                // Allow the query to the be sent Database
                //SqlCommand command = new SqlCommand(query, connection);

                // Add the parameters

                // Execute the query and get the data
                //using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    hashSalt.Add("hash", (string)reader["passwordHash"]);
                    hashSalt.Add("salt", (string)reader["passwordSalt"]);
                    return hashSalt;
                }

                throw new Exception("An issue occured in the database and password could not be found. \nTry again later!");
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
        }
        //public void AddPassHash(int id,string salt, string hash)
        //{
        //    string query = $"Insert into Passwords(person_id,passwordSalt,passwordHash) values (@id,@passwordSalt,@passwordHash)";

        //    Dictionary<string, string> hashSalt = new Dictionary<string, string>();
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    try
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(query, connection);

        //        // Add the parameters
        //        command.Parameters.AddWithValue("@id", id);
        //        command.Parameters.AddWithValue("@passwordSalt", salt);
        //        command.Parameters.AddWithValue("@passwordHash", hash);
        //        command.ExecuteNonQuery();

        //        // Execute the query and get the data
        //        //using SqlDataReader reader = command.ExecuteReader();

        //        //throw new Exception();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        //if (connection != null && connection.State == ConnectionState.Open)
        //        //{ connection.Close(); }
        //    }
        //}
        public bool UpdatePassword(int id, string salt, string hash)
        {
            string query = "Update Passwords set passwordSalt = @salt, " +
                "passwordHash = @hash where person_id = @id;";

            //SqlConnection connection = null;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                //SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@salt", salt);
                command.Parameters.AddWithValue("@hash", hash);
                //command.ExecuteScalar();
                int result = Convert.ToInt32(command.ExecuteScalar());
                if (result == 0)
                {
                    return true;
                }
                //else
                //{
                throw new Exception("Failed to update password \n Please,try again later!");
                //throw new Exception("An issue occured in the database and password could not be found. \nTry again later!");

                //throw new Exception();

                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update password \n Please,try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
        public void AddPassword(int id, string salt, string hash)
        {
            string query = "Insert into Passwords (person_id,passwordSalt,passwordHash) values (@id,@salt, " +
                "@hash);";

            //SqlConnection connection = null;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                //SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@salt", salt);
                command.Parameters.AddWithValue("@hash", hash);
                //command.ExecuteScalar();
                int result = Convert.ToInt32(command.ExecuteScalar());
                //if (result == 0)
                //{
                //    return true;
                //}
                //else
                //{
                //throw new Exception("Failed to add password \n Please,try again later!");
                //throw new Exception();

                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add password \nPlease,try again later!");
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }
    }
}
