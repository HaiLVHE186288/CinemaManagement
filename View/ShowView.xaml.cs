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
using System;
using System.Linq;
 
using CinemaManagement.Repository;
using System;
using System.Linq;
using CinemaManagement.Models;

namespace CinemaManagement.View
{
    public partial class ShowView : Window
    {
        private readonly IShowRepository showRepository;
        private Dashboard dashboard; // Thêm biến để giữ thể hiện của Dashboard
        public ShowView(IShowRepository repository)
        {
            InitializeComponent();
            showRepository = repository;
            LoadShows();
            dashboard = new Dashboard(); // Khởi tạo Dashboard
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Đóng cửa sổ BookingWindow
            dashboard.Show(); // Hiển thị lại Dashboard
        }

        private void LoadShows()
        {
            try
            {
                ShowDataGrid.ItemsSource = showRepository.GetAllShows().ToList(); // Tải danh sách lịch chiếu
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading shows");
            }
        }

        private void AddShowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Show show = new Show
                {
                    RoomId = int.Parse(RoomIDTextBox.Text),
                    FilmId = int.Parse(FilmIDTextBox.Text),
                    ShowDate = ShowDatePicker.SelectedDate.Value,
                    Price = decimal.Parse(PriceTextBox.Text),
                    Status = StatusTextBox.Text,
                    Slot = "Your default slot" // Thay thế với logic phù hợp nếu cần
                };
                showRepository.AddShow(show); // Thêm buổi chiếu vào danh sách
                LoadShows(); // Tải lại danh sách lịch chiếu
                ResetInputFields(); // Đặt lại các trường nhập liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditShowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ShowDataGrid.SelectedItem is Show selectedShow)
                {
                    selectedShow.RoomId = int.Parse(RoomIDTextBox.Text);
                    selectedShow.FilmId = int.Parse(FilmIDTextBox.Text);
                    selectedShow.ShowDate = ShowDatePicker.SelectedDate.Value;
                    selectedShow.Price = decimal.Parse(PriceTextBox.Text);
                    selectedShow.Status = StatusTextBox.Text;

                    showRepository.UpdateShow(selectedShow);
                    LoadShows();
                    ResetInputFields();
                }
                else
                {
                    MessageBox.Show("Please select a show to edit.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteShowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ShowDataGrid.SelectedItem is Show selectedShow)
                {
                    showRepository.DeleteShow(selectedShow.ShowId);
                    LoadShows();
                    ResetInputFields();
                }
                else
                {
                    MessageBox.Show("Please select a show to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShowDataGrid.SelectedItem is Show selectedShow)
            {
                RoomIDTextBox.Text = selectedShow.RoomId.ToString();
                FilmIDTextBox.Text = selectedShow.FilmId.ToString();
                ShowDatePicker.SelectedDate = selectedShow.ShowDate;
                PriceTextBox.Text = selectedShow.Price.ToString();
                StatusTextBox.Text = selectedShow.Status;
            }
        }

        private void ResetInputFields()
        {
            RoomIDTextBox.Text = string.Empty;
            FilmIDTextBox.Text = string.Empty;
            ShowDatePicker.SelectedDate = null;
            PriceTextBox.Text = string.Empty;
            StatusTextBox.Text = string.Empty;
        }
    }
}


