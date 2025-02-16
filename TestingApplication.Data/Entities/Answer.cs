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
    public class Answer : BaseEntity, IAnswer
    {
        private string _name;
        private string? _description;

        public string Name { get => _name; set => _name = value; }
        public string? Description { get => _description; set => _description = value; }

        public virtual ICollection<AnswerQuestion> AnswerQuestions { get; set; }
    }
}
