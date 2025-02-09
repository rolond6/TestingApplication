using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Data.Repositories.SQLite
{
    internal class SQLiteQuestionsTypesRepository : IQuestionsTypesRepository
    {
        public async Task<QuestionsType> Create(QuestionsType entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(QuestionsType entity)
        {
            throw new NotImplementedException();
        }

        public async Task<QuestionsType> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QuestionsType>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Update(QuestionsType entity)
        {
            throw new NotImplementedException();
        }
    }
}
