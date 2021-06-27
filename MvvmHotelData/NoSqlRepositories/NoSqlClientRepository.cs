using HotelModels.Data.DataGenerator;
using MvvmHotel.Interfaces;
using MvvmHotel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvvmHotel.Data.NoSqlRepositories
{
    public class NoSqlClientRepository : IClientRepository
    {
        private readonly List<Client> Clients = ClientGenerator.GenerateClients(100).ToList();

        public NoSqlClientRepository()
        {
            foreach (var client in Clients)
            {
                client.Id = Clients.IndexOf(client) + 1;
            }
        }
        public bool Contains(Client model)
        {
            return Clients.Contains(model);
        }

        public async Task<int> Create(Client model)
        {
            await Task.Run(() => Clients.Add(model));

            return model.Id;
        }

        public async Task Delete(Client model)
        {
            Client client = await Task.Run(() => Clients.FirstOrDefault(c => c.Id == model.Id
             && c.IsDeleted == false));

            if (client != null)
            {
                client.IsDeleted = true;
            }
        }

        public IEnumerable<Client> GetAll()
        {
            return Clients
               .Where(c => c.IsDeleted == false);
        }

        public async Task<Client> Read(int id)
        {
            var client = await Task.Run(() => Clients.Where(c => c.IsDeleted == false)
               .FirstOrDefault(c => c.Id == id));

            return client;
        }

        public async Task Update(Client model)
        {
            Client client = await Task.Run(() => Clients
            .Where(c => c.IsDeleted == false)
            .FirstOrDefault(c => c.Id == model.Id));

            if (client != null)
            {
                client.Name = model.Name;
                client.PhoneNumber = model.PhoneNumber;
            }
        }
    }
}
