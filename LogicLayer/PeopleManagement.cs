using DataAccessLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace MediaBazaarApp
{
    /// <summary>
    /// Manages operations related to people, such as adding new persons, managing availability, and handling passwords.
    /// </summary>
    public class PeopleManagement
    {
        DataAccessLayer.SQLDatabase database;
        private Person newPerson;
        private Availability newAvailability;
        AvailabilityDataAccessLayer availabilitySQL;
        PeopleDataAccessLayer peopleSQL;
        public PeopleManagement()
        {
            database = new DataAccessLayer.SQLDatabase();
            availabilitySQL = new AvailabilityDataAccessLayer();
            peopleSQL = new PeopleDataAccessLayer();
        }

        /// <summary>
        /// Adds a new person to the database and generates a default password with a salted hash.
        /// </summary>
        public void addNewPerson(int Id, string Email,string FirstName, string LastName,string PhoneNumber, Gender Gender, DateTime StartingDate, int managerId, Department department, Role role, double wage, int floor)
        {
            newPerson = new Person(Id, Email, FirstName, LastName, Gender, StartingDate, managerId, department, role, wage, floor);
            newPerson.PhoneNumber = PhoneNumber;
            PasswordManager passwordMasker = new PasswordManager();
            string salt = passwordMasker.GenerateRandomSalt(80);
            string defaultPassword = $"password{Id}";
            string hash = passwordMasker.GenerateSHA256Hash(defaultPassword, salt);
            PasswordDataAccessLayer psS = new PasswordDataAccessLayer();
            database.AddPerson(newPerson);
            psS.AddPassword(Id, salt, hash);
        }

        /// <summary>
        /// Finds a person in the database by their username (email).
        /// </summary>
        /// <returns>A <see cref="Person"/> object if found, otherwise null.</returns>
        public Person FindPerson(string username)
        {
            return database.FindPerson(username);
        }

        /// <summary>
        /// Retrieves all availability records between two dates for a specific shift, department, and role.
        /// </summary>
        /// <returns>A list of <see cref="Availability"/> records that match the criteria.</returns>
        public List<Availability> GetAllAvailability(DateTime date1, DateTime date2, AvailabilityForTheDay shift, Department selectedDepartment, Role selectedRole)
        {
            return availabilitySQL.TakeAllCorrespondingAvailability(date1, date2,shift,selectedDepartment,selectedRole);
        }

        /// <summary>
        /// Retrieves the availability for a specific user between two dates.
        /// </summary>
        /// <param name="date1">The start date for availability search.</param>
        /// <param name="date2">The end date for availability search.</param>
        /// <param name="id">The ID of the user whose availability is being checked.</param>
        /// <returns>A list of <see cref="Availability"/> records for the user.</returns>
        public List<Availability> GetUserAvailability(DateTime date1, DateTime date2, int id)
        {
            DateOnly firstDate = DateOnly.FromDateTime(date1);
            return availabilitySQL.TakeUserAvailability(firstDate, date2, id);
        }


        /// <summary>
        /// Checks the availability of a user for a specific date.
        /// </summary>
        /// <param name="date">The date to check availability for.</param>
        /// <param name="id">The ID of the user.</param>
        /// <returns>An <see cref="Availability"/> object representing the user's availability.</returns>
        public Availability CheckUserAvailability(DateTime date, int id)
        {
            if(availabilitySQL.GetShiftsAssignedPerWorker(date, id))
            {
                DateOnly date1 = DateOnly.FromDateTime(date);
                return availabilitySQL.TakeDayUserAvailability(date1, id);
            }
            else
            {
                Availability availability = new Availability(date, AvailabilityForTheDay.Unavailable);
                return availability;
            }
        }

        /// <summary>
        /// Finds a person based on specific information such as email or name.
        /// </summary>
        /// <param name="givenInfo">The information (e.g., email or name) used to find the person.</param>
        /// <returns>A <see cref="Person"/> object if a match is found, otherwise null.</returns>
        public Person FindConcretePerson(string givenInfo)
        {
            return peopleSQL.FindConcretePerson(givenInfo);
        }

        /// <summary>
        /// Retrieves the full name of a person by their ID.
        /// </summary>
        /// <param name="id">The ID of the person.</param>
        /// <returns>The full name of the person as a string.</returns>
        public string FindPersonName(int id)
        {
            string name = database.FindPersonName(id);
            return name;
        }


        /// <summary>
        /// Gets the highest available ID in the database.
        /// </summary>
        /// <returns>The highest available ID as an integer.</returns>
        public int GetHighestId()
        {
            return database.GetTheHighestId();
        }


        /// <summary>
        /// Changes the password for a specific person in the database.
        /// </summary>
        /// <param name="person_id">The ID of the person whose password is being changed.</param>
        /// <param name="newPassword">The new password to set.</param>
        public void ChangePassword(int person_id, string newPassword)
        {
            PasswordManager passwordMasker = new PasswordManager();
            string salt = passwordMasker.GenerateRandomSalt(80);
            string hash = passwordMasker.GenerateSHA256Hash(newPassword, salt);
            PasswordDataAccessLayer psql = new PasswordDataAccessLayer();
            psql.UpdatePassword(person_id, salt, hash);
        }
    }
}
