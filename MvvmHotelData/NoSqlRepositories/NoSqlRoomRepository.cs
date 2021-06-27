
using HotelModels.Data.DataGenerator;
using MvvmHotel.Interfaces;
using MvvmHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmHotel.Data.NoSqlRepositories
{
    public class NoSqlRoomRepository : IRoomRepository
    {
        private readonly List<Room> Rooms = RoomGenerator.GenerateRooms(100).ToList();
        public NoSqlRoomRepository()
        {
            foreach (var room in Rooms)
            {
                room.Id = Rooms.IndexOf(room) + 1;
                room.Number = room.Id;
            }
        }
        public bool Contains(Room model)
        {
            return Rooms.Contains(model);
        }

        public async Task<int> Create(Room model)
        {
            await Task.Run(() => Rooms.Add(model));

            return model.Id;
        }

        public async Task Delete(Room model)
        {
            Room room = await Task.Run(() => Rooms.FirstOrDefault(c => c.Id == model.Id
             && c.IsDeleted == false));

            if (room != null)
            {
                room.IsDeleted = true;
            }
        }

        public IEnumerable<Room> GetAll()
        {
            return Rooms
               .Where(c => c.IsDeleted == false);
        }

        public async Task<Room> Read(int id)
        {
            var room = await Task.Run(() => Rooms.Where(c => c.IsDeleted == false)
              .FirstOrDefault(c => c.Id == id));

            return room;
        }

        public async Task Update(Room model)
        {
            Room room = await Task.Run(() => Rooms
          .Where(c => c.IsDeleted == false)
          .FirstOrDefault(c => c.Id == model.Id));

            if (room != null)
            {
                room.Number = model.Number;
                room.Price = model.Price;
                room.Capacity = model.Capacity;
                room.ComfortId = model.ComfortId;
            }
        }
    }
}
