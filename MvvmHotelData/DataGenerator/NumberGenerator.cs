using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmHotel.Data.DataGenerator
{
    class NumberGenerator
    {
        private static Random rnd = new Random();
        public static string GenerateString(int count)
        {
            string result = "";

            for (int i = 0; i < count; i++)
            {
                result += rnd.Next(0, 10);
            }

            return result;
        }
    }
}
