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
    internal class DbAnswerToQuestionsRepository : DbGenericRepository<AnswerToQuestion>, IAnswerToQuestionsRepository
    {
        public DbAnswerToQuestionsRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
