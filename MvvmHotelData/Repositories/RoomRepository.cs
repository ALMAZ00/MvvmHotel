using Microsoft.EntityFrameworkCore;
using MvvmHotel.Interfaces;
using MvvmHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmHotel.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext hotelContext;
        public RoomRepository()
        {
            hotelContext = new HotelContext();
        }

        public bool Contains(Room model)
        {
            return hotelContext.Rooms
                .FirstOrDefault(c => c.Number == model.Number && c.IsDeleted == false) != null;
        }

        public async Task<int> Create(Room model)
        {
            Room room = new Room()
            {
                Capacity = model.Capacity,
                ComfortId = model.ComfortId,
                Price = model.Price
            };

            await hotelContext.AddAsync(room);
            await hotelContext.SaveChangesAsync();

            room.Number = room.Id;
            await hotelContext.SaveChangesAsync();

            return model.Id;
        }
        public async Task Delete(Room model)
        {
            Room room = await hotelContext.Rooms.FirstOrDefaultAsync(c => c.Number == model.Number
            && c.IsDeleted == false);

            if (room != null)
            {
                room.IsDeleted = true;
            }

            await hotelContext.SaveChangesAsync();
        }

        public IEnumerable<Room> GetAll()
        {
            return hotelContext.Rooms
                .Where(c => c.IsDeleted == false);
        }

        public async Task<Room> Read(int id)
        {
            var room = await hotelContext.Rooms
                .Where(c => c.IsDeleted == false)
                .FirstOrDefaultAsync(c => c.Id == id);

            return room;
        }

        public async Task Update(Room model)
        {
            var room = await hotelContext.Rooms.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (room != null)
            {
                room.IsDeleted = model.IsDeleted;
                room.Capacity = model.Capacity;
                room.ComfortId = model.ComfortId;
                room.Number = model.Number;
                room.Price = model.Price;

                hotelContext.Rooms.Update(room);

                await hotelContext.SaveChangesAsync();
            }
        }
    }
}
