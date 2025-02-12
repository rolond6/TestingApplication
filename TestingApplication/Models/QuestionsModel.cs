using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Models
{
    internal class QuestionsModel
    {
        IQuestionsRepository _repository;

        public QuestionsModel(IQuestionsRepository repository)
        {
            _repository = repository;
        }
    }
}
