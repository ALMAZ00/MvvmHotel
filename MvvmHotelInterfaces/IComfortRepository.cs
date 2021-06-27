using MvvmHotel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvvmHotel.Interfaces
{
    public interface IComfortRepository
    {
        IEnumerable<Comfort> GetAll();
    }
}