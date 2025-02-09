using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities.Interfaces;

namespace TestingApplication.Data.Entities
{
    internal class AnswerToQuestion : IAnswerToQuestion
    {
        public Guid Id => throw new NotImplementedException();

        public Guid QuestionID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid AnswerID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsTrue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
