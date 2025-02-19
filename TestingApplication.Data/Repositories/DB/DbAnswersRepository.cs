using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Entities.Interfaces;
using TestingApplication.Data.Repositories.Exceptions;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Data.Repositories.DB
{
    public class DbAnswersRepository: DbGenericRepository<Answer>, IAnswersRepository
    {
        public DbAnswersRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override Answer? Get(int id)
        {
            try
            {
                return _dbSet.AsNoTracking().Include(t => t.Question).FirstOrDefault(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить запись", ex);
            }
        }

        public override IEnumerable<Answer> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking().Include(t => t.Question).ToList();
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить записи", ex);
            }
        }

        public override IEnumerable<Answer> GetAll(Func<Answer, bool> predicate)
        {
            try
            {
                return _dbSet.AsNoTracking().Include(t => t.Question).Where(predicate);
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить записи", ex);
            }
        }
    }
}
