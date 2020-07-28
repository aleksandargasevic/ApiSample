using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Data;
using ApiSample.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiSample.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
        }

        public void Remove(Person person)
        {
            _context.Persons.Remove(person);
        }

        public void Update(Person person)
        {
            _context.Persons.Update(person);
        }

        public async Task<Person> GetByIdAsync(Guid id) => await _context.Persons.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<Person>> GetAllAsync() => await _context.Persons.ToListAsync();
    }
}
