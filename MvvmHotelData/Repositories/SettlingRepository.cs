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
    public class SettlingRepository : ISettlingRepository
    {
        private readonly HotelContext hotelContext;
        public SettlingRepository()
        {
            hotelContext = new HotelContext();
        }

        public bool Contains(Settling model)
        {
            var dbSettling = hotelContext.Settlings.FirstOrDefault(c => c.Id == model.Id
            && c.IsDeleted == false);

            return dbSettling != null;
        }

        public async Task<int> Create(Settling model)
        {
            Settling dbSettling = new Settling
            {
                ClientId = model.ClientId,
                RoomId = model.RoomId,
                EntryDate = model.EntryDate
            };

            await hotelContext.AddAsync(dbSettling);

            await hotelContext.SaveChangesAsync();

            return dbSettling.ClientId;
        }
        public async Task Delete(Settling model)
        {
            var dbSettling = await hotelContext.Settlings.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (dbSettling != null)
            {
                dbSettling.IsDeleted = true;
                hotelContext.Update(dbSettling);
                await hotelContext.SaveChangesAsync();
            }
        }

        public IEnumerable<Settling> GetAll()
        {
            return hotelContext.Settlings
                .Where(c => c.IsDeleted == false);
        }

        public async Task Update(Settling model)
        {
            var dbSettling = await hotelContext.Settlings.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (dbSettling != null)
            {
                dbSettling.ReleaseDate = model.ReleaseDate;

                hotelContext.Update(dbSettling);

                await hotelContext.SaveChangesAsync();
            }
        }
    }
}
