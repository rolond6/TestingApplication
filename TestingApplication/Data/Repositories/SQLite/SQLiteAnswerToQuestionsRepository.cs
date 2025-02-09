using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Data.Repositories.SQLite
{
    internal class SQLiteAnswerToQuestionsRepository : IAnswerToQuestionsRepository
    {
        public async Task<AnswerToQuestion> Create(AnswerToQuestion entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(AnswerToQuestion entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AnswerToQuestion> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnswerToQuestion>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Update(AnswerToQuestion entity)
        {
            throw new NotImplementedException();
        }
    }
}
