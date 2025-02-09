using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Interfaces
{
    internal interface IAnswerToQuestion
    {
        Guid Id { get; }
        Guid QuestionID { get; set; }
        Guid AnswerID { get; set; }
        bool IsTrue { get; set; }  
    }
}
