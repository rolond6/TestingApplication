using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public virtual TEntity? Get(int id)
        {
            try
            {
                return _dbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить запись", ex);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить записи", ex);
            }
        }

        public virtual IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            try
            {
                return _dbSet.AsNoTracking().Where(predicate);
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить записи", ex);
            }
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
                throw new AddFailedRepositoryException("Не удалось добавить запись", ex);
            }
        }

        public virtual void Edit(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _dbContext.ChangeTracker.Clear();
                throw new EditFailedRepositoryException("Не удалось изменить запись", ex);
            }
        }

        public virtual void Remove(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _dbContext.ChangeTracker.Clear();
                throw new RemoveFailedRepositoryException("Не удалось удалить запись", ex);
            }
        }
    }
}
