using Microsoft.EntityFrameworkCore;
using MvvmHotel.Interfaces;
using MvvmHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmHotel.Data.Repositories
{
    public class ComfortRepository : IComfortRepository
    {
        private readonly HotelContext hotelContext;
        public ComfortRepository()
        {
            hotelContext = new HotelContext();
        }

        public IEnumerable<Comfort> GetAll()
        {
            return hotelContext.Comforts;
        }
    }
}
