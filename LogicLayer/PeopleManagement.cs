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
    public class PeopleManagement
    {
        DataAccessLayer.SQLDatabase database;
        private Person newPerson;
        private Availability newAvailability;
        AvailabilitySQL availabilitySQL;
        PeopleSQL peopleSQL;
        public PeopleManagement()
        {
            database = new DataAccessLayer.SQLDatabase();
            availabilitySQL = new AvailabilitySQL();
            peopleSQL = new PeopleSQL();
        }

        public void addNewPerson(int Id, string Email,string FirstName, string LastName,string PhoneNumber, Gender Gender, DateTime StartingDate, int managerId, Department department, Role role, double wage, int floor)
        {
            newPerson = new Person(Id, Email, FirstName, LastName, Gender, StartingDate, managerId, department, role, wage, floor);
            newPerson.PhoneNumber = PhoneNumber;
            PasswordManager passwordMasker = new PasswordManager();
            string salt = passwordMasker.GenerateRandomSalt(80);
            string defaultPassword = $"password{Id}";
            string hash = passwordMasker.GenerateSHA256Hash(defaultPassword, salt);
            PasswordSQL psS = new PasswordSQL();
            database.AddPerson(newPerson);
            psS.AddPassword(Id, salt, hash);
        }

        public Person FindPerson(string username)
        {
            return database.FindPerson(username);
        }

        public List<Availability> GetAllAvailability(DateTime date1, DateTime date2, AvailabilityForTheDay shift, Department selectedDepartment, Role selectedRole)
        {
            return availabilitySQL.TakeAllCorrespondingAvailability(date1, date2,shift,selectedDepartment,selectedRole);
        }

        public List<Availability> GetUserAvailability(DateTime date1, DateTime date2, int id)
        {
            DateOnly firstDate = DateOnly.FromDateTime(date1);
            return availabilitySQL.TakeUserAvailability(firstDate, date2, id);
        }
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
        public Person FindConcretePerson(string givenInfo)
        {
            return peopleSQL.FindConcretePerson(givenInfo);
        }

        public string FindPersonName(int id)
        {
            string name = database.FindPersonName(id);
            return name;
        }

        public int GetHighestId()
        {
            return database.GetTheHighestId();
        }

        public void ChangePassword(int person_id, string newPassword)
        {
            PasswordManager passwordMasker = new PasswordManager();
            string salt = passwordMasker.GenerateRandomSalt(80);
            string hash = passwordMasker.GenerateSHA256Hash(newPassword, salt);
            PasswordSQL psql = new PasswordSQL();
            psql.UpdatePassword(person_id, salt, hash);
        }
    }
}
