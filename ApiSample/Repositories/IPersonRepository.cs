using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Domain;

namespace ApiSample.Repositories
{
    public interface IPersonRepository
    {
        Task AddAsync(Person person);
        void Remove(Person person);
        void Update(Person person);
        Task<Person> GetByIdAsync(Guid id);
        Task<List<Person>> GetAllAsync();
    }
}
