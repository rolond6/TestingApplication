using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Data.Repositories.SQLite
{
    internal class SQLiteAnswersRepository : IAnswersRepository
    {
        public async Task<Answer> Create(Answer entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Answer entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Answer> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Answer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Answer entity)
        {
            throw new NotImplementedException();
        }
    }
}
