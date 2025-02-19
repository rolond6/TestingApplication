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
    public class DbQuestionsRepository : DbGenericRepository<Question>, IQuestionsRepository
    {
        public DbQuestionsRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override Question? Get(int id)
        {
            try
            {
                return _dbSet.AsNoTracking().Include(t => t.Test).Include(t => t.Answers).FirstOrDefault(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить запись", ex);
            }
        }

        public override IEnumerable<Question> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking().Include(t => t.Test).Include(t => t.Answers).ToList();
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить записи", ex);
            }
        }

        public override IEnumerable<Question> GetAll(Func<Question, bool> predicate)
        {
            try
            {
                return _dbSet.AsNoTracking().Include(t => t.Test).Include(t => t.Answers).Where(predicate);
            }
            catch (Exception ex)
            {
                throw new GetFailedRepositoryException("Не удалось получить записи", ex);
            }
        }
    }
}
