using DataAccessLayer;
using LogicLayer;
using Microsoft.Data.SqlClient;
using Microsoft.Rest.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace MediaBazaarApp
{
    /// <summary>
    /// Manages operations related to people, such as adding new persons, managing availability, and handling passwords.
    /// </summary>
    public class PeopleManagement
    {
        private Person newPerson;
        private Availability newAvailability;
        AvailabilityDataAccessLayer availabilitySQL;
        PeopleDataAccessLayer peopleSQL;
        public PeopleManagement()
        {
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
            peopleSQL.AddPerson(newPerson);
            psS.AddPassword(Id, salt, hash);
        }

        /// <summary>
        /// Finds a person in the database by their username (email).
        /// </summary>
        /// <returns>A <see cref="Person"/> object if found, otherwise null.</returns>
        public Person FindPerson(string username)
        {
            return peopleSQL.FindPerson(username);
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
            string name = peopleSQL.FindPersonName(id);
            return name;
        }


        /// <summary>
        /// Gets the highest available ID in the database.
        /// </summary>
        /// <returns>The highest available ID as an integer.</returns>
        public int GetHighestId()
        {
            return peopleSQL.GetTheHighestId();
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
            if (pageNum < 0)
            {
                throw new ArgumentNullException("An invalid page number value has been passed to the system. \nPlease, try again later!");
            }
            return peopleSQL.ReadPeopleForSelectedPageDifferentFromManagers(selectedDepartment, StillWorking, pageNum, filteringCriteria);
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
            if (pageNum < 0)
            {
                throw new ArgumentNullException("An invalid page number value has been passed to the system. \nPlease, try again later!");
            }
            return peopleSQL.ReadPeopleForSelectedPage(selectedDepartment,selectedRole, StillWorking, pageNum, filteringCriteria);
        }

        /// <summary>
        /// Changes the working status of a person.
        /// </summary>
        /// <param name="person">The person whose status will be updated.</param>
        public void ChangeWorkingStatus(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("A null value has been passed to the system. \nPlease, try again later!");
            }
            peopleSQL.ChangeWorkingStatus(person);
        }


        /// <summary>
        /// Checks if an employee has clocked in within the last 5 minutes.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The time to check.</param>
        /// <returns>True if the employee has clocked in recently, otherwise false.</returns>
        public bool CheckIfJustClocked(int id, DateTime time)
        {
            if (id < 1)
            {
                throw new ArgumentNullException("An invalid id value has been passed to the system. \nPlease, try again later!");
            }
            return peopleSQL.CheckIfJustClocked(id, time);
        }

        /// <summary>
        /// Checks if an employee has already clocked in for a specific date.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The date to check for clock-in.</param>
        /// <returns>True if the employee has clocked in, otherwise false.</returns>
        public bool CheckIfClockedIn(int id, DateTime time)
        {
            if (id < 1)
            {
                throw new ArgumentNullException("An invalid id value has been passed to the system. \nPlease, try again later!");
            }
            return peopleSQL.CheckIfClockedIn(id, time);
        }


        /// <summary>
        /// Records the clocking-out time and calculates time worked for an employee.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The clock-out time.</param>
        /// <returns>The total time worked.</returns>
        public TimeSpan ClockOut(int id, DateTime time)
        {
            if (id < 1)
            {
                throw new ArgumentNullException("An invalid id value has been passed to the system. \nPlease, try again later!");
            }
            return peopleSQL.ClockOut(id, time);
        }

        /// <summary>
        /// Records the clocking-in time for an employee.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The clock-in time.</param>
        public void ClockingIn(int id, DateTime time)
        {
            if (id < 1)
            {
                throw new ArgumentNullException("An invalid id value has been passed to the system. \nPlease, try again later!");
            }
            peopleSQL.ClockingIn(id, time);
        }

        /// <summary>
        /// Retrieves the total work time for a month for an employee.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="month">The month to calculate the work time for.</param>
        /// <returns>A list of <see cref="DateTime"/> objects representing work shifts.</returns>
		public List<DateTime> GetWorkTimeMonth(int id, DateTime month)
        {
            if (id < 1)
            {
                throw new ArgumentNullException("An invalid id value has been passed to the system. \nPlease, try again later!");
            }
            return peopleSQL.GetWorkTimeMonth(id, month);
        }

        /// <summary>
        /// Checks if an email is available for registration.
        /// </summary>
        /// <param name="email">The email to check.</param>
        /// <returns>True if the email is available, otherwise false.</returns>
        public bool IsEmailAvailable(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("An null value has been passed to the system. \nPlease, try again later!");
            }
            return peopleSQL.IsEmailAvailable(email);
        }



        /// <summary>
        /// Finds the manager of a specified department.
        /// </summary>
        /// <param name="selectedDepartment">The department to find the manager for.</param>
        /// <returns>A <see cref="Person"/> representing the manager of the department.</returns>
        public Person FindDepartmentManager(Department selectedDepartment)
        {
            return peopleSQL.FindDepartmentManager(selectedDepartment);
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
            if (string.IsNullOrEmpty(email)|| userId < 0 || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(securityQuestion) || string.IsNullOrEmpty(securityAnswer))
            {
                throw new ArgumentNullException("An null value has been passed to the system. \nPlease, try again later!");
            }
            peopleSQL.UpdateUserDetails(userId, email, phoneNumber, securityQuestion, securityAnswer);
        }

        /// <summary>
        /// Gets the ID of a person by their email.
        /// </summary>
        /// <param name="email">The email of the person.</param>
        /// <returns>The ID of the person.</returns>
        public int GetPersonId(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("An null value has been passed to the system. \nPlease, try again later!");
            }
            return peopleSQL.GetPersonId(email);
        }

        /// <summary>
        /// Reads the details of a person by their email.
        /// </summary>
        /// <param name="givenEmail">The email of the person.</param>
        /// <returns>A <see cref="Person"/> object.</returns>
        public Person ReadPerson(string givenEmail)
        {
            if (string.IsNullOrEmpty(givenEmail))
            {
                throw new ArgumentNullException("An null value has been passed to the system. \nPlease, try again later!");
            }
            return peopleSQL.ReadPerson(givenEmail);
        }

        /// <summary>
        /// Updates the phone number for a person.
        /// </summary>
        /// <param name="person">The person whose phone number will be updated.</param>
        /// <param name="phoneNumber">The new phone number.</param>
        public void UpdateUserPhoneNumber(Person person, string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || person == null)
            {
                throw new ArgumentNullException("An null value has been passed to the system. \nPlease, try again later!");
            }
            peopleSQL.UpdateUserPhoneNumber(person,phoneNumber);
        }

        /// <summary>
        /// Sets a secret question and answer for a person.
        /// </summary>
        /// <param name="person">The person whose secret question will be set.</param>
        /// <param name="secretQuestion">The secret question.</param>
        /// <param name="secretAnswer">The secret answer.</param>
        public void SetSecretQuestion(Person person, string secretQuestion, string secretAnswer)
        {
            if (string.IsNullOrEmpty(secretQuestion) || string.IsNullOrEmpty(secretAnswer) || person == null)
            {
                throw new ArgumentNullException("An null value has been passed to the system. \nPlease, try again later!");
            }
            peopleSQL.SetSecretQuestion(person, secretQuestion,secretAnswer);
        }

        /// <summary>
        /// Updates the wage for a person.
        /// </summary>
        /// <param name="person">The person whose wage will be updated.</param>
        /// <param name="newWage">The new wage value.</param>
        public void UpdateWage(Person person, double newWage)
        {
            if (person == null)
            {
                throw new ArgumentNullException("An null value has been passed to the system. \nPlease, try again later!");
            }
            peopleSQL.UpdateWage(person, newWage);
        }
    }
}
