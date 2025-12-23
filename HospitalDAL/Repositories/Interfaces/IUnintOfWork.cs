using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Repositories.Interfaces
{
    public interface IUnintOfWork
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity :class;

        Task<int> SaveChangesAsync();
    }
}
