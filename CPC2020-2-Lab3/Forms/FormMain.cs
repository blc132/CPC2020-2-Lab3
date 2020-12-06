﻿using System;
using System.Data;
using System.Windows.Forms;
using CPC2020_2_Lab3.Models;
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
        /// Klasa do przetwarzania danych związanych z tabelą Authors
        /// </summary>
        private readonly AuthorsRepository authorsRepository;

        /// <summary>
        /// Klasa do przetwarzania danych związanych z tabelą Genres
        /// </summary>
        private readonly GenresRepository genersRepository;


        /// <summary>
        /// Konstruktor okna głownego aplikacji
        /// </summary>
        public FormMain()
        {
            //Zainicjalizowanie repozytoriów
            booksRepository = new BooksRepository();
            authorsRepository = new AuthorsRepository();
            genersRepository = new GenresRepository();

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
            //wyciągnięcie danych z textboxów
            string title = textBoxBookTitle.Text;
            int yearOfPublication = int.Parse(textBoxYearOfPublication.Text);
            float price = float.Parse(textBoxPrice.Text);
            string genre = textBoxGenre.Text;
            string authorFirstName = textBoxFirstName.Text;
            string authorLastName = textBoxLastName.Text;

            //dodanie do bazy nowej książki
            booksRepository.AddBook(title, yearOfPublication, price, genre, authorFirstName, authorLastName);

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
            //wyciągnięcie bookId z textboxu
            int bookId = int.Parse(textBoxId.Text);

            //usunięcie książki z bazy danych
            booksRepository.DeleteBook(bookId);

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
            //wyciągnięcie danych z textboxów
            int bookId = int.Parse(textBoxId.Text);
            string title = textBoxBookTitle.Text;
            int yearOfPublication = int.Parse(textBoxYearOfPublication.Text);
            float price = float.Parse(textBoxPrice.Text);
            string genre = textBoxGenre.Text;
            string authorFirstName = textBoxFirstName.Text;
            string authorLastName = textBoxLastName.Text;

            //aktualizacja książki
            booksRepository.UpdateBook(bookId, title, yearOfPublication, price, genre, authorFirstName, authorLastName);

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

            int authorId = int.Parse(row.Cells[4].Value.ToString());
            int genreId = int.Parse(row.Cells[5].Value.ToString());

            //pobierz autora z bazy danych na podstawie wyciągniętego authorId
            Author author = authorsRepository.GetAuthor(authorId);

            //pobierz gatunek z bazy danych na podstawie wyciągniętego genreId
            Genre genre = genersRepository.GetGenre(genreId);

            //poustawiaj dane w textboxach wybranej książki
            textBoxId.Text = id.ToString();
            textBoxBookTitle.Text = title;
            textBoxYearOfPublication.Text = yearOfPublication.ToString();
            textBoxPrice.Text = price.ToString();

            textBoxGenre.Text = genre.Name;
            textBoxFirstName.Text = author.FirstName;
            textBoxLastName.Text = author.LastName;

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