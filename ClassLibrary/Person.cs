using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp
{
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

        public void setManager(Person p)
        {
            this.manager = p;
        }

        public int GetId() 
        { 
            return this.id; 
        }  
        public int GetManagerId()
        {
            return this.managerID;
        }
        public string FirstName
        {
            get { return this.firstName; }
        }
        public string LastName
        {
            get { return this.lastName; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string PhoneNumber
        {
            get {  return phoneNumber; } 
            set {  phoneNumber = value; }
        }

        public int ID
        {
            get { return this.id; }
        }
		public string Email
		{
			get { return email; }
		}
		public void NoLongerWorking()
        {
            stillWorking = false;
        }
        public bool GetStillWorking
        {
            get { return stillWorking; }
        }
        public string GetName
        {
            get { return $"{this.firstName} {this.lastName}"; }
        }

        public string GetInfo()
        {
            return $"{id} - {email} - ({firstName} {lastName})";
        }
        public string GetShortInfo()
        {
            return $"{id} - {firstName} {lastName} - ({floor})";
        }
        public string getEmail()
        {
            return email;
        }
        public Department GetDepartment
        {
            get { return department; }
        }
		public string? PersonDetailedInfo
		{
			get
			{
				string managerName = manager != null ? manager.GetName : "Unknown";
				return $"Id: {id}\r\n Name: {firstName} {lastName}\r\n Email: {email}\r\n Phone Number: {phoneNumber}\r\n Gender: {gender}\r\n Starting Date: {startingDate:dd/MM/yyyy}\r\n Manager: {managerName}\r\n Department: {department}\r\n Role: {role}\r\n Still Working: {stillWorking}\r\n  Wage: €{wage}\r\n  Floor: {floor}";
			}
		}


		public Role GetRole
        {
            get { return role; }
        }
        public Gender GetGender
        {
            get { return gender; }
        }

        public DateTime GetStartignDate
        {
            get { return this.startingDate; }
        }

        public string SecretQuestion
        {
            get { return  secretQuestion; }
        }

		public string SecretAnswer
		{
			get { return secretAnswer; }
		}
        public double GetWage
        {
            get { return wage; }
        }

        public int GetFloor
        {
            get { return this.floor; }
        }
	}
}
