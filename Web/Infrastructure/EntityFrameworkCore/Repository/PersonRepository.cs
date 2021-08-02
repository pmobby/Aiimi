using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.Entities;
using Web.Core.Interfaces;
using Web.Entities;

namespace Web.Infrastructure.EntityFrameworkCore.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AiimiContext _aiimiContext;

        public PersonRepository(AiimiContext aiimiContext)
        {
            _aiimiContext = aiimiContext;
        }
        public void AddUser(Person person)
        {
            var people = _aiimiContext.People.ToList();

            bool personExists = people.Any(x => x.FirstName == person.FirstName && x.LastName == person.LastName);

            if(!personExists)
            {
                _aiimiContext.Add(person);
                _aiimiContext.SaveChanges();
            }
           
        }

        public async Task<IEnumerable<Person>> GetEverybody()
        {
            return await _aiimiContext.People.ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetPeopleBySearch(string searchTerm)
        {
            var people = await _aiimiContext.People.Where(p => p.LastName.Contains(searchTerm) || p.FirstName.Contains(searchTerm)).ToListAsync();            

            return people;
        }

        public async Task<Person> GetPerson(string fullname)
        {
            string[] namearray = fullname.Split(' ');
            string firstName = namearray[0];
            string lastName = namearray[1];

            var person = await _aiimiContext.People.Where(p => p.FirstName == firstName && p.LastName == lastName).FirstOrDefaultAsync();

            return person;
        }
    }
}
