using System.Data.SqlClient;
using CPC2020_2_Lab3.Models;
using CPC2020_2_Lab3.Repositories.Interfaces;

namespace CPC2020_2_Lab3.Repositories
{
    /// <summary>
    /// Klasa definiująca metody związane z komunikacją z bazą danych dla tabeli Genres
    /// </summary>
    public class GenresRepository: Repository, IGenresRepository
    {
        /// <summary>
        /// Metoda zwracająca Genre z tabeli Genres
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        public Genre GetGenre(int genreId)
        {
            string getGenreQuery = "SELECT * FROM Genres WHERE Id = " + genreId;
            Genre genre = new Genre();

            Connection.Open();

            SqlCommand getGenreCommand = new SqlCommand(getGenreQuery, Connection);
            SqlDataReader reader = getGenreCommand.ExecuteReader();

            while (reader.Read())
            {
                genre.Id = int.Parse(reader["Id"].ToString());
                genre.Name = reader["Name"].ToString();
            }

            Connection.Close();

            return genre;
        }
    }
}
