using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Entities.Interfaces;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Data.Repositories.DB
{
    public class DbAnswerQuestionRepository : DbGenericRepository<AnswerQuestion>, IAnswerQuestionRepository
    {
        public DbAnswerQuestionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
