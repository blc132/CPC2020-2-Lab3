using CPC2020_2_Lab3.Models;

namespace CPC2020_2_Lab3.Repositories.Interfaces
{
    /// <summary>
    /// Interfejs definiujący metody związane z komunikacją z bazą danych dla tabeli Genres
    /// </summary>
    public interface IGenresRepository
    {
        /// <summary>
        /// Abstrakcyjna metoda do pobierania gatunku książki z tabeli Genres na podstawie genreId
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        Genre GetGenre(int genreId);
    }
}
