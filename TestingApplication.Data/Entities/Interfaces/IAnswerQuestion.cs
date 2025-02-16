using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Interfaces
{
    public interface IAnswerQuestion: IIdentifiableEntity
    {
        int? QuestionId { get; set; }
        int? AnswerId { get; set; }
        bool IsTrue { get; set; }  
    }
}
