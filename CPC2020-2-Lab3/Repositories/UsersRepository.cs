using System.Data.SqlClient;
using CPC2020_2_Lab3.Repositories.Interfaces;

namespace CPC2020_2_Lab3.Repositories
{
    /// <summary>
    /// Klasa definiująca metody związane z komunikacją z bazą danych dla tabeli Users
    /// </summary>
    public class UsersRepository: Repository, IUsersRepository
    {
        /// <summary>
        /// Metoda sprawdzająca czy można się zalogować do aplikacji na podstawie login i password
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string login, string password)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Login='" + login + "' AND Password='" + password + "';";

            Connection.Open();

            SqlCommand comm = new SqlCommand(query, Connection);
            int foundUsers = (int)comm.ExecuteScalar();

            Connection.Close();

            if (foundUsers >= 1)
                return true;
            return false;
        }
    }
}
