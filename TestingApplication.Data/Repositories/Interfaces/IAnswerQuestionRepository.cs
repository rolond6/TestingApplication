using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Entities.Interfaces;

namespace TestingApplication.Data.Repositories.Interfaces
{
    public interface IAnswerQuestionRepository
    {
        IDictionary<Answer, bool> GetAnswersFromQuestion(Question question);
        void AddAnswerToQuestion(Answer answer, Question question, bool is_true);
        void RemoveAnswerFromQuestion(Answer answer, Question question);
        void EditAnswerFromQuestion(Answer answer_old, Answer answer_new, Question question, bool is_true);
    }
}
