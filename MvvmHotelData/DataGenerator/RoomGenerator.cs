
using MvvmHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels.Data.DataGenerator
{
    class RoomGenerator
    {
        private static Random rnd = new Random();
        internal static IEnumerable<Room> GenerateRooms(int count)
        {
            List<Room> rooms = new List<Room>();

            for (int i = 0; i < count; i++)
            {
                var newRoom = new Room
                {
                    Capacity = rnd.Next(1, 5),
                    ComfortId = rnd.Next(1, 4),
                    Price = rnd.Next(1000, 5000)
                };

                rooms.Add(newRoom);
            }

            return rooms;
        }
    }
}
