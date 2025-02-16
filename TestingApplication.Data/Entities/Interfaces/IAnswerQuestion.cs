using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Interfaces
{
    public interface IAnswerQuestion: IIdentifiableEntity
    {
        byte[]? QuestionId { get; set; }
        byte[]? AnswerId { get; set; }
        bool IsTrue { get; set; }  
    }
}
