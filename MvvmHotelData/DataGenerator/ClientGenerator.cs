
using Bogus;
using MvvmHotel.Data.DataGenerator;
using MvvmHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bogus.DataSets.Name;

namespace HotelModels.Data.DataGenerator
{
    class ClientGenerator
    {
        internal static IEnumerable<Client> GenerateClients(int count)
        {
            Faker<Client> generatorPerson = getGeneratorPerson();
            List<Client> persons = generatorPerson.Generate(count);

            foreach (var client in persons)
            {
                client.PassportData = NumberGenerator.GenerateString(10);
            }

            return persons;
        }
        private static Faker<Client> getGeneratorPerson()
        {
            return new Faker<Client>("ru")
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                 .RuleFor(x => x.Surname, f => f.Name.LastName())
                .RuleFor(x => x.PhoneNumber, f => "8" + f.Phone.PhoneNumber().Replace("(", "").Replace(")", "").Replace("-", ""));
        }
    }
}
