using System;
using System.Data;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metoda usuwająca książkę z tabeli Books na podstawie bookId
        /// </summary>
        /// <param name="bookId"></param>
        public void DeleteBook(int bookId)
        {
            throw new NotImplementedException();
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
