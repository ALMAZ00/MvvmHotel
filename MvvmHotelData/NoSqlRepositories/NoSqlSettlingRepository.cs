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
    public class NoSqlSettlingRepository : ISettlingRepository
    {
        private readonly List<Client> Clients = ClientGenerator.GenerateClients(100).ToList();
        private readonly List<Room> Rooms = RoomGenerator.GenerateRooms(100).ToList();
        private readonly List<Settling> Settlings;

        public NoSqlSettlingRepository()
        {
            foreach (var client in Clients)
            {
                client.Id = Clients.IndexOf(client) + 1;
            }
            foreach (var room in Rooms)
            {
                room.Id = Rooms.IndexOf(room) + 1;
                room.Number = room.Id;
            }

            Settlings = SettlingGenerator.GenerateSettlings(
            Clients.Select(c => c.Id).ToList(),
            Rooms.Select(c => c.Id).ToList()).ToList();

            foreach (var settling in Settlings)
            {
                settling.Id = Settlings.IndexOf(settling) + 1;
            }
        }
        public bool Contains(Settling model)
        {
            return Settlings.Contains(model);
        }

        public async Task<int> Create(Settling model)
        {
            await Task.Run(() => Settlings.Add(model));

            return model.Id;
        }

        public async Task Delete(Settling model)
        {
            Settling settling = await Task.Run(() => Settlings.FirstOrDefault(c => c.Id == model.Id
            && c.IsDeleted == false));

            if (settling != null)
            {
                settling.IsDeleted = true;
            }
        }

        public IEnumerable<Settling> GetAll()
        {
            return Settlings;
        }

        public async Task Update(Settling model)
        {
            Settling settling = await Task.Run(() => Settlings
             .Where(c => c.IsDeleted == false)
             .FirstOrDefault(c => c.Id == model.Id));

            if (settling != null)
            {
                settling.ClientId = model.ClientId;
                settling.RoomId = model.RoomId;
                settling.EntryDate = model.EntryDate;
                settling.ReleaseDate = model.ReleaseDate;
            }
        }
    }
}
