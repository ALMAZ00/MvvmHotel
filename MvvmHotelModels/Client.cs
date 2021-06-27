using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace MvvmHotel.Models
{
    public class Client
    {
        public Client() { }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [MaxLength(10)]
        public string PassportData { get; set; }
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public virtual bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Name) &&
                    !string.IsNullOrEmpty(Surname) &&
                    !string.IsNullOrEmpty(PhoneNumber) &&
                    !string.IsNullOrEmpty(PassportData) && IsCorrect();
            }
        }
        public bool IsCorrect()
        {
            Regex regex = new Regex("^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)" +
                "?[\\d\\- ]{7,10}$");
            regex = new Regex("(8|\\+7|7)[0-9]{10}");
            if (regex.IsMatch(PhoneNumber) == false)
            {
                return false;
            }

            regex = new Regex(@"\w*");
            if (regex.IsMatch(Name) == false)
            {
                return false;
            }
            regex = new Regex(@"\w*");
            if (regex.IsMatch(Surname) == false)
            {
                return false;
            }

            regex = new Regex("\\d{10}");
            if (regex.IsMatch(PassportData) == false)
            {
                return false;
            }

            return true;
        }
    }
}
