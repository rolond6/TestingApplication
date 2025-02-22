﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Data.Repositories.DB
{
    public class DbQuestionsTypesRepository : DbGenericRepository<QuestionsType>, IQuestionsTypesRepository
    {
        public DbQuestionsTypesRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
