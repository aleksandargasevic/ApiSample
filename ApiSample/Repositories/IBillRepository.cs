using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Domain;

namespace ApiSample.Repositories
{
    public interface IBillRepository
    {
        Task AddAsync(Bill bill);
        Task AddPersonBill(Guid billId, Guid personId);
        Task<Bill> GetAsync(Guid id);
        Task<List<Bill>> GetPersonBillsAsync(Guid personId);
    }
}
