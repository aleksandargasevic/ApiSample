using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Data;
using ApiSample.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiSample.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly AppDbContext _context;

        public BillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Bill bill)
        {
            await _context.Bills.AddAsync(bill);
        }

        public async Task AddPersonBill(Guid billId, Guid personId)
        {
            var personBill = new PersonBill
            {
                BillId = billId,
                PersonId = personId
            };
            await _context.PersonBills.AddAsync(personBill);
        }

        public async Task<Bill> GetAsync(Guid id) => await _context.Bills.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<Bill>> GetPersonBillsAsync(Guid personId)
        {
            return await _context.PersonBills
                .Include(x => x.Bill)
                .Where(x => x.PersonId == personId)
                .Select(x => x.Bill)
                .ToListAsync();
        }
    }
}
