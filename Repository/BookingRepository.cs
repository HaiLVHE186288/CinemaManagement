using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaManagement.Models;
using System.Windows;
using System.Windows.Controls;
using CinemaManagement.Repository;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Repository
{
	public class BookingRepository : IBookingRepository
	{
		private readonly List<Booking> bookings = CinemaContext.INSTANCE.Bookings.ToList(); // Temporary booking list

		public IEnumerable<Booking> GetAllBookings()
		{
			// Return all bookings
			return CinemaContext.INSTANCE.Bookings.ToList();
		}

		public Booking GetBookingById(int bookingId)
		{
			// Find and return booking by ID
			return bookings.FirstOrDefault(b => b.BookingId == bookingId);
		}

		public void AddBooking(Booking booking)
		{

			if (booking == null)
			{
				throw new ArgumentNullException(nameof(booking), "Booking cannot be null.");
			}

			try
			{

				CinemaContext.INSTANCE.Bookings.Add(booking);
				CinemaContext.INSTANCE.SaveChanges();
			}
			catch (Exception ex)
			{

				Console.WriteLine($"Error adding booking: {ex.Message}");
				throw;
			}
		}

		public void UpdateBooking(Booking booking)
		{
			var existingBooking = CinemaContext.INSTANCE.Bookings
									.FirstOrDefault(b => b.BookingId == booking.BookingId);
			if (existingBooking != null)
			{
			
				existingBooking.CustomerName = booking.CustomerName;
				existingBooking.SeatStatus = booking.SeatStatus;
				existingBooking.Amount = booking.Amount;			
				
				CinemaContext.INSTANCE.Entry(existingBooking).State = EntityState.Modified;

			
				CinemaContext.INSTANCE.SaveChanges();
			}
			else
			{
				throw new ArgumentException("Booking not found", nameof(booking)); 
			}
		}

	}
}

