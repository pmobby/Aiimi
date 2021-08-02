using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Core.Interfaces
{
    public interface IPersonService
    {
        public Task<IEnumerable<Person>> GetEverybody();
        public Task<IEnumerable<Person>> GetPeopleBySearch(string searchTerm);
        public Task<Person> GetPerson(string fullname);
        void AddUser(Person person);
    }
}
