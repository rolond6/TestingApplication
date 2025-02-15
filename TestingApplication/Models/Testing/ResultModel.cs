using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Services.Session;

namespace TestingApplication.Models.Testing
{
    internal class ResultModel
    {
        private ITestSession? _session;

        public ResultModel(ITestSession? session)
        {
            _session = session;
        }
    }
}
