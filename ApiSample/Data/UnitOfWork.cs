using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Repositories;

namespace ApiSample.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private IPersonRepository _personRepository;
        public IPersonRepository PersonRepository
        {
            get { return _personRepository ??= new PersonRepository(_context); }
        }

        private IBillRepository _billRepository;
        public IBillRepository BillRepository
        {
            get { return _billRepository ??= new BillRepository(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
