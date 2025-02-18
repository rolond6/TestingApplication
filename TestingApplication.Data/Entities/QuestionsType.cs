using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities.Interfaces;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace TestingApplication.Data.Entities
{
    public class QuestionsType : BaseEntity, IQuestionsType
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        public virtual List<Question> Questions { get; set; } = new();
    }
}
