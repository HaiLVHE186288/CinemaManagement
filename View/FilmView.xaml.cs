using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CinemaManagement.Repository;
using Microsoft.Win32;
using CinemaManagement.View;
using CinemaManagement.Models;

namespace CinemaManagement.View
{
    public partial class FilmView : Window
    {
        private readonly IFilmRepository filmRepository;
        private readonly Dashboard dashboard; // Reference to the Dashboard window
        
        public FilmView(IFilmRepository repository)
        {
            InitializeComponent();
            filmRepository = repository;
            LoadFilmList();
            dashboard = new Dashboard(); // Initialize Dashboard
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            dashboard.Show(); // Show Dashboard
            this.Close(); // Close FilmView
        }

        private void LoadFilmList()
        {
            try
            {
                FilmDataGrid.ItemsSource = filmRepository.GetAllFilms().ToList(); // Tải danh sách phim
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading films");
            }
        }


        private void AddFilmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Film film = new Film
                {
                    Title = TitleTextBox.Text,
                    Year = int.Parse(YearTextBox.Text),
                    Genre = GenreTextBox.Text,
                    Country = CountryTextBox.Text
                };
                filmRepository.AddFilm(film); // Thêm phim vào danh sách
                LoadFilmList(); // Tải lại danh sách phim để hiển thị
                ResetInputFields(); // Đặt lại các trường nhập liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void EditFilmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FilmDataGrid.SelectedItem is Film selectedFilm)
                {
                    selectedFilm.Title = TitleTextBox.Text;
                    selectedFilm.Year = int.Parse(YearTextBox.Text);
                    selectedFilm.Genre = GenreTextBox.Text;
                    selectedFilm.Country = CountryTextBox.Text;
                    filmRepository.UpdateFilm(selectedFilm);
                    LoadFilmList();
                    ResetInputFields();
                }
                else
                {
                    MessageBox.Show("Please select a film to edit.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteFilmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FilmDataGrid.SelectedItem is Film selectedFilm)
                {
                    filmRepository.DeleteFilm(selectedFilm.FilmId);
                    LoadFilmList();
                    ResetInputFields();
                }
                else
                {
                    MessageBox.Show("Please select a film to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FilmDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilmDataGrid.SelectedItem is Film selectedFilm)
            {
                TitleTextBox.Text = selectedFilm.Title;
                YearTextBox.Text = selectedFilm.Year.ToString();
                GenreTextBox.Text = selectedFilm.Genre;
                CountryTextBox.Text = selectedFilm.Country;
            }
        }

        private void ResetInputFields()
        {
            TitleTextBox.Text = string.Empty;
            YearTextBox.Text = string.Empty;
            GenreTextBox.Text = string.Empty;
            CountryTextBox.Text = string.Empty;
        }
    }
}



