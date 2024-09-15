using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using ClassLibrary;
using MediaBazaarApp;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    /// <summary>
    /// Represents a class to interact with a SQL Database.
    /// </summary>
    public class SQLDatabase
    {
        /// <summary>
        /// Connection string used to establish a connection with the SQL server.
        /// </summary>
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi527531_mediashop;User Id=dbi527531_mediashop;Password=mediashop123; TrustServerCertificate=True";



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
            string query = "select * from Person where stillWorking = @stillWorking ";

            if(!string.IsNullOrEmpty(selectedDepartment.ToString()))
            {
                query += "and department = @department ";
            }
            if(!string.IsNullOrEmpty(selectedRole.ToString()))
            {
                query += "and _role = @role ";
            }
            if(!string.IsNullOrEmpty(filteringCriteria))
            {
                query += "and (firstName LIKE '%' + @filteringCriteria + '%' " +
                    "OR lastName LIKE '%' + @filteringCriteria + '%' " +
                    "OR email LIKE '%' + @filteringCriteria + '%' " +
                    "OR id LIKE '%' + @filteringCriteria + '%') ";
            }
            query += "ORDER BY id " +
                "OFFSET (@pageNum - 1) * 15 ROWS " +
                "FETCH NEXT 16 ROWS ONLY;";
            List<Person> fetchedPeople = new List<Person>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (!string.IsNullOrEmpty(selectedDepartment.ToString()))
                {
                    command.Parameters.AddWithValue("@department", selectedDepartment.ToString());
                }
                if (!string.IsNullOrEmpty(selectedRole.ToString()))
                {
                    command.Parameters.AddWithValue("@role", selectedRole.ToString());
                }
                if (StillWorking)
                {
                    command.Parameters.AddWithValue("@stillWorking",1);
                }
                else
                {
                    command.Parameters.AddWithValue("@stillWorking",0);
                }
                if (!string.IsNullOrEmpty(filteringCriteria))
                {
                    command.Parameters.AddWithValue("@filteringCriteria", filteringCriteria);
                }
                command.Parameters.AddWithValue("@pageNum", pageNum);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string email = reader["email"].ToString();
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
                    newPerson.setManager(ReadPersonById(manager_id));
                    fetchedPeople.Add(newPerson);
                }
                return fetchedPeople;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading employees failed");
            }
            finally
            {
                connection.Close();
            }
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
            string query = "select * from Person where stillWorking = @stillWorking and _role != 'Manager' ";

            if (!string.IsNullOrEmpty(selectedDepartment.ToString()))
            {
                query += "and department = @department ";
            }
            if (!string.IsNullOrEmpty(filteringCriteria))
            {
                query += "and (firstName LIKE '%' + @filteringCriteria + '%' " +
                    "OR lastName LIKE '%' + @filteringCriteria + '%' " +
                    "OR email LIKE '%' + @filteringCriteria + '%' " +
                    "OR id LIKE '%' + @filteringCriteria + '%') ";
            }
            query += "ORDER BY id " +
                "OFFSET (@pageNum - 1) * 15 ROWS " +
                "FETCH NEXT 16 ROWS ONLY;";
            List<Person> fetchedPeople = new List<Person>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (!string.IsNullOrEmpty(selectedDepartment.ToString()))
                {
                    command.Parameters.AddWithValue("@department", selectedDepartment.ToString());
                }
                if (StillWorking)
                {
                    command.Parameters.AddWithValue("@stillWorking", 1);
                }
                else
                {
                    command.Parameters.AddWithValue("@stillWorking", 0);
                }
                if (!string.IsNullOrEmpty(filteringCriteria))
                {
                    command.Parameters.AddWithValue("@filteringCriteria", filteringCriteria);
                }
                command.Parameters.AddWithValue("@pageNum", pageNum);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string email = reader["email"].ToString();
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
                    newPerson.setManager(ReadPersonById(manager_id));
                    fetchedPeople.Add(newPerson);
                }
                return fetchedPeople;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading employees failed");
            }
            finally
            {
                connection.Close();
            }
        }



        /// <summary>
        /// Reads a person's details by their ID.
        /// </summary>
        /// <param name="personId">The ID of the person to retrieve.</param>
        /// <returns>A <see cref="Person"/> object if found, otherwise null.</returns>
        public Person ReadPersonById(int personId)
        {
            string query = "SELECT * from Person where id = @id";
            SqlConnection connection = new SqlConnection(connectionString);

            Person newPerson = null;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", personId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string email = reader["email"].ToString();
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

                    newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                    newPerson.PhoneNumber = phoneNumber;
                }
                return newPerson;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading person failed");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Finds the manager of a specified department.
        /// </summary>
        /// <param name="selectedDepartment">The department to find the manager for.</param>
        /// <returns>A <see cref="Person"/> representing the manager of the department.</returns>
        public Person FindDepartmentManager(Department selectedDepartment)
        {
            string query = "SELECT TOP 1 * from Person where department = @department and _role = 'Manager' and stillWorking = 1";
            SqlConnection connection = new SqlConnection(connectionString);

            Person newPerson = null;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@department", selectedDepartment.ToString());
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string email = reader["email"].ToString();
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

                    newPerson = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                    newPerson.PhoneNumber = phoneNumber;
                }
                return newPerson;
            }
            catch (Exception ex)
            {
                throw new Exception("Reading manager failed");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Adds a new person to the database.
        /// </summary>
        /// <param name="p">The <see cref="Person"/> object to add.</param>
        public void AddPerson(Person p)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"INSERT INTO Person (id, email,firstName, lastName, gender, phoneNumber, startingDate, manager_id, department, _role, stillWorking,Wage,_floor,isFirstLogIn) VALUES(@id,@email,@firstName,@lastName,@gender,@phoneNumber,@startingDate,@manager_id,@department,@_role,@stillWorking,@wage,@floor,@isFirstLogIn)";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", p.GetId());
                cmd.Parameters.AddWithValue("@email", p.getEmail());
                cmd.Parameters.AddWithValue("@firstName", p.FirstName);
                cmd.Parameters.AddWithValue("@lastName", p.LastName);
                cmd.Parameters.AddWithValue("@gender", Convert.ToString(p.GetGender));
                cmd.Parameters.AddWithValue("@phoneNumber", p.PhoneNumber);
                cmd.Parameters.AddWithValue("@startingDate", p.GetStartignDate);
                cmd.Parameters.AddWithValue("@manager_id", p.GetManagerId());
                cmd.Parameters.AddWithValue("@department", p.GetDepartment.ToString());
                cmd.Parameters.AddWithValue("@_role", p.GetRole.ToString());
                cmd.Parameters.AddWithValue("@stillWorking", 1);
                cmd.Parameters.AddWithValue("@wage", p.GetWage);
                cmd.Parameters.AddWithValue("@floor", p.GetFloor);
                cmd.Parameters.AddWithValue("@isFirstLogIn",true);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Adding person failed");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Retrieves restocking requests from sales representatives.
        /// </summary>
        /// <returns>A list of <see cref="RestockingRequest"/> objects.</returns>
        public List<RestockingRequest> GetRequestsFromSalesRepresentative()
        {
            List<RestockingRequest> requests = new List<RestockingRequest>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        string query = "SELECT * FROM RestockingRequests WHERE RequestFrom = 'Sales representative'";

                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            RestockingRequest request = new RestockingRequest(
                                (int)reader["ProductID"],
                                reader["productName"].ToString(),
                                (int)reader["Quantity"],
                                DateOnly.FromDateTime((DateTime)reader["Date"]),
                                (string)reader["RequestFrom"]);


                            requests.Add(request);
                        }

                        reader.Close();
                        return requests;

                }
                catch (Exception ex)
                    {
                        throw new Exception("Retrieving requests failed");
                    }
                }        
        }



        /// <summary>
        /// Gets the highest person ID from the database.
        /// </summary>
        /// <returns>An integer representing the highest person ID.</returns>
        public int GetTheHighestId()
        {
            int id = 0;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                string query = $"SELECT MAX(id) as MaxId FROM Person;";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["MaxId"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Getting Id failed");
            }
            finally
            {
                connection.Close();
            }
            return id + 1;
        }



        /// <summary>
        /// Finds a person by their username (email).
        /// </summary>
        /// <param name="username">The email of the person to find.</param>
        /// <returns>A <see cref="Person"/> object if found, otherwise null.</returns>
        public Person FindPerson(string username)
        {
            int floor;
            string query = "SELECT * from Person WHERE email = @username;";
            Person person = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    int id = Convert.ToInt32(reader["id"]);
                    string email = reader["email"].ToString();
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
                    if (reader["_floor"] != DBNull.Value)
                    {
                        floor = Convert.ToInt32(reader["_floor"]);
                    }
                    else
                    {
                        floor = 1;
                    }

                    if (reader["manager_id"] == DBNull.Value)
                    {
                        person = new Person(id, email, firstName, lastName, selected_gender, startingDate, 0, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                        person.setManager(ReadPersonById(manager_id));
                        person.PhoneNumber = phoneNumber;
                    }
                    else if (reader["manager_id"] != DBNull.Value)
                    {
                        person = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                        person.PhoneNumber = phoneNumber;
                        person.setManager(ReadPersonById(manager_id));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading person failed. \nPlease try again!");
            }
            finally
            {
                connection.Close();
            }
            return person;
        }


        /// <summary>
        /// Retrieves the full name of a person by their ID.
        /// </summary>
        /// <param name="id">The ID of the person.</param>
        /// <returns>The full name of the person.</returns>
        public string FindPersonName(int id)
        {
            string name = "";
            string query = "SELECT firstName, lastName from Person " +
                "WHERE id = @id";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    name = firstName + " " + lastName;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading person failed \nPlease try again");
            }

            finally
            {
                connection.Close();
            }
            return name;
        }


        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of <see cref="Product"/> objects.</returns>
        public List<Product> TakeAllProducts()
        {
            string query = "SELECT * from Product";
            List<Product> fetchedProducts = new List<Product>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    int id = Convert.ToInt32(reader["productId"]);
                    string name = reader["name"].ToString();
                    string productCategory = reader["category"].ToString();
                    ProductCategory category = (ProductCategory)Enum.Parse(typeof(ProductCategory), productCategory);
                    int year = Convert.ToInt32(reader["year"]);
                    string description = reader["description"].ToString();
                    int quantityInStock = Convert.ToInt32(reader["quantityInStock"]);
                    double price = Convert.ToDouble(reader["price"]);
                    string barcode = reader["barcode"].ToString();
                    int maxCapacity = Convert.ToInt32(reader["maxQuantity"]);

					Product newProduct = new Product(name, year, description, category, barcode, maxCapacity, price, id, quantityInStock);
                    fetchedProducts.Add(newProduct);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading products failed \nPlease try again");
            }
            finally
            {
                connection.Close();
            }
            return fetchedProducts;
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="p">The <see cref="Product"/> object to add.</param>
        public void AddProduct(Product p)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"INSERT INTO Product (productId, name, category, year, description, quantityInStock, price, barcode) VALUES(@productId, @name, @category, @year, @description, @quantityInStock, @price, @barcode";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@productId", p.getId());
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@category", Convert.ToString(p.getCategory()));
                cmd.Parameters.AddWithValue("@year", p.Year);
                cmd.Parameters.AddWithValue("@description", p.Description);
                cmd.Parameters.AddWithValue("@quantityInStock", 0);
                cmd.Parameters.AddWithValue("@price", 0);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Adding product failed \nPlease try again");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Changes the working status of a person in the database.
        /// </summary>
        /// <param name="person">The person whose status will be updated.</param>
        public void ChangeWorkingStatus(Person person)
        {
            string query = "UPDATE Person SET stillWorking = @stillWorking WHERE id = @id;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (person.GetStillWorking)
                {
                    command.Parameters.AddWithValue("@stillWorking", 0);
                }
                if (!person.GetStillWorking)
                {
                    command.Parameters.AddWithValue("@stillWorking", 1);
                }
                command.Parameters.AddWithValue("@id", person.GetId());

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Chainging status failed due to database issues. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Sets a secret question and answer for a person.
        /// </summary>
        /// <param name="person">The person whose secret question will be set.</param>
        /// <param name="secretQuestion">The secret question.</param>
        /// <param name="secretAnswer">The secret answer.</param>
        public void SetSecretQuestion(Person person, string secretQuestion, string secretAnswer)
        {
            
            string query = "UPDATE person SET secretQuestion = @secretQuestion, secretAnswer = @secretAnswer WHERE id = @id;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", person.GetId());
                cmd.Parameters.AddWithValue("@secretQuestion", secretQuestion);
                cmd.Parameters.AddWithValue("@secretAnswer", secretAnswer);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Setting secret question failed due to database issues. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Updates the phone number for a person.
        /// </summary>
        /// <param name="person">The person whose phone number will be updated.</param>
        /// <param name="phoneNumber">The new phone number.</param>
        public void UpdateUserPhoneNumber(Person person, string phoneNumber)
        {
            string query = "Update Person set phoneNumber = @phoneNumber where id = @id";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@id", person.GetId());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Updating phone number failed due to database issues. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Updates the wage for a person.
        /// </summary>
        /// <param name="person">The person whose wage will be updated.</param>
        /// <param name="newWage">The new wage value.</param>
        public void UpdateWage(Person person, double newWage)
        {
            string query = "UPDATE Person SET Wage = @wage WHERE id = @id;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@wage", Convert.ToDecimal(newWage));

                command.Parameters.AddWithValue("@id", person.GetId());

                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new Exception("Updating wage failed due to database issues. \nPlease try again later!");

            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Checks if an email is available for registration.
        /// </summary>
        /// <param name="email">The email to check.</param>
        /// <returns>True if the email is available, otherwise false.</returns>
        public bool IsEmailAvailable(string email)
        {
            string query = "SELECT COUNT(*) AS email FROM Person WHERE email = @email;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;
                throw new Exception("Database is not working at the moment please try again later");
            }
            catch (Exception e)
            {
                throw new Exception("Database is not working at the moment please try again later");
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Updates the price of a product in the database.
        /// </summary>
        /// <param name="product">The product whose price will be updated.</param>
        public void UpdatePriceDatabase(Product product)
        {
            string query = "UPDATE Product SET price = @price WHERE productId = @productId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@price", product.getPrice());
                        command.Parameters.AddWithValue("@productId", product.getId());

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Updating price failed. \nPlease try again later!");
                }
            }
        }


        /// <summary>
        /// Removes availability dates for a person.
        /// </summary>
        /// <param name="person_id">The ID of the person whose availability will be removed.</param>
        /// <param name="selectedDates">The list of dates to remove.</param>
        public void RemoveAvailability(int person_id, List<DateTime> selectedDates)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Availabilty WHERE person_id = @person_id AND _date = @_date";

                try
                {
                    connection.Open();
                    foreach (var date in selectedDates)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@person_id", person_id);
                            command.Parameters.AddWithValue("@_date", date);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while removing availability.", ex);
                }
            }
        }


        /// <summary>
        /// Checks if a specific date exists for a person.
        /// </summary>
        /// <param name="person_id">The ID of the person.</param>
        /// <param name="selectedDate">The selected date.</param>
        /// <returns>True if the date exists, otherwise false.</returns>
        public bool IsDateExist(int person_id, DateTime selectedDate)
        {
            bool isShiftSelected = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT COUNT(*) FROM Availabilty WHERE person_id = @person_id AND _date = @_date";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@person_id", person_id);
                command.Parameters.AddWithValue("@_date", selectedDate);

                int count = (int)command.ExecuteScalar();
                isShiftSelected = count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Checking date failed.");
            }
            finally
            {
                connection.Close();
            }

            return isShiftSelected;
        }


        /// <summary>
        /// Retrieves products from the depot.
        /// </summary>
        /// <returns>A list of <see cref="Product"/> objects.</returns>
        public List<Product> TakeDepotProducts()
        {
            string query = "SELECT * from DepotProduct";
            List<Product> fetchedProducts = new List<Product>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    int id = Convert.ToInt32(reader["DepotProductId"]);
                    string name = reader["name"].ToString();
                    string productCategory = reader["category"].ToString();
                    ProductCategory category = (ProductCategory)Enum.Parse(typeof(ProductCategory), productCategory);
                    int year = Convert.ToInt32(reader["year"]);
                    string description = reader["description"].ToString();
                    int quantityInStock = Convert.ToInt32(reader["quantity"]);

                    Product newProduct = new Product(name, year, description, category, id, quantityInStock);
                    fetchedProducts.Add(newProduct);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading products failed.");

            }
            finally
            {
                connection.Close();
            }
            return fetchedProducts;
        }


        /// <summary>
        /// Gets the quantity of a depot product by its ID.
        /// </summary>
        /// <param name="productID">The ID of the product.</param>
        /// <returns>The quantity of the product.</returns>
        public int GetDepoProductQuantityByID(int productID)
        {
            int quantity = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT quantity FROM DepotProduct WHERE DepotProductId = @DepotProductId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DepotProductId", productID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        quantity = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading product id failed.");

                }
            }

            return quantity;
        }


        /// <summary>
        /// Gets the quantity of a store product by its ID.
        /// </summary>
        /// <param name="productID">The ID of the product.</param>
        /// <returns>The quantity of the product.</returns>
        public int GetStoreProductQuantityByID(int productID)
        {
            int quantity = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT quantityInStock FROM Product WHERE productId = @productId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@productId", productID);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        quantity = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading product quantity failed.");

                }
            }

            return quantity;
        }


        /// <summary>
        /// Updates the quantity of a store product.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <param name="quantityInStock">The new quantity of the product.</param>
        public void UpdateStoreProductQuantity(int productId, int quantityInStock)
        {
            string query = "UPDATE Product SET quantityInStock = @quantityInStock WHERE productId = @productId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@quantityInStock", quantityInStock);
                        command.Parameters.AddWithValue("@productId", productId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Updating product quantity failed.");

                }
            }
        }


        /// <summary>
        /// Updates the quantity of a depot product.
        /// </summary>
        /// <param name="DepotProductId">The ID of the depot product.</param>
        /// <param name="quantity">The new quantity of the product.</param>
        public void UpdateDepoProductQuantity(int DepotProductId, int quantity)
        {
            string query = "UPDATE DepotProduct SET quantity = @quantity WHERE DepotProductId = @DepotProductId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@DepotProductId", DepotProductId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading product quantity failed.");

                }
            }
        }

        /// <summary>
        /// Deletes a restocking request from the database.
        /// </summary>
        /// <param name="productID">The ID of the product.</param>
        /// <param name="Quantity">The quantity of the product.</param>
        public void DeleteRequest(int productID, int Quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM [RestockingRequests] WHERE ProductID = @ProductID AND Quantity = @Quantity";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", productID);
                    command.Parameters.AddWithValue("@Quantity", Quantity);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Deleting request failed.");

                }
            }
        }


        /// <summary>
        /// Creates a new restocking request.
        /// </summary>
        /// <param name="ProductID">The ID of the product.</param>
        /// <param name="productName">The name of the product.</param>
        /// <param name="Quantity">The quantity of the product.</param>
        /// <param name="Date">The date of the request.</param>
        /// <param name="RequestFrom">The requester.</param>
        public void CreateNewRestockRequest(int ProductID, string productName, int Quantity, DateOnly Date, string RequestFrom)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO RestockingRequests (ProductID, productName, Quantity, Date, RequestFrom) VALUES (@ProductID, @productName, @Quantity, @Date, @RequestFrom)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@Date", Date);
                cmd.Parameters.AddWithValue("@RequestFrom", RequestFrom);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Creating request failed.");

            }
            finally
            {
                connection.Close();
            }
        }



        /// <summary>
        /// Checks if a request already exists for a given product and requester.
        /// </summary>
        /// <param name="productID">The ID of the product.</param>
        /// <param name="requestFrom">The requester.</param>
        /// <returns>True if the request exists, otherwise false.</returns>
        public bool CheckRequestAlreadyExists(int productID, string requestFrom)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM RestockingRequests WHERE ProductID = @ProductID AND RequestFrom = @RequestFrom";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", productID);
                    command.Parameters.AddWithValue("@RequestFrom", requestFrom);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        exists = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Checking duplicate request failed.");
                }
            }
            return exists;
        }


        /// <summary>
        /// Gets the ID of a person by their email.
        /// </summary>
        /// <param name="email">The email of the person.</param>
        /// <returns>The ID of the person.</returns>
        public int GetPersonId(string email)
        {
            string query = "select id from Person where email = @email;";
            SqlConnection connection = new SqlConnection(connectionString);
            int id = 0;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading person id failed.");
            }
            finally
            {
                connection.Close();
            }
            return id;
        }
        

        /// <summary>
        /// Reads the details of a person by their email.
        /// </summary>
        /// <param name="givenEmail">The email of the person.</param>
        /// <returns>A <see cref="Person"/> object.</returns>
        public Person ReadPerson(string givenEmail)
        {
            string query = "select * from Person where email = @email";
            Person p = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", givenEmail);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    int id = Convert.ToInt32(reader["id"]);
                    string email = reader["email"].ToString();
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

                    p = new Person(id, email, firstName, lastName, selected_gender, startingDate, manager_id, selected_department, selected_role, wage, floor, secretQuestion, secretAnswer, stillWorking);
                    p.setManager(ReadPersonById(manager_id));
                    p.PhoneNumber = phoneNumber;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading person failed due to database issues. \nPlease try again later.");
            }
            finally
            {
                connection.Close();
            }
            return p;
        }

        /// <summary>
        /// Retrieves restocking requests from depot workers.
        /// </summary>
        /// <returns>A list of <see cref="RestockingRequest"/> objects.</returns>
        public List<RestockingRequest> GetRequestsFromDepoWorker()
        {
            List<RestockingRequest> requests = new List<RestockingRequest>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM RestockingRequests WHERE RequestFrom = 'Depot worker' ORDER BY ProductID DESC";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        RestockingRequest request = new RestockingRequest((int)reader["ProductID"],
                            reader["productName"].ToString(),
                            (int)reader["Quantity"],
                            DateOnly.FromDateTime((DateTime)reader["Date"]),
                            (string)reader["RequestFrom"]);
                        requests.Add(request);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Retrieving requests failed.");
                }
            }

            return requests;
        }

        /// <summary>
        /// Finds a product by its barcode.
        /// </summary>
        /// <param name="barcode">The barcode of the product.</param>
        /// <returns>A <see cref="Product"/> object.</returns>
        public Product FindProductByBarcode(string barcode)
        {
            Product product = null;
            string query = "SELECT * from Product " +
                "WHERE barcode = @barcode;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@barcode", barcode);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    int id = Convert.ToInt32(reader["productId"]);
                    string name = reader["name"].ToString();
                    string productCategory = reader["category"].ToString();
                    ProductCategory category = (ProductCategory)Enum.Parse(typeof(ProductCategory), productCategory);
                    int year = Convert.ToInt32(reader["year"]);
                    string description = reader["description"].ToString();
                    int quantityInStock = Convert.ToInt32(reader["quantityInStock"]);
                    double price = Convert.ToDouble(reader["price"]);
					int maxCapacity = Convert.ToInt32(reader["maxQuantity"]);

					product = new Product(name, year, description, category, barcode, maxCapacity, price, id, quantityInStock);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading barcode failed.");
            }
            finally
            {
                connection.Close();
            }
            return product;
        }


        /// <summary>
        /// Gets the maximum quantity of a depot product by its ID.
        /// </summary>
        /// <param name="productID">The ID of the product.</param>
        /// <returns>The maximum quantity of the product.</returns>
        public int GetDepoProductMaxQuantityByID(int productID)
        {
            int quantity = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT MaxQuantity FROM DepotProduct WHERE DepotProductId = @DepotProductId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DepotProductId", productID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        quantity = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading maximum quantity failed.");
                }
            }

            return quantity;
        }


        /// <summary>
        /// Gets the total number of orders.
        /// </summary>
        /// <returns>The total order count.</returns>
        public int GetOrderCount()
        {
            int orderCount = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM [Order]";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        orderCount = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading orders number failed.");

                }
            }

            return orderCount;
        }


        /// <summary>
        /// Gets the names of suppliers for a given product ID.
        /// </summary>
        /// <param name="ProductID">The ID of the product.</param>
        /// <returns>A list of supplier names.</returns>
        public List<string> GetSupplierNamesByProductID(int ProductID)
        {
            List<string> supplierNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SupplierName FROM Supplier Where ProductID = @ProductID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", ProductID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string supplierName = reader.GetString(reader.GetOrdinal("SupplierName"));
                        supplierNames.Add(supplierName);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading supplier failed.");
                }
            }
            return supplierNames;
        }


        /// <summary>
        /// Creates a new order item.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <param name="ProductID">The ID of the product.</param>
        /// <param name="quantity">The quantity of the product.</param>
        public void CreateNewOrderItem(int orderId, int ProductID, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"INSERT INTO [OrderItem] (OrderID, ProductID, Quantity)
                         VALUES (@OrderId, @ProductId, @Quantity)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@ProductId", ProductID);
                    command.Parameters.AddWithValue("@Quantity", quantity);


                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception("Creating new order item failed.");

                }
            }
        }


        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <param name="supplier">The supplier's name.</param>
        /// <param name="orderDate">The date of the order.</param>
        /// <param name="arrivalDate">The expected arrival date.</param>
        /// <param name="status">The status of the order.</param>
        public void CreateNewOrder(int orderId, string supplier, DateTime orderDate, DateTime arrivalDate, string status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"INSERT INTO [Order] (OrderId, Supplier, OrderDate, ArrivalDate, Status)
                         VALUES (@OrderId, @Supplier, @OrderDate, @ArrivalDate, @Status)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@Supplier", supplier);
                    command.Parameters.AddWithValue("@OrderDate", orderDate);
                    command.Parameters.AddWithValue("@ArrivalDate", arrivalDate);
                    command.Parameters.AddWithValue("@Status", status);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Creating new order failed.");
                }
            }
        }


        /// <summary>
        /// Retrieves all orders from the database.
        /// </summary>
        /// <returns>A list of <see cref="Order"/> objects.</returns>
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [Order]";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int orderId = reader.GetInt32(reader.GetOrdinal("OrderId"));
                        DateTime orderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate"));
                        DateTime arrivalDate = reader.GetDateTime(reader.GetOrdinal("ArrivalDate"));
                        string status = reader.GetString(reader.GetOrdinal("Status"));

                        Order order = new Order(orderId, orderDate, arrivalDate, status, getOrderItemsByOrderID(orderId));
                        orders.Add(order);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading orders failed.");
                }
            }

            return orders;
        }


        /// <summary>
        /// Retrieves the items of an order by the order ID.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>A list of <see cref="OrderItem"/> objects.</returns>
        public List<OrderItem> getOrderItemsByOrderID(int orderId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [OrderItem] WHERE OrderID = @OrderId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int productId = reader.GetInt32(reader.GetOrdinal("ProductID"));
                        int quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));

                        OrderItem orderItem = new OrderItem(GetProductByID(productId), quantity);
                        orderItems.Add(orderItem);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Retrieving items failed");
                }
            }

            return orderItems;
        }


        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <returns>A <see cref="Product"/> object.</returns>
        public Product GetProductByID(int productId)
        {
            Product product = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM DepotProduct WHERE DepotProductId = @ProductId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["DepotProductId"]);
                        string name = reader["name"].ToString();
                        string productCategory = reader["category"].ToString();
                        ProductCategory category = (ProductCategory)Enum.Parse(typeof(ProductCategory), productCategory);
                        int year = Convert.ToInt32(reader["year"]);
                        string description = reader["description"].ToString();
                        int quantityInStock = Convert.ToInt32(reader["quantity"]);


                        product = new Product(name, year, description, category, id, quantityInStock);

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading product Id failed.");
                }
            }

            return product;
        }


        /// <summary>
        /// Retrieves the name of the supplier for a specific order.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>The supplier's name.</returns>
        public string GetSupplierNameByOrderID(int orderId)
        {
            string supplierName = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Supplier FROM [Order] WHERE OrderID = @OrderId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        supplierName = Convert.ToString(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading supplier failed.");
                }
            
            }

            return supplierName;
        }


        /// <summary>
        /// Changes the status of an order.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <param name="newStatus">The new status of the order.</param>
        public void ChangeOrderStatus(int orderId, string newStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE [Order] SET Status = @NewStatus WHERE OrderId = @OrderId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewStatus", newStatus);
                command.Parameters.AddWithValue("@OrderId", orderId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Updating status failed.");
                }
            }
        }

        /// <summary>
        /// Changes the quantity of a depot product.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <param name="newQuantity">The new quantity of the product.</param>
        public void ChangeProductQuantity(int productId, int newQuantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE DepotProduct SET quantity = @NewQuantity WHERE DepotProductID = @ProductId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewQuantity", newQuantity);
                command.Parameters.AddWithValue("@ProductId", productId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                                        
                }
                catch (Exception ex)
                {
                    throw new Exception("Chanign quantity failed.");
                }
            }
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Person 
                         SET email = @Email, 
                             phoneNumber = @PhoneNumber, 
                             secretQuestion = @SecurityQuestion, 
                             secretAnswer = @SecurityAnswer 
                         WHERE id = @UserId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@SecurityQuestion", securityQuestion);
                command.Parameters.AddWithValue("@SecurityAnswer", securityAnswer);
                command.Parameters.AddWithValue("@UserId", userId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("User details updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to update user details.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Updating user details failed.");
                }
            }
        }


        /// <summary>
        /// Records the clocking-in time for an employee.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The clock-in time.</param>
        public void ClockingIn(int id,  DateTime time)
        {
			SqlConnection connection = new SqlConnection(connectionString);
			string query = "INSERT INTO Clocking (employeeID, time) VALUES (@employeeID, @time)";
			try
			{
				connection.Open();
				SqlCommand command = new SqlCommand(query, connection);
				SqlCommand cmd = new SqlCommand(query, connection);
				cmd.Parameters.AddWithValue("@employeeID", id);
				cmd.Parameters.AddWithValue("@time", time);

				cmd.ExecuteNonQuery();
			}
            catch (Exception ex)
            {
                throw new Exception("Clocking in failed.");
            }
            finally
			{
				connection.Close();
			}
		}


        /// <summary>
        /// Retrieves the total work time for a month for an employee.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="month">The month to calculate the work time for.</param>
        /// <returns>A list of <see cref="DateTime"/> objects representing work shifts.</returns>
		public List<DateTime> GetWorkTimeMonth(int id, DateTime month)
		{
			List<DateTime> results = new List<DateTime>();
			SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * from Clocking " +
                "WHERE employeeID = @employeeID "+
                "AND DATEDIFF(month, time, @time) = 0";
			try
			{
				connection.Open();
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@time", month);
				command.Parameters.AddWithValue("@employeeID", id);
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					results.Add(Convert.ToDateTime(reader["time"]));
				}
			}
            catch (Exception ex)
            {
                throw new Exception("Calculating work time failed.");
            }
            finally
			{
				connection.Close();
			}
			return results;
		}


        /// <summary>
        /// Adds availability for a person.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="date">The date of the availability.</param>
        /// <param name="shift">The shift availability for the day.</param>
        public void AddAvailability(int personId, DateTime date, AvailabilityForTheDay shift)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"INSERT INTO Availabilty (person_id, _date, availabilityForTheDay, IsTaken) VALUES (@PersonId, @Date, @Shift, {0})";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonId", personId);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@Shift", shift.ToString());

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Adding availability failed.");
                }
            }
        }

        /// <summary>
        /// Records the clocking-out time and calculates time worked for an employee.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The clock-out time.</param>
        /// <returns>The total time worked.</returns>
        public TimeSpan ClockOut(int id, DateTime time)
        {
            TimeSpan timeWorked = time - time;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT TOP 1 * from Clocking  " +
                "WHERE employeeID = @employeeID " +
                "AND DATEDIFF(day, time, @time) = 0 " +
                "ORDER BY time DESC";
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@employeeID", id);
                cmd.Parameters.AddWithValue("@time", time);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime clockInTime = Convert.ToDateTime(reader["time"]);
                    timeWorked = time - clockInTime;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Clocking out failed.");
            }
            finally
            {
                connection.Close();
            }

            return timeWorked;
        }


        /// <summary>
        /// Checks if an employee has already clocked in for a specific date.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The date to check for clock-in.</param>
        /// <returns>True if the employee has clocked in, otherwise false.</returns>
        public bool CheckIfClockedIn(int id, DateTime time)
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT COUNT(*) as count from Clocking  " +
                "WHERE employeeID = @employeeID " +
                "AND DATEDIFF(day, time, @time) = 0";
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@employeeID", id);
                cmd.Parameters.AddWithValue("@time", time);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = Convert.ToInt32(reader["count"]);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Checking clocking in failed.");
            }
            finally
            {
                connection.Close();
            }

            if (count % 2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// Checks if an employee has clocked in within the last 5 minutes.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="time">The time to check.</param>
        /// <returns>True if the employee has clocked in recently, otherwise false.</returns>
        public bool CheckIfJustClocked(int id, DateTime time)
        {
            bool result = false;
			SqlConnection connection = new SqlConnection(connectionString);
			string query = "SELECT COUNT(*) as count from Clocking  " +
				"WHERE employeeID = @employeeID " +
				"AND DATEDIFF(minute, time, @time) < 5";
			try
			{
				connection.Open();
				SqlCommand cmd = new SqlCommand(query, connection);
				cmd.Parameters.AddWithValue("@employeeID", id);
				cmd.Parameters.AddWithValue("@time", time);
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					int count = Convert.ToInt32(reader["count"]);
                    if (count > 0)
                    {
                        result = true;
                    }
				}

			}
            catch (Exception ex)
            {
                throw new Exception("Checking clock in failed.");
            }
            finally
			{
				connection.Close();
			}

            return result;
		}
    }
}
