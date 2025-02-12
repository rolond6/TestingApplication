using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Models
{
    internal class AnswersModel
    {
        IAnswersRepository _repository;

        public AnswersModel(IAnswersRepository repository)
        {
            _repository = repository;
        }

        public void TestAdd()
        {
            _repository.Create(new Data.Entities.Answer() { Name = "Проверка", Description="Тестовое описание" });
        }
    }
}
