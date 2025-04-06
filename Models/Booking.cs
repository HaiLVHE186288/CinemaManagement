using System;
using System.Collections.Generic;

namespace CinemaManagement.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int ShowId { get; set; }

    public string? CustomerName { get; set; }

    public string? SeatStatus { get; set; }

    public decimal Amount { get; set; }

    public virtual Show Show { get; set; } = null!;
}
