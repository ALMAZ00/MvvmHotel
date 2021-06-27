using MvvmHotel.Data.Repositories;
using MvvmHotel.Interfaces;
using MvvmHotel.View;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmHotel.ViewModel
{
    public class AllRoomsViewModel : BindableBase
    {
        private IRoomRepository roomRepository;
        private IComfortRepository comfortRepository;
        public RelayCommand ShowRoom { get; set; }
        public ObservableCollection<RoomViewModel> AllRooms => allRooms;
        private ObservableCollection<RoomViewModel> allRooms;
        private IEnumerable<RoomViewModel> sourceRooms;

        public AllRoomsViewModel()
        {
            roomRepository = new RoomRepository();
            comfortRepository = new ComfortRepository();
            sourceRooms = roomRepository.GetAll()
                .Select(c => new RoomViewModel(c, roomRepository, comfortRepository));
            allRooms = new ObservableCollection<RoomViewModel>(sourceRooms);

            ShowRoom = new RelayCommand(
                async c =>
                {
                    var displayRootRegistry = (Application.Current as App).displayRootRegistry;
                    RoomViewModel viewModel;
                    var roomRepository = new RoomRepository();
                    var comfortRepository = new ComfortRepository();
                    if (c == null)
                    {
                        viewModel = new RoomViewModel(roomRepository, comfortRepository);
                    }
                    else
                    {
                        viewModel = c as RoomViewModel;
                    }
                    await displayRootRegistry.ShowModalPresentation(viewModel);

                    sourceRooms = roomRepository.GetAll()
                        .Select(c => new RoomViewModel(c, roomRepository, comfortRepository));
                    allRooms = new ObservableCollection<RoomViewModel>(sourceRooms);
                    RaisePropertyChanged(nameof(AllRooms));
                });
        }
    }
}
