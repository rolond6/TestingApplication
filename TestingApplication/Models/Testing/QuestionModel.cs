using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Services.Session;

namespace TestingApplication.Models.Testing
{
    internal class QuestionModel
    {
        private ITestSession? _session;

        public QuestionModel(ITestSession? session)
        {
            _session = session;
        }
    }
}
