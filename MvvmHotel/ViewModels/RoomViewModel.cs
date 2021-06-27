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
    public class RoomViewModel : BindableBase
    {
        public Room Room { get; set; }
        private readonly IComfortRepository comfortRepository;
        private readonly IRoomRepository roomRepository;
        public RelayCommand SaveRoom { get; set; }
        public RelayCommand DeleteRoom { get; set; }
        public ObservableCollection<string> Comforts
        {
            get
            {
                var list = comfortRepository.GetAll();
                return new ObservableCollection<string>(list.Select(c => c.Name));
            }
        }
        public RoomViewModel()
        {
            this.Room = new Room();
            this.roomRepository = new RoomRepository();
            this.comfortRepository = new ComfortRepository();
            CreateSaveCommand();
        }
        public RoomViewModel(IRoomRepository roomRepository, IComfortRepository comfortRepository)
        {
            this.Room = new Room();
            this.roomRepository = roomRepository;
            this.comfortRepository = comfortRepository;
            CreateSaveCommand();
        }
        public RoomViewModel(Room room, IRoomRepository roomRepository, IComfortRepository comfortRepository)
        {
            this.Room = room;
            this.roomRepository = roomRepository;
            this.comfortRepository = comfortRepository;
            CreateSaveCommand();
        }
        private void CreateSaveCommand()
        {
            SaveRoom = new RelayCommand(
                async c =>
                {
                    try
                    {
                        await Save();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Дождитесь выполнения операции!");
                    }
                });

            DeleteRoom = new RelayCommand(
               async c =>
               {
                   try
                   {
                       await roomRepository.Delete(Room);
                   }
                   catch (Exception)
                   {
                       MessageBox.Show("Дождитесь выполнения операции!");
                   }
               });
        }
        public async Task Save()
        {
            if (IsValid)
            {
                if (roomRepository.Contains(Room))
                {
                    await roomRepository.Update(Room);
                }
                else
                {
                    await roomRepository.Create(Room);
                }
            }
        }
        public bool IsOldRoom
        {
            get
            {
                return roomRepository.Contains(Room);
            }
        }
        public bool IsValid
        {
            get
            {
                return Room.IsValid;
            }
        }
        public int Capacity
        {
            get
            {
                return Room.Capacity;
            }
            set
            {
                Room.Capacity = value;
                RaisePropertyChanged(nameof(IsValid));
                RaisePropertyChanged(nameof(IsOldRoom));
            }
        }
        public int Price
        {
            get
            {
                return Room.Price;
            }
            set
            {
                Room.Price = value;
                RaisePropertyChanged(nameof(IsValid));
                RaisePropertyChanged(nameof(IsOldRoom));
            }
        }
        public string Comfort
        {
            get
            {
                return comfortRepository.GetAll().FirstOrDefault(c => c.Id == Room.ComfortId)?.Name ?? "";
            }
            set
            {
                var list = comfortRepository.GetAll();
                Room.ComfortId = list.FirstOrDefault(c => c.Name == value)?.Id ?? 0;

                RaisePropertyChanged(nameof(IsValid));
                RaisePropertyChanged(nameof(IsOldRoom));
            }
        }
        public int Number
        {
            get
            {
                return Room.Number;
            }
        }
    }
}
