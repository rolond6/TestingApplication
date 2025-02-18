using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Interfaces
{
    public interface IAnswer : IIdentifiableEntity
    {
        string Name { get; set; }
        string? Description { get; set; }
        bool IsTrue { get; set; }
        int QuestionId { get; set; }
    }
}
