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
    public class RoomViewModelTests
    {
        private RoomViewModel viewModel;
        private IRoomRepository roomRepository;
        private IComfortRepository comfortRepository;
        private Room room;

        [TestInitialize()]
        public void Initialize()
        {
            roomRepository = new NoSqlRoomRepository();
            comfortRepository = new NoSqlComfortRepository();

            room = roomRepository.GetAll().First();

            viewModel = new RoomViewModel(room, roomRepository, comfortRepository);
        }
        [TestMethod()]
        public void IsValidTest()
        {
            Assert.AreEqual(true, viewModel.IsValid);
        }
        [TestMethod()]
        public void ChangeCapacityIsValidTest()
        {
            viewModel.Capacity = -2;

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void ChangePriceDataIsValid()
        {
            viewModel.Price = -1;

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void ChangeComfortNumberIsValid()
        {
            viewModel.Comfort = "Нету такого комфорта!";

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void ChangeComfortNumberIsZeroComfortId()
        {
            viewModel.Comfort = "Нету такого комфорта!";

            Assert.AreEqual("", viewModel.Comfort);
        }
        [TestMethod()]
        public void ChangePrice2TimesIsValidTest()
        {
            viewModel.Price = -100;
            viewModel.Price = 1500;

            Assert.AreEqual(true, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyConstructorIsValid()
        {
            viewModel = new RoomViewModel(roomRepository, comfortRepository);

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyCapacityIsValid()
        {
            viewModel = new RoomViewModel(roomRepository, comfortRepository);

            viewModel.Comfort = comfortRepository.GetAll().First().Name;
            viewModel.Price = roomRepository.GetAll().First().Price;

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyPriceIsValid()
        {
            viewModel = new RoomViewModel(roomRepository, comfortRepository);

            viewModel.Capacity = roomRepository.GetAll().First().Capacity;
            viewModel.Comfort = comfortRepository.GetAll().First().Name;

            Assert.AreEqual(false, viewModel.IsValid);
        }
        [TestMethod()]
        public void EmptyComfortIsValid()
        {
            viewModel = new RoomViewModel(roomRepository, comfortRepository);

            viewModel.Capacity = roomRepository.GetAll().First().Capacity;
            viewModel.Price = roomRepository.GetAll().First().Price;

            Assert.AreEqual(false, viewModel.IsValid);
        }
    }
}
