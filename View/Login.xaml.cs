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
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_account.Text;
            string password = txt_password.Text;

            // Kiểm tra tính hợp lệ của người dùng
            if (UserRepository.ValidateUser(username, password))
            {
                // Nếu hợp lệ, mở Dashboard
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Close(); // Đóng cửa sổ đăng nhập
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); // Đóng cửa sổ Login
        }

    }
}

