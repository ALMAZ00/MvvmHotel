using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmHotel.Interfaces
{
    public interface IRepository<T>
    {
        bool Contains(T model);
        Task<int> Create(T model);
        Task Delete(T model);
        IEnumerable<T> GetAll();
        Task Update(T model);
    }
}
