using System;
using System.Windows.Forms;

namespace CPC2020_2_Lab3.Forms
{
    /// <summary>
    /// Okno do logowania
    /// </summary>
    public partial class FormLogin : Form
    {
        /// <summary>
        /// Konstruktor okna do logowania
        /// </summary>
        public FormLogin()
        {
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
        }
    }
}
