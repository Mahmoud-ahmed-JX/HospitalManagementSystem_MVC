using HospitalDAL.Data;
using HospitalDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalDAL.Repositories.Classes
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> condition = null!)
        {
            if (condition == null)
                return _dbContext.Set<TEntity>().AsNoTracking().ToList();
            else
                return _dbContext.Set<TEntity>().AsNoTracking().Where(condition).ToList();

        }

        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);


        public void Update(TEntity entity)
        {
           _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
