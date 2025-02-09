using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Data.Repositories.SQLite
{
    internal class SQLiteQuestionsRepository : IQuestionsRepository
    {
        public async Task<Question> Create(Question entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Question entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Question> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Question entity)
        {
            throw new NotImplementedException();
        }
    }
}
