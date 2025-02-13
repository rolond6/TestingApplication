using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Repositories.Interfaces;
using TestingApplication.Services.Session;

namespace TestingApplication.Models
{
    internal class TestLobbyModel
    {
        private ITestsRepository? _repository;
        private LocalTestSession? _session;

        public TestLobbyModel() { }
        public TestLobbyModel(ITestsRepository repository, LocalTestSession session)
        {
            _repository = repository;
            _session = session;
        }

        public async Task<IEnumerable<Test>> GetTestList()
        {
            if (_repository != null)
                return await Task.Run(_repository.GetAll);
            return new List<Test>();
        }

        public async Task StartTest(Test test)
        {
            if (_session != null)
                _session.Start(test);
        }
        public async Task CreateTest()
        {
            if (_session != null)
                _session.Start(new Test(), true);
        }
        public async Task EditTest(Test test)
        {
            if (_session != null)
                _session.Start(test, true);
        }
        public async Task DeleteTest(Test test)
        {

        }
    }
}
