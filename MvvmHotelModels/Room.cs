using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmHotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int ComfortId { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }
        public virtual bool IsValid
        {
            get
            {
                return Capacity > 0 && Capacity < 20 && ComfortId > 0 && Price > 0;
            }
        }
    }
}
