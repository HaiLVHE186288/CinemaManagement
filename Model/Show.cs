using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Model
{
    public class Show
    {
        public int ShowID { get; set; }
        public int RoomID { get; set; }
        public int FilmID { get; set; }
        public DateTime ShowDate { get; set; }
        public decimal Price { get; set; }
        public required string Status { get; set; }
        public required string Slot { get; set; }
    }
}

