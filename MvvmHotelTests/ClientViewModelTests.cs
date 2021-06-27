using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmHotel.Interfaces;
using MvvmHotel.Models;
using MvvmHotel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmHotel.Data.NoSqlRepositories;

namespace MvvmHotel.ViewModel.Tests
{
    [TestClass()]
    public class ClientViewModelTests
    {
        private ClientViewModel viewModel;
        private Client client;
        private IClientRepository clientRepository;

        [TestInitialize()]
        public void Initialize()
        {
            clientRepository = new NoSqlClientRepository();
            client = clientRepository.GetAll().First();

            viewModel = new ClientViewModel(client, clientRepository);
        }
        [TestMethod()]
        public void IsValidTest()
        {
            Assert.AreEqual(true, viewModel.IsValid);
        }
        [TestMethod()]
        public void ChangeFioIsValidTest()
        {
            viewModel.Name = "Петя";

            Assert.AreEqual(true, viewModel.IsValid);
        }
        [TestMethod()]
        public void ChangePassportDataIsValid()
        {
            viewModel.PassportData = "11";

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void ChangePhoneNumberIsValid()
        {
            viewModel.PhoneNumber = "1";

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void ChangePhoneNumber2TimesIsValidTest()
        {
            viewModel.PhoneNumber = "1";
            viewModel.PhoneNumber = "89900099009";

            Assert.AreEqual(true, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyConstructorIsValid()
        {
            viewModel = new ClientViewModel(clientRepository);

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyNameIsValid()
        {
            viewModel = new ClientViewModel(clientRepository);

            viewModel.Surname = "Surname";
            viewModel.PassportData = "1111111111";
            viewModel.PhoneNumber = "89997776655";

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptySurnameIsValid()
        {
            viewModel = new ClientViewModel(clientRepository);

            viewModel.Name = "Name";
            viewModel.PassportData = "1111111111";
            viewModel.PhoneNumber = "89997776655";

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyPassportDataIsValid()
        {
            viewModel = new ClientViewModel(clientRepository);

            viewModel.Name = "Name";
            viewModel.Surname = "Surname";
            viewModel.PhoneNumber = "89997776655";

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyPhoneNumberIsValid()
        {
            viewModel = new ClientViewModel(clientRepository);

            viewModel.Name = "Name";
            viewModel.Surname = "Surname";
            viewModel.PassportData = "1111111111";

            Assert.AreEqual(false, viewModel.IsValid);
        }
    }
}