using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp
{
    /// <summary>
    /// Represents an individual person within the system, including personal details, role, and employment information.
    /// </summary>
    public class Person
    {
        private int id;
        private string email;
        private string password;
        private string firstName;
        private string lastName;
        private Gender gender;
        private string phoneNumber;
        private DateTime startingDate;
        private int managerID;
        private Person manager;
        private Department department;
        private Role role;
        private bool stillWorking;
        private string secretQuestion;
        private string secretAnswer;
        private double wage;
        private int floor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class with the specified details.
        /// </summary>
        public Person(int id, string email, string firstName, string lastName, Gender gender, DateTime startingDate, int managerID, Department department, Role role, double wage, int floor, bool stillWorking = true)
        {
            this.id = id;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.startingDate = startingDate;
            this.managerID = managerID;
            this.department = department;
            this.role = role;
            this.stillWorking = stillWorking;
            this.wage = wage;
            this.floor = floor;
            if (floor == null)
            {
                floor = 1;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class with the specified details including secret question and answer.
        /// </summary>
        public Person(int id, string email, string firstName, string lastName, Gender gender, DateTime startingDate, int managerID, Department department, Role role, double wage, int floor, string secretQuestion, string secretAnswer, bool stillWorking = true)
        {
            this.id = id;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.startingDate = startingDate;
            this.managerID = managerID;
            this.department = department;
            this.role = role;
            this.stillWorking = stillWorking;
            this.wage = wage;
            this.floor = floor;
            this.secretQuestion = secretQuestion;
            this.secretAnswer = secretAnswer;
            if (floor == null)
            {
                floor = 1;
            }
        }

        /// <summary>
        /// Sets the manager for the person.
        /// </summary>
        /// <param name="p">The <see cref="Person"/> object representing the manager.</param>
        public void setManager(Person p)
        {
            this.manager = p;
        }

        /// <summary>
        /// Gets the unique identifier of the person.
        /// </summary>
        /// <returns>The unique identifier of the person.</returns>
        public int GetId()
        {
            return this.id;
        }

        /// <summary>
        /// Gets the unique identifier of the person's manager.
        /// </summary>
        /// <returns>The unique identifier of the person's manager.</returns>
        public int GetManagerId()
        {
            return this.managerID;
        }

        /// <summary>
        /// Gets the first name of the person.
        /// </summary>
        public string FirstName
        {
            get { return this.firstName; }
        }

        /// <summary>
        /// Gets the last name of the person.
        /// </summary>
        public string LastName
        {
            get { return this.lastName; }
        }

        /// <summary>
        /// Gets or sets the phone number of the person.
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        /// <summary>
        /// Gets the unique identifier of the person.
        /// </summary>
        public int ID
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets the email address of the person.
        /// </summary>
        public string Email
        {
            get { return email; }
        }

        /// <summary>
        /// Gets a flag indicating if the person is still working.
        /// </summary>
        public bool GetStillWorking
        {
            get { return stillWorking; }
        }

        /// <summary>
        /// Gets the full name of the person.
        /// </summary>
        public string GetName
        {
            get { return $"{this.firstName} {this.lastName}"; }
        }

        /// <summary>
        /// Gets a formatted string containing the person's ID, email, and full name.
        /// </summary>
        /// <returns>A string representing the person's ID, email, and name.</returns>
        public string GetInfo()
        {
            return $"{id} - {email} - ({firstName} {lastName})";
        }

        /// <summary>
        /// Gets a formatted string containing the person's ID, full name, and floor.
        /// </summary>
        /// <returns>A string representing the person's ID, name, and floor.</returns>
        public string GetShortInfo()
        {
            return $"{id} - {firstName} {lastName} - ({floor})";
        }

        /// <summary>
        /// Gets the email address of the person.
        /// </summary>
        /// <returns>The email address of the person.</returns>
        public string getEmail()
        {
            return email;
        }

        /// <summary>
        /// Gets the department the person belongs to.
        /// </summary>
        public Department GetDepartment
        {
            get { return department; }
        }

        /// <summary>
        /// Gets detailed information about the person, including their manager and other personal details.
        /// </summary>
        public string? PersonDetailedInfo
        {
            get
            {
                string managerName = manager != null ? manager.GetName : "Unknown";
                return $"Id: {id}\r\n Name: {firstName} {lastName}\r\n Email: {email}\r\n Phone Number: {phoneNumber}\r\n Gender: {gender}\r\n Starting Date: {startingDate:dd/MM/yyyy}\r\n Manager: {managerName}\r\n Department: {department}\r\n Role: {role}\r\n Still Working: {stillWorking}\r\n Wage: €{wage}\r\n Floor: {floor}";
            }
        }

        /// <summary>
        /// Gets the role of the person within the organization.
        /// </summary>
        public Role GetRole
        {
            get { return role; }
        }

        /// <summary>
        /// Gets the gender of the person.
        /// </summary>
        public Gender GetGender
        {
            get { return gender; }
        }

        /// <summary>
        /// Gets the starting date of the person in the organization.
        /// </summary>
        public DateTime GetStartignDate
        {
            get { return this.startingDate; }
        }

        /// <summary>
        /// Gets the secret question associated with the person.
        /// </summary>
        public string SecretQuestion
        {
            get { return secretQuestion; }
        }

        /// <summary>
        /// Gets the answer to the secret question associated with the person.
        /// </summary>
        public string SecretAnswer
        {
            get { return secretAnswer; }
        }

        /// <summary>
        /// Gets the wage of the person.
        /// </summary>
        public double GetWage
        {
            get { return wage; }
        }

        /// <summary>
        /// Gets the floor the person works on.
        /// </summary>
        public int GetFloor
        {
            get { return this.floor; }
        }
    }
}
