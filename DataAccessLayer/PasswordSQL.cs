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

    /// <summary>
    /// Provides methods for interacting with the password storage in the database, 
    /// including retrieving, updating, and adding password hashes and salts.
    /// </summary>
    public class PasswordSQL
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi527531_mediashop;User Id=dbi527531_mediashop;Password=mediashop123; TrustServerCertificate=True";


        /// <summary>
        /// Retrieves the password hash and salt for a specific user.
        /// </summary>
        /// <param name="id">The ID of the user whose password hash and salt are to be retrieved.</param>
        /// <returns>A dictionary containing the password hash and salt for the specified user.</returns>
        /// <exception cref="Exception">Thrown when there is an issue with retrieving the password hash and salt from the database.</exception>
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


        /// <summary>
        /// Updates the password hash and salt for a specific user.
        /// </summary>
        /// <param name="id">The ID of the user whose password is to be updated.</param>
        /// <param name="salt">The new salt to be used for the password.</param>
        /// <param name="hash">The new hash to be used for the password.</param>
        /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
        /// <exception cref="Exception">Thrown when there is an issue with updating the password in the database.</exception>
        public bool UpdatePassword(int id, string salt, string hash)
        {
            string query = "Update Passwords set passwordSalt = @salt, " +
                "passwordHash = @hash where person_id = @id;";

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@salt", salt);
                command.Parameters.AddWithValue("@hash", hash);
                int result = Convert.ToInt32(command.ExecuteScalar());
                if (result == 0)
                {
                    return true;
                }
                throw new Exception("Failed to update password \n Please,try again later!");
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

        /// <summary>
        /// Adds a new password entry for a specific user.
        /// </summary>
        /// <param name="id">The ID of the user for whom the password is being added.</param>
        /// <param name="salt">The salt for the new password.</param>
        /// <param name="hash">The hash for the new password.</param>
        /// <exception cref="Exception">Thrown when there is an issue with adding the password to the database.</exception>
        public void AddPassword(int id, string salt, string hash)
        {
            string query = "Insert into Passwords (person_id,passwordSalt,passwordHash) values (@id,@salt, " +
                "@hash);";

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@salt", salt);
                command.Parameters.AddWithValue("@hash", hash);
                int result = Convert.ToInt32(command.ExecuteScalar());
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
