using MvvmHotel.Data.Repositories;
using MvvmHotel.Interfaces;
using MvvmHotel.Models;
using MvvmHotel.View;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmHotel.ViewModel
{
    public class SettlingViewModel : BindableBase
    {
        private IClientRepository clientRepository;
        private IRoomRepository roomRepository;
        private ISettlingRepository settlingRepository;
        public RelayCommand SaveSettling { get; set; }
        public Settling Settling { get; set; }
        public SettlingViewModel()
        {
            Settling = new Settling();
            this.clientRepository = new ClientRepository();
            this.roomRepository = new RoomRepository();
            this.settlingRepository = new SettlingRepository();
            CreateSaveCommand();
        }
        public SettlingViewModel(Settling settling)
        {
            Settling = settling;
            this.clientRepository = new ClientRepository();
            this.roomRepository = new RoomRepository();
            this.settlingRepository = new SettlingRepository();
            CreateSaveCommand();
        }
        public SettlingViewModel(IClientRepository clientRepository, IRoomRepository roomRepository, ISettlingRepository settlingRepository)
        {
            Settling = new Settling();
            this.clientRepository = clientRepository;
            this.roomRepository = roomRepository;
            this.settlingRepository = settlingRepository;
            CreateSaveCommand();
        }
        public SettlingViewModel(Settling settling, IClientRepository clientRepository, IRoomRepository roomRepository, ISettlingRepository settlingRepository)
        {
            Settling = settling;
            this.clientRepository = clientRepository;
            this.roomRepository = roomRepository;
            this.settlingRepository = settlingRepository;
            CreateSaveCommand();
        }
        private void CreateSaveCommand()
        {
            SaveSettling = new RelayCommand(
                async c =>
                {
                    try
                    {
                        await Save();
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Дождитесь выполнения операции!");
                    }
                }
                );
        }
        public ObservableCollection<string> AllClients
        {
            get
            {
                var list = clientRepository.GetAll();
                return new ObservableCollection<string>(list.Select(c => $"{c.Name} {c.Surname}"));
            }
        }
        public ObservableCollection<int> AllRooms
        {
            get
            {
                var list = roomRepository.GetAll();
                return new ObservableCollection<int>(list.Select(c => c.Number));
            }
        }
        public async Task Save()
        {
            if (IsValid)
            {
                if (settlingRepository.Contains(Settling))
                {
                    await settlingRepository.Update(Settling);
                }
                else
                {
                    CheckSettlingData();

                    await settlingRepository.Create(Settling);
                }
            }
        }

        private void CheckSettlingData()
        {
            var list = settlingRepository.GetAll();
            var dbSettling = list.FirstOrDefault(
                c => c.ClientId == Settling.ClientId
                && c.ReleaseDate == null
                );

            if (dbSettling != null)
            {
                throw new InvalidOperationException($"Клиент " +
                    $"{clientRepository.GetAll().FirstOrDefault(c => c.Id == Settling.ClientId).Name} " +
                    $"{clientRepository.GetAll().FirstOrDefault(c => c.Id == Settling.ClientId).Surname}" +
                    $" на дату {Settling.EntryDate} уже заселен в комнату №{dbSettling.Room.Number}");
            }

            dbSettling = list.FirstOrDefault(
                c => c.RoomId == Settling.RoomId
                && c.EntryDate < Settling.EntryDate
                && c.ReleaseDate == null);
            if (dbSettling != null)
            {
                throw new InvalidOperationException($"Комната №{Settling.RoomId} еще не осободилась на дату {Settling.EntryDate}");
            }
        }

        public string ClientNameAndSurname
        {
            get
            {
                var client = clientRepository.GetAll().FirstOrDefault(c => c.Id == Settling.ClientId);
                if (client == null)
                {
                    return "";
                }

                return $"{client.Name} {client.Surname}";
            }
            set
            {
                var list = clientRepository.GetAll();
                if (string.IsNullOrEmpty(value) || value.Split(' ').Length != 2)
                {
                    Settling.ClientId = 0;
                }
                else
                {
                    var names = value.Split(' ');
                    var name = names[0];
                    var surname = names[1];
                    var x = list.FirstOrDefault(c => c.Name == name
                    && c.Surname == surname);
                    Settling.ClientId = list.FirstOrDefault(c => c.Name == name
                    && c.Surname == surname)?.Id ?? 0;
                }

                RaisePropertyChanged(nameof(IsValid));
            }
        }
        public int RoomNumber
        {
            get
            {
                return roomRepository.GetAll().FirstOrDefault(c => c.Id == Settling.RoomId)?.Number ?? 0;
            }
            set
            {
                var list = roomRepository.GetAll();
                Settling.RoomId = list.FirstOrDefault(c => c.Number == value)?.Id ?? 0;

                RaisePropertyChanged(nameof(IsValid));
            }
        }
        public DateTime EntryDate
        {
            get
            {
                return Settling.EntryDate;
            }
            set
            {
                Settling.EntryDate = value;
                RaisePropertyChanged(nameof(IsValid));
            }
        }
        public DateTime? ReleaseDate
        {
            get
            {
                return Settling.ReleaseDate ?? null;
            }
            set
            {
                Settling.ReleaseDate = value;
                RaisePropertyChanged(nameof(IsValid));
            }
        }
        public bool IsValid
        {
            get
            {
                return Settling.IsValid;
            }
        }
        public virtual bool IsOpenSettling
        {
            get
            {
                return Settling.IsOpenSettling;
            }
        }
    }
}
