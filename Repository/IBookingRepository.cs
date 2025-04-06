using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaManagement.Models;

namespace CinemaManagement.Repository
{
    public interface IBookingRepository
    {
		IEnumerable<Booking> GetAllBookings();
		Booking GetBookingById(int bookingId);
		void AddBooking(Booking booking);

		void UpdateBooking(Booking booking);
	}
}




