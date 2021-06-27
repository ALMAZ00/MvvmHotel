
using HotelModels.Data.DataGenerator;
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
    public class ClientRepository : IClientRepository
    {
        private readonly HotelContext hotelContext;
        public ClientRepository()
        {
            hotelContext = new HotelContext();
        }

        public bool Contains(Client model)
        {
            return hotelContext.Clients.FirstOrDefault(c => c.Id == model.Id && c.IsDeleted == false) != null;
        }

        public async Task<int> Create(Client model)
        {
            model.PhoneNumber = model.PhoneNumber.Substring(0, 11);
            model.PassportData = model.PassportData.Substring(0, 10);
            await hotelContext.Clients.AddAsync(model);

            await hotelContext.SaveChangesAsync();

            return model.Id;
        }
        public async Task Delete(Client model)
        {
            Client client = await hotelContext.Clients.FirstOrDefaultAsync(c => c.Id == model.Id
             && c.IsDeleted == false);

            if (client != null)
            {
                client.IsDeleted = true;
            }

            await hotelContext.SaveChangesAsync();
        }

        public IEnumerable<Client> GetAll()
        {
            return hotelContext.Clients
                .Where(c => c.IsDeleted == false);
        }

        public async Task<Client> Read(int id)
        {
            var client = await hotelContext.Clients.Where(c => c.IsDeleted == false)
                .FirstOrDefaultAsync(c => c.Id == id);

            return client;
        }

        public async Task Update(Client model)
        {
            Client client = await hotelContext.Clients
            .Where(c => c.IsDeleted == false)
            .FirstOrDefaultAsync(c => c.Id == model.Id);

            if (client != null)
            {
                client.Name = model.Name;
                client.Surname = model.Surname;
                client.PhoneNumber = model.PhoneNumber;

                hotelContext.Clients.Update(client);

                await hotelContext.SaveChangesAsync();
            }
        }
    }
}
