using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Interfaces
{
    public interface IAnswerQuestion
    {
        int Id { get; set; }
        int? QuestionID { get; set; }
        int? AnswerID { get; set; }
        bool IsTrue { get; set; }  
    }
}
