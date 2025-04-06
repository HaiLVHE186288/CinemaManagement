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
 

namespace CinemaManagement.View
{
    public partial class RoomView : Window
    {
        private readonly IRoomRepository _roomRepository;
        private readonly Dashboard dashboard; // Reference to the Dashboard window
        public RoomView()
        {
            InitializeComponent();
            _roomRepository = new RoomRepository(); // Khởi tạo RoomRepository
            _roomRepository.LoadStaticRooms();
            RoomDataGrid.ItemsSource = _roomRepository.GetAllRooms();
            dashboard = new Dashboard(); // Initialize Dashboard
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            dashboard.Show(); // Show Dashboard
            this.Close(); // Close RoomView
        }
    }
}




