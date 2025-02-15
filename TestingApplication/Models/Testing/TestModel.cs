using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Services.Session;

namespace TestingApplication.Models.Testing
{
    internal class TestModel
    {
        private ITestSession? _session;

        public TestModel(ITestSession? session)
        {
            _session = session;
        }

    }
}
