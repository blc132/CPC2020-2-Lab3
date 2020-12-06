using System;
using System.Windows.Forms;
using CPC2020_2_Lab3.Repositories;

namespace CPC2020_2_Lab3.Forms
{
    /// <summary>
    /// Okno do logowania
    /// </summary>
    public partial class FormLogin : Form
    {
        /// <summary>
        /// Klasa do przetwarzania danych związanych z tabelą Users
        /// </summary>
        private readonly UsersRepository usersRepository;

        /// <summary>
        /// Konstruktor okna do logowania
        /// </summary>
        public FormLogin()
        {
            //Zainicjalizowanie repozytorium
            usersRepository = new UsersRepository();

            InitializeComponent();

            //Ustawienie okna, żeby pojawiało się na środku ekranu
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku od logowania
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            bool logged = usersRepository.Login(login, password);

            if (logged)
            {
                Program.Logged = true;
                Close();
            }

            MessageBox.Show("Niepoprawny login lub hasło!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }
    }
}
