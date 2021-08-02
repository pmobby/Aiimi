using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.Interfaces;
using Web.Entities;

namespace Web.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;
        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }
        public void AddUser(Person person)
        {
            _personRepo.AddUser(person);
        }

        public async Task<IEnumerable<Person>> GetEverybody()
        {
            var people = await _personRepo.GetEverybody();
            return people;
        }

        public async Task<IEnumerable<Person>> GetPeopleBySearch(string searchTerm)
        {
            var people = await _personRepo.GetPeopleBySearch(searchTerm);
            return people;
        }

        public async Task<Person> GetPerson(string fullname)
        {
            var person = await _personRepo.GetPerson(fullname);
            return person;
        }
    }
}
