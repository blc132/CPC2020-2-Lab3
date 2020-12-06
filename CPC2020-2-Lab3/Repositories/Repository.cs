using System.Data.SqlClient;
using CPC2020_2_Lab3.Infrastructure;

namespace CPC2020_2_Lab3.Repositories
{
    /// <summary>
    /// Klasa abstrakcyjna mająca zmienne i/lub metody, które każde repozytorium powinno zawierać
    /// </summary>
    public abstract class Repository
    {
        /// <summary>
        /// Zmienna przechowująca połączenie z bazą danych
        /// </summary>
        protected readonly SqlConnection Connection;

        protected Repository()
        {
            //Inicjalizacja połączenia z bazą danych
            Connection = new SqlConnection(Constants.ConnectionString);
        }
    }
}
