using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities.Interfaces;
using System.Xml.Linq;

namespace TestingApplication.Data.Entities
{
    public class Test : BaseEntity, ITest
    {
        private string _name;
        private string? _description;
        private int _timer;

        public string Name { get => _name; set => _name = value; }
        public string? Description { get => _description; set => _description = value; }
        public int Timer { get => _timer; set => _timer = value; }

        public virtual List<Question> Questions { get; set; } = new();
    }
}
