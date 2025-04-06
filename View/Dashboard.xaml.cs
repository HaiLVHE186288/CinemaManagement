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
using CinemaManagement;

namespace CinemaManagement.View
{
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.Opacity = 0.8; 
            }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.Opacity = 1;
            }
        }

        private void Room_Click(object sender, RoutedEventArgs e)
        {
            RoomView roomView = new RoomView();
            roomView.Show();
            this.Hide(); // Ẩn Dashboard
        }

        private void Film_Click(object sender, RoutedEventArgs e)
        {
            IFilmRepository filmRepository = new FilmRepository(); // Khởi tạo filmRepository
            FilmView filmView = new FilmView(filmRepository); // Truyền filmRepository vào constructor
            filmView.Show();
            this.Hide(); // Ẩn Dashboard
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            IShowRepository showRepository = new ShowRepository(); // Khởi tạo showRepository
            ShowView showView = new ShowView(showRepository); // Truyền showRepository vào constructor
            showView.Show();
            this.Hide(); // Ẩn Dashboard
        }

        private void Booking_Click(object sender, RoutedEventArgs e)
        {
            // Giả định bạn có các thông tin để truyền vào BookingWindow
            string customerName = "Tên khách"; // Thay thế bằng tên khách thực tế hoặc lấy từ một input
            int? selectedMovie = null; // Thay thế bằng mã phim được chọn (có thể lấy từ ComboBox)
            int? selectedShow = null; // Thay thế bằng mã lịch chiếu được chọn (có thể lấy từ ComboBox)
            string selectedSeat = "Ghế"; // Thay thế bằng ghế được chọn (có thể lấy từ ComboBox)

            IBookingRepository bookingRepository = new BookingRepository(); // Khởi tạo bookingRepository
            BookingWindow bookingView = new BookingWindow(customerName, selectedMovie, selectedShow, selectedSeat, bookingRepository); // Truyền các tham số vào constructor
            bookingView.Show();
            this.Hide(); // Ẩn Dashboard
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {

            // Open MainWindow after logging out
            var mainWindow = new MainWindow();
            mainWindow.Show();
            // Close the current dashboard window
            this.Close();
        }

    }
}

