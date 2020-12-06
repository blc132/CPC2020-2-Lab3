namespace CPC2020_2_Lab3.Repositories.Interfaces
{
    /// <summary>
    /// Interfejs definiujący metody związane z komunikacją z bazą danych dla tabeli Users
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Abstrakcyjna metoda do logowania z tabeli Users na podstawie login i password
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Login(string login, string password);
    }
}
