using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities.Interfaces;
using System.Security.Cryptography;

namespace TestingApplication.Data.Entities
{
    public class AnswerQuestion : BaseEntity, IAnswerQuestion
    {
        private int? _questionId;
        private Question _question;
        private Answer _answer;
        private int? _answerId;
        private bool _isTrue;

        public int? QuestionId { get => _questionId; set => _questionId = value; }
        public virtual Question Question { get => _question; set => _question = value; }
        public int? AnswerId { get => _answerId; set => _answerId = value; }
        public virtual Answer Answer { get => _answer; set => _answer = value; }
        public bool IsTrue { get => _isTrue; set => _isTrue = value; }
    }
}
