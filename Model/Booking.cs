using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Model
{
    public class Booking
    {
        public int BookingID { get; set; }       // Booking ID
        public int ShowID { get; set; }           // Show ID
        public string? CustomerName { get; set; } // Customer Name
        public string? SeatStatus { get; set; }   // Seat Status
        public decimal Amount { get; set; }       // Amount
    }
}
