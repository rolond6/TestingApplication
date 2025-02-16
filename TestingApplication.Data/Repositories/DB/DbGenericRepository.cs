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

        public TEntity? Add(TEntity entity)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbSet.Add(entity);
                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return _dbSet.Find(entity.Id);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new AddFailedRepositoryException("Произошла ошибка при добавлении записи", ex);
                }
                finally
                {
                    _dbContext.ChangeTracker.Clear();
                }
            }
        }

        public TEntity? Get(long id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
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

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
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

        public void Remove(TEntity entity)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbSet.Remove(entity);
                    _dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw new RemoveFailedRepositoryException();
                }
                finally
                {
                    _dbContext.ChangeTracker.Clear();
                }
            }
        }

        public void Edit(TEntity entity)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbSet.Update(entity);
                    _dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw new RemoveFailedRepositoryException();
                }
                finally
                {
                    _dbContext.ChangeTracker.Clear();
                }
            }
        }
    }
}
