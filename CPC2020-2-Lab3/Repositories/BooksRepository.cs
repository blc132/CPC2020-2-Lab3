using System;
using System.Data;
using System.Data.SqlClient;
using CPC2020_2_Lab3.Repositories.Interfaces;

namespace CPC2020_2_Lab3.Repositories
{
    /// <summary>
    /// Klasa definiująca metody związane z komunikacją z bazą danych dla tabeli Books
    /// </summary>
    public class BooksRepository: Repository, IBooksRepository
    {
        /// <summary>
        /// Metoda zwracająca wszystkie książki z tabeli Books
        /// </summary>
        /// <returns></returns>
        public DataTable GetBooks()
        {
            string query = "SELECT Books.*, Authors.FirstName, Authors.LastName, Genres.Name FROM Books JOIN Authors ON Books.AuthorId = Authors.Id JOIN Genres ON Books.GenreId = Genres.Id; ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Metoda dodająca nową książkę do tabeli Books
        /// </summary>
        /// <param name="title"></param>
        /// <param name="yearOfPublish"></param>
        /// <param name="price"></param>
        /// <param name="genre"></param>
        /// <param name="authorFirstName"></param>
        /// <param name="authorLastName"></param>
        public void AddBook(string title, int yearOfPublish, float price, string genre, string authorFirstName, string authorLastName)
        {
            string queryGetAuthorId = "SELECT Id FROM Authors WHERE FirstName='" + authorFirstName + "' AND LastName='" + authorLastName + "';";
            string queryGetGenreId = "SELECT Id from Genres WHERE Name='" + genre + "';";

            Connection.Open();

            SqlCommand commandGetAuthorId = new SqlCommand(queryGetAuthorId, Connection);
            int authorId = (int)commandGetAuthorId.ExecuteScalar();

            SqlCommand commandGetGenreId = new SqlCommand(queryGetGenreId, Connection);
            int genreId = (int)commandGetGenreId.ExecuteScalar();


            string insertBookQuery = "INSERT INTO Books VALUES ('" + title + "'," + yearOfPublish + "," + price + "," + authorId + "," + genreId + ");";
            SqlCommand commandInsertBook = new SqlCommand(insertBookQuery, Connection);
            commandInsertBook.ExecuteNonQuery();

            Connection.Close();
        }

        /// <summary>
        /// Metoda usuwająca książkę z tabeli Books na podstawie bookId
        /// </summary>
        /// <param name="bookId"></param>
        public void DeleteBook(int bookId)
        {
            string queryDeleteBook = "DELETE FROM Books WHERE Id=" + bookId;

            Connection.Open();

            SqlCommand commandDeleteBook = new SqlCommand(queryDeleteBook, Connection);
            commandDeleteBook.ExecuteNonQuery();

            Connection.Close();
        }

        /// <summary>
        /// Metoda edytująca książkę z tabeli Books
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="yearOfPublish"></param>
        /// <param name="price"></param>
        /// <param name="genre"></param>
        /// <param name="authorFirstName"></param>
        /// <param name="authorLastName"></param>
        public void EditBook(int bookId, string title, int yearOfPublish, float price, string genre, string authorFirstName, string authorLastName)
        {
            throw new NotImplementedException();
        }
    }
}
