using MvvmHotel.Data.Repositories;
using MvvmHotel.Interfaces;
using MvvmHotel.Models;
using MvvmHotel.View;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmHotel.ViewModel
{
    class AllSettlingsViewModel : BindableBase
    {
        public RelayCommand DeleteSettling { get; set; }
        public RelayCommand ReleaseSettling { get; set; }
        public RelayCommand CreateSettling { get; set; }
        public RelayCommand FilterList { get; set; }
        public ObservableCollection<SettlingViewModel> AllSettlings => allSettlings;
        private readonly ObservableCollection<SettlingViewModel> allSettlings;
        private readonly IEnumerable<SettlingViewModel> sourceClients;
        private ISettlingRepository settlingRepository;
        public AllSettlingsViewModel()
        {
            settlingRepository = new SettlingRepository();
            sourceClients = settlingRepository.GetAll().Select(c => new SettlingViewModel(c));
            allSettlings = new ObservableCollection<SettlingViewModel>(sourceClients);

            DeleteSettling = new RelayCommand(
                async c =>
                {
                    var settling = c as SettlingViewModel;

                    if (settling != null)
                    {
                        try
                        {
                            await Delete(settling);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Дождитесь выполнения операции!");
                        }
                    }
                });

            ReleaseSettling = new RelayCommand(
                async c =>
                {
                    var settling = c as SettlingViewModel;

                    if (settling != null)
                    {
                        try
                        {
                            await Release(settling);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Дождитесь выполнения операции!");
                        }
                    }
                });
            CreateSettling = new RelayCommand(
                async c =>
                {
                    var displayRootRegistry = (Application.Current as App).displayRootRegistry;
                    SettlingViewModel viewModel;
                    var clientRepository = new ClientRepository();
                    var roomRepository = new RoomRepository();
                    var settlingRepository = new SettlingRepository();
                    if (c == null)
                    {
                        viewModel = new SettlingViewModel(clientRepository, roomRepository, settlingRepository);
                    }
                    else
                    {
                        viewModel = c as SettlingViewModel;
                    }
                    await displayRootRegistry.ShowModalPresentation(viewModel);

                    try
                    {
                        var index = allSettlings.IndexOf(viewModel);
                        allSettlings.Remove(viewModel);
                        if (index > -1)
                        {
                            allSettlings.Insert(index, viewModel);
                        }
                        else
                        {
                            allSettlings.Add(viewModel);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Дождитесь выполнения операции!");
                    }
                });
                FilterList = new RelayCommand(
                   c =>
                   {
                       string text = c as string;
                       ObservableCollection<SettlingViewModel> filterList;

                       if (string.IsNullOrEmpty(text))
                       {
                           filterList = new ObservableCollection<SettlingViewModel>(sourceClients);
                       }
                       else
                       {
                           filterList = new ObservableCollection<SettlingViewModel>(
                               (sourceClients.Where(c => c.ClientNameAndSurname.Contains(text.Trim(), StringComparison.OrdinalIgnoreCase))));
                           
                       }

                       allSettlings.Clear();
                       foreach (var client in filterList)
                       {
                           allSettlings.Add(client);
                       }
                   });
        }
        public async Task Delete(SettlingViewModel settling)
        {
            await settlingRepository.Delete(settling.Settling);
            allSettlings.Remove(settling);
            RaisePropertyChanged(nameof(AllSettlings));
        }
        public async Task Release(SettlingViewModel settling)
        {
            settling.ReleaseDate = DateTime.Now;
            await settlingRepository.Update(settling.Settling);
            var oldSettling = allSettlings.FirstOrDefault(c => c.ClientNameAndSurname == settling.ClientNameAndSurname
                           && c.RoomNumber == settling.RoomNumber
                           && c.EntryDate == settling.EntryDate);
            var index = allSettlings.IndexOf(oldSettling);

            var newSettling = oldSettling;
            newSettling.ReleaseDate = DateTime.Now;

            allSettlings.Remove(oldSettling);
            allSettlings.Insert(index, newSettling);
        }
    }
}
