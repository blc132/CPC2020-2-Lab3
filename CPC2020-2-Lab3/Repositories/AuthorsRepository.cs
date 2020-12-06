using System.Data.SqlClient;
using CPC2020_2_Lab3.Models;
using CPC2020_2_Lab3.Repositories.Interfaces;

namespace CPC2020_2_Lab3.Repositories
{
    /// <summary>
    /// Klasa definiująca metody związane z komunikacją z bazą danych dla tabeli Authors
    /// </summary>
    public class AuthorsRepository: Repository, IAuthorsRepository
    {
        /// <summary>
        /// Metoda zwracająca Autora z tabeli Authors na podstawie authorId
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public Author GetAuthor(int authorId)
        {
            string getAuthorQuery = "SELECT * FROM Authors WHERE Id = " + authorId;
            Author author = new Author();

            Connection.Open();

            SqlCommand getAuthorCommand = new SqlCommand(getAuthorQuery, Connection);
            SqlDataReader reader = getAuthorCommand.ExecuteReader();

            while (reader.Read())
            {
                author.Id = int.Parse(reader["Id"].ToString());
                author.FirstName = reader["FirstName"].ToString();
                author.LastName = reader["LastName"].ToString();
            }

            Connection.Close();

            return author;
        }
    }
}
