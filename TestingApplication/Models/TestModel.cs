using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Repositories.Interfaces;
using TestingApplication.Services.Session;

namespace TestingApplication.Models
{
    internal class TestModel
    {
        private ITestSession? _session;
        public TestModel() { }
        public TestModel(ITestSession session)
        {
            _session = session;
        }
    }
}
