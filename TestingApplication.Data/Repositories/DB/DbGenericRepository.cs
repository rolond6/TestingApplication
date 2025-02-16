using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Repositories.Exceptions;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Data.Repositories.DB
{
    public class DbGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContext _dbContext;

        protected DbSet<TEntity> _dbSet;

        public DbGenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _dbContext.ChangeTracker.Clear();
                throw new AddFailedRepositoryException("Произошла ошибка при добавлении записи", ex);
            }
        }

        public virtual TEntity? Get(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking().ToList();
            }
            catch
            {
                throw new GetFailedRepositoryException();
            }
        }

        public virtual IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            try
            {
                return _dbSet.AsNoTracking().Where(predicate).ToList();
            }
            catch
            {
                throw new GetFailedRepositoryException();
            }
        }

        public virtual void Remove(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch
            {
                _dbContext.ChangeTracker.Clear();
                throw new RemoveFailedRepositoryException();
            }
        }

        public virtual void Edit(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                _dbContext.SaveChanges();
            }
            catch
            {
                _dbContext.ChangeTracker.Clear();
                throw new RemoveFailedRepositoryException();
            }
        }
    }
}
