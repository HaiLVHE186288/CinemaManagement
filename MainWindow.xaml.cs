using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CinemaManagement.Repository;
using CinemaManagement.View;
using System.Collections.ObjectModel;
using System;
using CinemaManagement.Models;

namespace CinemaManagement
{
    public partial class MainWindow : Window
    {
     
        private ShowRepository showRepository; 
		IBookingRepository bookingRepository = new BookingRepository();
		public MainWindow()
        {
            InitializeComponent();
            LoadMovies(); 
			LoadMovieListDataGrid();
			showRepository = new ShowRepository(); 

        }


		private void LoadMovieListDataGrid()
        {
            MovieListDataGrid.ItemsSource = CinemaContext.INSTANCE.Films.ToList();
        }

		private void LoadMovies()
		{
			MovieComboBox.Items.Clear();
			MovieComboBox.Items.Add(new ComboBoxItem { Content = "Chọn phim", Tag = null });

			var films = CinemaContext.INSTANCE.Films.ToList();

			foreach (var film in films)
			{
				MovieComboBox.Items.Add(new ComboBoxItem
				{
					Content = film.Title, 
					Tag = film.FilmId 
				});
			}
		}

		private void MovieComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (MovieComboBox.SelectedItem is ComboBoxItem selectedItem && selectedItem.Tag is int selectedFilmId)
			{
				LoadShowtimes(selectedFilmId); 
			}
			else
			{
				ShowtimeComboBox.Items.Clear(); 
				ShowtimeComboBox.Items.Add(new ComboBoxItem { Content = "Chọn giờ chiếu", Tag = null });
			}
		}

		private void LoadShowtimes(int filmId)
		{
			ShowtimeComboBox.Items.Clear(); 
			ShowtimeComboBox.Items.Add(new ComboBoxItem { Content = "Chọn giờ chiếu", Tag = null });

			var shows = showRepository.GetAllShows(); 
			foreach (var show in shows)
			{
				if (show.FilmId == filmId) 
				{
					ShowtimeComboBox.Items.Add(new ComboBoxItem
					{
						Content = $"{show.ShowDate} - Giá: {show.Price} VND",
						Tag = show.ShowId 
					});
				}
			}
		}

		private void ShowtimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ShowtimeComboBox.SelectedItem is ComboBoxItem selectedItem && selectedItem.Tag is int showId)
			{
				var selectedShow = showRepository.GetShowById(showId); 
				if (selectedShow != null)
				{
					LoadSeats(selectedShow); 
					SeatStatusTextBlock.Text = selectedShow.Status; 
					PriceTextBlock.Text = $"{selectedShow.Price} VND"; 
				}
			}
			else
			{
				SeatComboBox.Items.Clear(); 
				SeatStatusTextBlock.Text = ""; 
				PriceTextBlock.Text = ""; 
			}
		}


		private void LoadSeats(Show show)
        {
            // Giả sử có một danh sách ghế được lấy từ lịch chiếu
            SeatComboBox.Items.Clear(); // Xóa các ghế hiện có
            SeatComboBox.Items.Add(new ComboBoxItem { Content = "Chọn ghế", Tag = null }); // Mục mặc định

            // Thêm ghế từ show (giả định rằng show chứa danh sách ghế)
            // Cần cập nhật lại theo cách thức lấy ghế từ Show
            foreach (var seat in show.Slot.Split(',')) // Giả sử Slot chứa danh sách ghế
            {
                SeatComboBox.Items.Add(new ComboBoxItem { Content = seat.Trim(), Tag = seat.Trim() }); // Thêm ghế vào ComboBox
            }
        }

		private void BookTicketButton_Click(object sender, RoutedEventArgs e)
		{
			var customerName = CustomerNameTextBox.Text;
			var selectedMovie = (MovieComboBox.SelectedItem as ComboBoxItem)?.Tag;
			var selectedShow = (ShowtimeComboBox.SelectedItem as ComboBoxItem)?.Tag;

			
			if (string.IsNullOrEmpty(customerName))
			{
				MessageBox.Show("Vui lòng nhập tên khách hàng.");
				return;
			}

			
			if (selectedMovie == null)
			{
				MessageBox.Show("Vui lòng chọn một bộ phim.");
				return;
			}

			
			if (selectedShow == null)
			{
				MessageBox.Show("Vui lòng chọn buổi chiếu.");
				return;
			}

			
			string seatStatus = SeatStatusTextBlock.Text;
			string priceText = PriceTextBlock.Text;

			
			if (string.IsNullOrEmpty(seatStatus))
			{
				MessageBox.Show("Vui lòng nhập tình trạng ghế.");
				return;
			}		

			var booking = new Booking
			{
				CustomerName = customerName,
				ShowId = (int)selectedShow,
				SeatStatus = seatStatus,			
			};				
			bookingRepository.AddBooking(booking);

		
			MessageBox.Show("Đặt vé thành công!");
		}



		private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo một cửa sổ Login và hiển thị nó
            Login loginWindow = new Login();
            loginWindow.Show(); // Hiển thị cửa sổ login
            this.Close(); // Đóng cửa sổ MainWindow nếu cần thiết
        }
    }
}
