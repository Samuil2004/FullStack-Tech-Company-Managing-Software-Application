using DataAccessLayer;
using MediaBazaarApp;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Manages user-related operations, including authentication, checking first-time login, and marking successful logins.
    /// </summary>
    public class UserManager
    {
        /// <summary>
        /// Checks if a user exists and verifies their password.
        /// </summary>
        /// <param name="username">The username (email) of the user to check.</param>
        /// <param name="password">The password entered by the user.</param>
        /// <returns>True if the username and password match, otherwise false.</returns>
        public bool CheckUser(string username,string password)
        {
            PasswordDataAccessLayer passSQL = new PasswordDataAccessLayer();
            PeopleManagement peopleManager = new PeopleManagement();
            PasswordManager manager = new PasswordManager();
            Dictionary<string, string> ContainerForSaltHash = passSQL.GetUserHashSalt(peopleManager.GetPersonId(username));
            string testHash = manager.GenerateSHA256Hash(password, ContainerForSaltHash["salt"]);
            if (ContainerForSaltHash["hash"].Equals(testHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a user is logging in for the first time.
        /// </summary>
        /// <param name="email">The email of the user to check.</param>
        /// <returns>True if the user is logging in for the first time, otherwise false.</returns>
        /// <exception cref="ArgumentException">Thrown when a null or empty email is passed.</exception>
        public bool IsUserLoggingINFortheFirstTime(string email)
        {
            PeopleDataAccessLayer peopleSQL = new PeopleDataAccessLayer();
            if(string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("A null value has been passed!");
            }
            return peopleSQL.IsUserLoggingINFortheFirstTime(email);
        }


        /// <summary>
        /// Retrieves the user ID for a given email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>The user ID as an integer.</returns>
        /// <exception cref="ArgumentException">Thrown when a null or empty email is passed.</exception>
        public int GetUserId(string email)
        {
            PeopleDataAccessLayer peopleSQL = new PeopleDataAccessLayer();
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("A null value has been passed!");
            }
            return peopleSQL.GetUserId(email);
        }

        /// <summary>
        /// Marks a user as having successfully logged in.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <exception cref="ArgumentException">Thrown when a null or empty email is passed.</exception>
        public void MarkSuccessfullLogIn(string email)
        {
            PeopleDataAccessLayer peopleSQL = new PeopleDataAccessLayer();
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("A null value has been passed!");
            }
            peopleSQL.MarkSuccessfullLogIn(email);
        }
    }
}
