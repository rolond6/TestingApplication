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
    public class DbTestsRepository : DbGenericRepository<Test>, ITestsRepository
    {
        public DbTestsRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override Test? Get(int id)
        {
            try
            {
                return _dbSet.AsNoTracking().Include(t => t.Questions).ThenInclude(t => t.Answers).FirstOrDefault(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить запись", ex);
            }
        }

        public override IEnumerable<Test> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking().Include(t => t.Questions).ThenInclude(t => t.Answers).ToList();
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить записи", ex);
            }
        }

        public override IEnumerable<Test> GetAll(Func<Test, bool> predicate)
        {
            try
            {
                return _dbSet.AsNoTracking().Include(t => t.Questions).ThenInclude(t => t.Answers).Where(predicate);
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить записи", ex);
            }
        }
    }
}
