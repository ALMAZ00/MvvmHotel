using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvvmHotel.Models
{
    public class Settling
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EntryDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ReleaseDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual bool IsValid
        {
            get
            {
                return ClientId > 0 && RoomId > 0 && EntryDate != default;
            }
        }
        public virtual bool IsOpenSettling
        {
            get
            {
                return ReleaseDate == null;
            }
        }
    }
}
