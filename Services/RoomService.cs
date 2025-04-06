using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaManagement.Models;
using CinemaManagement.Repository;

namespace CinemaManagement.Services
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAllRooms() => _roomRepository.GetAllRooms();

        public void AddRoom(Room room) => _roomRepository.AddRoom(room);

        public void UpdateRoom(Room room) => _roomRepository.UpdateRoom(room);

        public void DeleteRoom(int id) => _roomRepository.DeleteRoom(id);
    }
}

