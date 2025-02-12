using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Models
{
    internal class TestsModel
    {
        ITestsRepository _repository;

        public TestsModel(ITestsRepository repository)
        {
            _repository = repository;
        }
    }
}
