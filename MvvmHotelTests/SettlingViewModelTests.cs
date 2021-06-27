using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmHotel.Data.NoSqlRepositories;
using MvvmHotel.Interfaces;
using MvvmHotel.Models;
using MvvmHotel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmHotel.ViewModel.Tests
{
    [TestClass()]
    public class SettlingViewModelTests
    {
        private SettlingViewModel viewModel;
        private IRoomRepository roomRepository;
        private IClientRepository clientRepository;
        private ISettlingRepository settlingRepository;
        private Settling settling;

        [TestInitialize()]
        public void Initialize()
        {
            roomRepository = new NoSqlRoomRepository();
            clientRepository = new NoSqlClientRepository();
            settlingRepository = new NoSqlSettlingRepository();

            settling = new Settling
            {
                EntryDate = DateTime.Now,
                ReleaseDate = null,
                ClientId = 1,
                RoomId = 1
            };

            viewModel = new SettlingViewModel(settling, clientRepository, roomRepository, settlingRepository);
        }
        [TestMethod()]
        public void IsValidTest()
        {
            Assert.AreEqual(true, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyConstructorTest()
        {
            viewModel = new SettlingViewModel(clientRepository, roomRepository, settlingRepository);

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void IsOpenSettlingTest()
        {
            viewModel = new SettlingViewModel(clientRepository, roomRepository, settlingRepository);

            Assert.AreEqual(true, viewModel.IsOpenSettling);
        }
        [TestMethod()]
        public void CloseSettlingTest()
        {
            viewModel.ReleaseDate = DateTime.Now;

            Assert.AreEqual(false, viewModel.IsOpenSettling);
        }

        [TestMethod()]
        public void EmptyFioValidTest()
        {
            viewModel.ClientNameAndSurname = "";

            Assert.AreEqual(false, viewModel.IsValid);
        }

        [TestMethod()]
        public void ValidFioValidTest()
        {
            viewModel.ClientNameAndSurname = "";
            viewModel.ClientNameAndSurname = clientRepository.GetAll().First().Name + " " + clientRepository.GetAll().First().Surname;

            Assert.AreEqual(true, viewModel.IsValid);
        }

        [TestMethod()]
        public void BadNumberTest()
        {
            viewModel.RoomNumber = -1;

            Assert.AreEqual(false, viewModel.IsValid);
        }

        [TestMethod()]
        public void DefaultEntryDateTest()
        {
            viewModel.EntryDate = default;

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void NullReleaseDateTest()
        {
            viewModel.ReleaseDate = null;

            Assert.AreEqual(true, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyNameAndSurnameTest()
        {
            viewModel = new SettlingViewModel(clientRepository, roomRepository, settlingRepository);

            viewModel.RoomNumber = roomRepository.GetAll().First().Number;
            viewModel.EntryDate = DateTime.Now.AddDays(-1);
            viewModel.ReleaseDate = DateTime.Now;

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyRoomNumberTest()
        {
            viewModel = new SettlingViewModel(clientRepository, roomRepository, settlingRepository);

            viewModel.ClientNameAndSurname = clientRepository.GetAll().First().Name + " " + clientRepository.GetAll().First().Surname;
            viewModel.EntryDate = DateTime.Now.AddDays(-1);
            viewModel.ReleaseDate = DateTime.Now;

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyEntryDateTest()
        {
            viewModel = new SettlingViewModel(clientRepository, roomRepository, settlingRepository);

            viewModel.ClientNameAndSurname = clientRepository.GetAll().First().Name + " " + clientRepository.GetAll().First().Surname;
            viewModel.RoomNumber = roomRepository.GetAll().First().Number;
            viewModel.ReleaseDate = DateTime.Now;

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyReleaseDateTest()
        {
            viewModel = new SettlingViewModel(clientRepository, roomRepository, settlingRepository);

            viewModel.ClientNameAndSurname = clientRepository.GetAll().First().Name + " " + clientRepository.GetAll().First().Surname;
            viewModel.RoomNumber = roomRepository.GetAll().First().Number;
            viewModel.EntryDate = DateTime.Now.AddDays(-1);

            Assert.AreEqual(true, viewModel.IsValid);
        }
    }
}