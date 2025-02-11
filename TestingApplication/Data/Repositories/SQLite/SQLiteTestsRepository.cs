using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Data.Repositories.SQLite
{
    internal class SQLiteTestsRepository : ITestsRepository
    {
        public Task<Test> Create(Test entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Test entity)
        {
            throw new NotImplementedException();
        }

        public Task<Test> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Test>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Test entity)
        {
            throw new NotImplementedException();
        }
    }
}
