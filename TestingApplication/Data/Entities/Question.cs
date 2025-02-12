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
    internal class Question : IQuestion
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int? TestId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual Test Test { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int? TypeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual QuestionsType Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public virtual ICollection<AnswerToQuestion> AnswersFromQuestion { get; set; }
    }
}
