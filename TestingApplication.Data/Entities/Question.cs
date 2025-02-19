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
using static System.Net.Mime.MediaTypeNames;

namespace TestingApplication.Data.Entities
{
    public class Question : BaseEntity, IQuestion
    {
        private string _name;
        private string _description;
        private int _testId;
        private Test? _test;
        private int _typeId;
        private QuestionsType? _type;

        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public int TestId { get => _testId; set => _testId = value; }
        public virtual Test? Test { get => _test; set => _test = value; }
        public int TypeId { get => _typeId; set => _typeId = value; }
        public virtual QuestionsType? Type { get => _type; set => _type = value; }

        public virtual List<Answer> Answers { get; set; } = new();
    }
}
