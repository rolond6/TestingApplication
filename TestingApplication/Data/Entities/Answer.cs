using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities.Interfaces;
using Avalonia;

namespace TestingApplication.Data.Entities
{
    internal class Answer : IAnswer
    {
        private int _id;
        private string _name;
        private string? _description;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string? Description { get => _description; set => _description = value; }

        public virtual ICollection<AnswerToQuestion> AnswerToQuestions { get; set; }
    }
}
