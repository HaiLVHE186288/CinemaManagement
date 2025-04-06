using System;
using System.Collections.Generic;

namespace CinemaManagement.Models;

public partial class Film
{
    public int FilmId { get; set; }

    public string Title { get; set; } = null!;

    public int Year { get; set; }

    public string Genre { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
