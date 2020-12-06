using CPC2020_2_Lab3.Models;

namespace CPC2020_2_Lab3.Repositories.Interfaces
{
    /// <summary>
    /// Interfejs definujący metody związane z komunikacją z bazą danych dla tabeli Authors
    /// </summary>
    public interface IAuthorsRepository
    {
        /// <summary>
        /// Abstrakcyjna metoda do pobierania autora z tabeli Authors na podstawie authorId
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        Author GetAuthor(int authorId);
    }
}
