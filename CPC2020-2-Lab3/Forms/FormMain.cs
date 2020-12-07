using System;
using System.Data;
using System.Windows.Forms;
using CPC2020_2_Lab3.Repositories;

namespace CPC2020_2_Lab3.Forms
{
    /// <summary>
    /// Klasa okna głównego aplikacji
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Klasa do przetwarzania danych związanych z tabelą Books
        /// </summary>
        private readonly BooksRepository booksRepository;


        /// <summary>
        /// Konstruktor okna głownego aplikacji
        /// </summary>
        public FormMain()
        {
            //Zainicjalizowanie repozytoriów
            booksRepository = new BooksRepository();
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
            //Jeśli żadnen wiersz nie jest zaznaczony lub jest zaznaczonych więcej niż jeden to nic nie rób (return)
            int rowsCount = dataGridViewBooks.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1)
                return;

            //weź pierwszy zaznaczony wiersz
            DataGridViewRow row = dataGridViewBooks.SelectedRows[0];

            //wyciągnij dane z zaznaczonego wiersza
            int id = int.Parse(row.Cells[0].Value.ToString());
            string title = row.Cells[1].Value.ToString();
            int yearOfPublication = int.Parse(row.Cells[2].Value.ToString());
            float price = float.Parse(row.Cells[3].Value.ToString());
            string firstName = row.Cells[6].Value.ToString();
            string lastName = row.Cells[7].Value.ToString();
            string genre = row.Cells[8].Value.ToString();

            //poustawiaj dane w textboxach wybranej książki
            textBoxId.Text = id.ToString();
            textBoxBookTitle.Text = title;
            textBoxYearOfPublication.Text = yearOfPublication.ToString();
            textBoxPrice.Text = price.ToString();

            textBoxGenre.Text = genre;
            textBoxFirstName.Text = firstName;
            textBoxLastName.Text = lastName;

            labelLastAction.Text = "Wybrano książkę";
        }

        /// <summary>
        /// Metoda dostosowująca DataGridViewBooks - ustawianie widoczności kolumn i ich nazw
        /// </summary>
        private void CustomizeDataGridViewBooks()
        {
            //ustaw widoczność kolumn AuthorId i GenreId na niewidoczne
            dataGridViewBooks.Columns["AuthorId"].Visible = false;
            dataGridViewBooks.Columns["GenreId"].Visible = false;

            //ustaw nazwy kolumn na polskie
            dataGridViewBooks.Columns["Title"].HeaderText = "Tytuł";
            dataGridViewBooks.Columns["YearOfPublish"].HeaderText = "Data publikacji";
            dataGridViewBooks.Columns["Price"].HeaderText = "Cena";
            dataGridViewBooks.Columns["FirstName"].HeaderText = "Imię";
            dataGridViewBooks.Columns["LastName"].HeaderText = "Nazwisko";
            dataGridViewBooks.Columns["Name"].HeaderText = "Gatuenk";
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
            //pobierz wszystkie książki z bazy danych
            DataTable books = booksRepository.GetBooks();

            //przypisz wszystkie książki do DataGridViewBooks
            dataGridViewBooks.DataSource = books;
        }
    }
}
