using System;
using System.Windows.Forms;

namespace CPC2020_2_Lab3.Forms
{
    /// <summary>
    /// Klasa okna głównego aplikacji
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Konstruktor okna głownego aplikacji
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            //Ustawienie okna, żeby pojawiało się na środku ekranu
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Aktualizacja danych w DataGridViewBooks przy ładowaniu okna
            RefreshDataGridViewBooks();

            //Dostosowanie tabeli DataGridViewBooks przy ładowaniu okna
            CustomizeDataGridViewBooks();
        }

        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku do dodawania nowej książki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            RefreshDataGridViewBooks();
            ClearTextBoxes();
            labelLastAction.Text = "Dodano książkę";
        }

        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku do usuwania książki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            RefreshDataGridViewBooks();
            ClearTextBoxes();
            labelLastAction.Text = "Usunięto książkę";
        }


        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku od edycji książki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditBook_Click(object sender, EventArgs e)
        {
            RefreshDataGridViewBooks();
            ClearTextBoxes();
            labelLastAction.Text = "Edytowano książkę";
        }

        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku od czyszczenia TextBoxów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearTextBoxes_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            labelLastAction.Text = "Wyczyszczono pola";
        }

        /// <summary>
        /// Metoda wykonywana za każdym razem gdy użytkownik zmieni zaznaczenie wiersza w DataGridViewBook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            labelLastAction.Text = "Wybrano książkę";
        }

        /// <summary>
        /// Metoda dostosowująca DataGridViewBooks - ustawianie widoczności kolumn i ich nazw
        /// </summary>
        private void CustomizeDataGridViewBooks()
        {
        }

        /// <summary>
        /// Metoda czyszcząca wszystkie TextBoxy w oknie głównym
        /// </summary>
        private void ClearTextBoxes()
        {
            textBoxId.Text = "";
            textBoxBookTitle.Text = "";
            textBoxYearOfPublication.Text = "";
            textBoxPrice.Text = "";
            textBoxGenre.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
        }

        /// <summary>
        /// Metoda odświeżająca dane w DataGridViewBooks
        /// </summary>
        private void RefreshDataGridViewBooks()
        {
        }
    }
}
