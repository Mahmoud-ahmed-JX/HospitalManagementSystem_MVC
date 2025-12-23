using HospitalDAL.Data;
using HospitalDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDAL.Repositories.Classes
{
    public class UnitOfWork(ApplicationDbContext _dbcontext) : IUnintOfWork
    {
        private readonly Dictionary<Type,object> Repos = new Dictionary<Type,object>();
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (Repos.TryGetValue(typeof(TEntity), out var Repo))
                return (IGenericRepository<TEntity>)Repo;
            var newRepo = new GenericRepository<TEntity>(_dbcontext);
            Repos.Add(typeof(TEntity),newRepo);
            return newRepo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
