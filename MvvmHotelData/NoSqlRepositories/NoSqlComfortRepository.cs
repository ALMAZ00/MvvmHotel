using MvvmHotel.Interfaces;
using MvvmHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmHotel.Data.NoSqlRepositories
{
    public class NoSqlComfortRepository : IComfortRepository
    {
        public IEnumerable<Comfort> GetAll()
        {
            return new List<Comfort>()
            {
                new Comfort{Id = 1, Name = "Эконом" },
                new Comfort{Id = 2, Name = "Стандарт" },
                new Comfort{Id = 3, Name = "Люкс" }
            };
        }
    }
}
