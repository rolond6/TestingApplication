using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Models
{
    internal class AnswerToQuestionsModel
    {
        IAnswerToQuestionsRepository _repository;

        public AnswerToQuestionsModel(IAnswerToQuestionsRepository repository)
        {
            _repository = repository;
        }
    }
}
