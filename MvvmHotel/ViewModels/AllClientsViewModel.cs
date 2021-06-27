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
using System.Windows.Controls;
using System.Windows.Input;

namespace MvvmHotel.ViewModel
{
    public class AllClientsViewModel : BindableBase
    {
        private readonly IClientRepository clientRepository;
        public RelayCommand ShowClient { get; set; }
        public RelayCommand FilterList { get; set; }
        public ObservableCollection<ClientViewModel> AllClients => allClients;
        private ObservableCollection<ClientViewModel> allClients;
        private IEnumerable<ClientViewModel> sourceClients;
        public AllClientsViewModel()
        {
            clientRepository = new ClientRepository();
            sourceClients = clientRepository.GetAll()
                             .Select(c => new ClientViewModel(c, clientRepository));
            allClients = new ObservableCollection<ClientViewModel>(sourceClients);

            ShowClient = new RelayCommand(
                async c =>
                {
                    var displayRootRegistry = (Application.Current as App).displayRootRegistry;
                    ClientViewModel viewModel;
                    var repository = new ClientRepository();
                    if (c == null)
                    {
                        viewModel = new ClientViewModel(repository);
                    }
                    else
                    {
                        viewModel = c as ClientViewModel;
                    }                    
                    await displayRootRegistry.ShowModalPresentation(viewModel);

                    sourceClients = clientRepository.GetAll()
                             .Select(c => new ClientViewModel(c, clientRepository));
                    allClients = new ObservableCollection<ClientViewModel>(sourceClients);
                    RaisePropertyChanged(nameof(AllClients));
                });

            FilterList = new RelayCommand(
                c =>
                {
                    string text = c as string;
                    ObservableCollection<ClientViewModel> filterList;

                    if (string.IsNullOrEmpty(text))
                    {
                        filterList = new ObservableCollection<ClientViewModel>(sourceClients);
                    }
                    else
                    {
                        filterList = new ObservableCollection<ClientViewModel>
                                (sourceClients.Where(c => c.Name.Contains(text.Trim(), StringComparison.OrdinalIgnoreCase)
                                || c.Surname.Contains(text.Trim(), StringComparison.OrdinalIgnoreCase)));
                    }

                    allClients.Clear();
                    foreach (var client in filterList)
                    {
                        allClients.Add(client);
                    }
                });
        }
    }
}
