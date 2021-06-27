
using MvvmHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels.Data.DataGenerator
{
    class SettlingGenerator
    {
        private static Random rnd = new Random();
        internal static IEnumerable<Settling> GenerateSettlings(List<int> clientIds, List<int> roomIds)
        {
            int minCount = clientIds.Count;
            if (roomIds.Count < minCount)
            {
                minCount = roomIds.Count;
            }
            List<Settling> settlings = new List<Settling>();
            for (int i = 0; i < minCount; i++)
            {
                var newSettling = new Settling
                {
                    ClientId = clientIds[i],
                    RoomId = roomIds[i],
                    EntryDate = DateTime.Now.AddDays(rnd.Next(-30, 30))
                };

                settlings.Add(newSettling);
            }

            foreach (var settling in settlings)
            {
                if (rnd.Next(0, 3) == 0)
                {
                    settling.ReleaseDate = settling.EntryDate.AddDays(rnd.Next(10, 30));
                }
            }

            return settlings;
        }
    }
}
