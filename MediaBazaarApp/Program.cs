using DataAccessLayer;
using LogicLayer;
using System.Text;
using WorkTasks_Individual_Kristof_Szabo;
namespace MediaBazaarApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new loginForm());

            //PasswordManager pm = new PasswordManager();
            //PasswordSQL sql = new PasswordSQL();
            //for (int i = 629; i <= 925; i++)
            //{
            //    string password = $"password{i}";
            //    string salt = pm.GenerateRandomSalt(80);
            //    string hash = pm.GenerateSHA256Hash(password, salt);
            //    sql.AddPassword(i, salt, hash);
            //}

            //Iterate over each line and split it into id and password
            //    foreach (string line in lines)
            //{
            //    // Split the line into id and password parts
            //    string[] parts = line.Split(':');
            //    int id = int.Parse(parts[0]);
            //    string password = parts[1];
            //    string salt = pm.GenerateRandomSalt(80);
            //    string hash = pm.GenerateSHA256Hash(password, salt);
            //    sql.AddPassword(id, salt, hash);
            //    Add the id - password pair to the dictionary
            //    idPasswordDictionary.Add(id, password);
            //}
            ApplicationConfiguration.Initialize();
            Application.Run(new loginForm());

        }
    }
}