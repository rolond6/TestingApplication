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
    public class Answer : BaseEntity, ICorrectAnswer
    {
        private string _name;
        private string? _description;
        private int _questionId;
        private Question? _question;
        private bool _isCorrect;

        public string Name { get => _name; set => _name = value; }
        public string? Description { get => _description; set => _description = value; }
        public int QuestionId { get => _questionId; set => _questionId = value; }
        public virtual Question? Question { get => _question; set => _question = value; }
        public bool IsCorrect { get => _isCorrect; set => _isCorrect = value; }
    }
}
