using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Model
{
    public class Film
    {
        public int FilmID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }  // Thêm thuộc tính Genre
        public string Country { get; set; } // Thêm thuộc tính Country
    }
}


