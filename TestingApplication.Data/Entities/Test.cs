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
    public class Test : BaseEntity, ITest
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Timer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
