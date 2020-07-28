using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Repositories;

namespace ApiSample.Data
{
    public interface IUnitOfWork
    {
        IPersonRepository PersonRepository { get; }
        IBillRepository BillRepository { get; }
        void Commit();
        Task CommitAsync();
        void Rollback();
        Task RollbackAsync();
    }
}
