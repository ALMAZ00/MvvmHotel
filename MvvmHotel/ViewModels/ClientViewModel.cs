using MvvmHotel.Data.Repositories;
using MvvmHotel.Interfaces;
using MvvmHotel.Models;
using MvvmHotel.View;
using Prism.Mvvm;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmHotel.ViewModel
{
    public class ClientViewModel : BindableBase
    {
        public Client Client { get; private set; }
        private readonly IClientRepository clientRepository;
        public RelayCommand SaveClient { get; set; }
        public RelayCommand DeleteClient { get; set; }
        public ClientViewModel()
        {
            this.Client = new Client();
            this.clientRepository = new ClientRepository();
            CreateSaveCommand();
        }       

        public ClientViewModel(IClientRepository clientRepository)
        {
            this.Client = new Client();
            this.clientRepository = clientRepository;
            CreateSaveCommand();
        }
        public ClientViewModel(Client client, IClientRepository clientRepository)
        {
            this.Client = client;
            this.clientRepository = clientRepository;
            CreateSaveCommand();
        }
        private void CreateSaveCommand()
        {
            SaveClient = new RelayCommand(
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
                            });
            DeleteClient = new RelayCommand(
               async c =>
               {
                   try
                   {
                       await clientRepository.Delete(Client);
                   }
                   catch (Exception)
                   {
                       MessageBox.Show("Дождитесь выполнения операции!");
                   }
               });
        }
        public bool IsValid
        {
            get
            {
                return Client.IsValid;
            }
        }
        public bool IsBlockPassportData
        {
            get
            {
                return clientRepository.Contains(Client);
            }
        }
        public bool IsOldClient
        {
            get
            {
                return clientRepository.Contains(Client);
            }
        }
        public async Task Save()
        {
            if (IsValid)
            {
                if (clientRepository.Contains(Client))
                {
                    await clientRepository.Update(Client);
                }
                else
                {
                    CheckClientData();
                    await clientRepository.Create(Client);
                }
            }
        }

        private void CheckClientData()
        {
            if (clientRepository.GetAll()
                .FirstOrDefault(c => c.PassportData == Client.PassportData) != null)
            {
                throw new InvalidOperationException($"Клиент с паспортными данными {Client.PassportData}" +
                    $" уже существует");
            }
            if (clientRepository.GetAll()
                .FirstOrDefault(c => c.PhoneNumber == Client.PhoneNumber) != null)
            {
                throw new InvalidOperationException($"Клиент с номером телефона {Client.PhoneNumber}" +
                    $" уже существует");
            }
        }

        public string Name
        {
            get
            {
                return Client.Name;
            }
            set
            {
                Client.Name = value;
                RaisePropertyChanged(nameof(IsValid));
            }
        }
        public string Surname
        {
            get
            {
                return Client.Surname;
            }
            set
            {
                Client.Surname = value;
                RaisePropertyChanged(nameof(IsValid));
            }
        }
        public string PassportData
        {
            get
            {
                return Client.PassportData;
            }
            set
            {
                Client.PassportData = value;
                RaisePropertyChanged(nameof(IsValid));
            }
        }
        public string PhoneNumber
        {
            get
            {
                return Client.PhoneNumber;
            }
            set
            {
                Client.PhoneNumber = value;
                RaisePropertyChanged(nameof(IsValid));
            }
        }

    }
}
