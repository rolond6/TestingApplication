using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities.Interfaces;

namespace TestingApplication.Data.Entities
{
    public class AnswerQuestion : IAnswerQuestion
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int? QuestionID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual Question Question { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int? AnswerID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual Answer Answer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsTrue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
