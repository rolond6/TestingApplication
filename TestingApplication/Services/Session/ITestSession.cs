using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;

namespace TestingApplication.Services.Session
{
    internal interface ITestSession
    {
        void Start(Test test, bool edit_mode = false);
        void NextQuestion();
        void PrevQuestion();
        void Stop();
    }
}
