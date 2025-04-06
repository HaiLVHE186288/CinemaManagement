using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Model
{
    public class Room
    {
        public int RoomID { get; set; }
        public required string Name { get; set; }
        public int NumberRows { get; set; }
        public int NumberCols { get; set; }
    }
}

