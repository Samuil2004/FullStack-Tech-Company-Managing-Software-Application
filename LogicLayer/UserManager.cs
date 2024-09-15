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
    public class UserManager
    {
        public bool CheckUser(string username,string password)
        {
            PasswordSQL passSQL = new PasswordSQL();
            SQLDatabase db = new SQLDatabase();
            PasswordManager manager = new PasswordManager();
            Dictionary<string, string> ContainerForSaltHash = passSQL.GetUserHashSalt(db.GetPersonId(username));
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
        public bool IsUserLoggingINFortheFirstTime(string email)
        {
            PeopleSQL peopleSQL = new PeopleSQL();
            if(string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("A null value has been passed!");
            }
            return peopleSQL.IsUserLoggingINFortheFirstTime(email);
        }
        public int GetUserId(string email)
        {
            PeopleSQL peopleSQL = new PeopleSQL();
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("A null value has been passed!");
            }
            return peopleSQL.GetUserId(email);
        }
        public void MarkSuccessfullLogIn(string email)
        {
            PeopleSQL peopleSQL = new PeopleSQL();
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("A null value has been passed!");
            }
            peopleSQL.MarkSuccessfullLogIn(email);
        }
    }
}
