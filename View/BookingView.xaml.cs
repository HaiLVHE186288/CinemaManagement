using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CinemaManagement.Models;
using CinemaManagement.Repository;

namespace CinemaManagement.View
{
	public partial class BookingWindow : Window
	{
		private readonly IBookingRepository bookingRepository;
		private ShowRepository showRepository;
		private Dashboard dashboard;

		public BookingWindow(string customerName, int? selectedMovie, int? selectedShow, string selectedSeat, IBookingRepository bookingRepository)
		{
			InitializeComponent();
			this.bookingRepository = bookingRepository;
			LoadBookings();
			LoadMovies();
			showRepository = new ShowRepository();
			dashboard = new Dashboard();
		
		}

		private void LoadBookings()
		{
			var bookingDetails = from booking in bookingRepository.GetAllBookings()
								 join show in CinemaContext.INSTANCE.Shows
									 on booking.ShowId equals show.ShowId
								 join film in CinemaContext.INSTANCE.Films
									 on show.FilmId equals film.FilmId
								 select new 
								 {
									 BookingId = booking.BookingId,
									 CustomerName = booking.CustomerName,
									 SeatStatus = booking.SeatStatus,
									 Amount = show.Price,
									 MovieName = film.Title,
									 ShowTime = show.ShowDate
								 };

			var bookings = bookingDetails.ToList();
			BookingDataGrid.ItemsSource = bookings;
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
			dashboard.Show();
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
					SeatStatusTextBlock.Text = selectedShow.Status;
					PriceTextBlock.Text = $"{selectedShow.Price} VND";
				}
			}
			else
			{
			
				SeatStatusTextBlock.Text = "";
				PriceTextBlock.Text = "";
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
			LoadBookings();

			MessageBox.Show("Đặt vé thành công!");
		}



	}

}
