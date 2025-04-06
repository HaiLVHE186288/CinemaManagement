using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly List<Room> rooms = CinemaContext.INSTANCE.Rooms.ToList();

        public IEnumerable<Room> GetAllRooms() => CinemaContext.INSTANCE.Rooms.ToList();

        public Room GetRoomById(int id) => rooms.FirstOrDefault(r => r.RoomId == id);

        public void AddRoom(Room room)
        {
            CinemaContext.INSTANCE.Rooms.Add(room);
            CinemaContext.INSTANCE.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            var existingRoom = GetRoomById(room.RoomId);
            if (existingRoom != null)
            {
                existingRoom.Name = room.Name;
                existingRoom.NumberRows = room.NumberRows;
                existingRoom.NumberCols = room.NumberCols;
                if (CinemaContext.INSTANCE.Entry(existingRoom).State != EntityState.Modified)
                {
                    CinemaContext.INSTANCE.Entry(existingRoom).State = EntityState.Modified;
                }
                CinemaContext.INSTANCE.SaveChanges();
            }
        }

        public void DeleteRoom(int id)
        {

            CinemaContext.INSTANCE.Rooms.Remove(GetRoomById(id));
            CinemaContext.INSTANCE.SaveChanges();
        }

        public void LoadStaticRooms() // Triển khai phương thức này
        {
            //rooms = CinemaContext.INSTANCE.Rooms.ToList();
            //rooms = CinemaContext.INSTANCE.Rooms.ToList();
            //// Thêm dữ liệu tĩnh vào danh sách rooms
            //rooms.Add(new Room { RoomID = 1, Name = "Phòng A", NumberRows = 10, NumberCols = 10 });
            //rooms.Add(new Room { RoomID = 2, Name = "Phòng B", NumberRows = 8, NumberCols = 8 });
            //rooms.Add(new Room { RoomID = 3, Name = "Phòng C", NumberRows = 12, NumberCols = 12 });
            //// Thêm dữ liệu phòng khác nếu cần
        }
    }
}


