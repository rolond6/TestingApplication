using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Entities.Interfaces;
using TestingApplication.Data.Repositories.Exceptions;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Data.Repositories.DB
{
    public class DbAnswerQuestionRepository : IAnswerQuestionRepository
    {
        protected DbContext _dbContext;

        protected DbSet<Answer> _dbSetAnswers;
        protected DbSet<Question> _dbSetQuestions;
        protected DbSet<AnswerQuestion> _dbSetGeneric;

        public DbAnswerQuestionRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSetAnswers = _dbContext.Set<Answer>();
            _dbSetQuestions = _dbContext.Set<Question>();
            _dbSetGeneric = _dbContext.Set<AnswerQuestion>();
        }

        public IDictionary<Answer, bool> GetAnswersFromQuestion(Question question)
        {
            try
            {
                IDictionary<Answer, bool> keyValues = new Dictionary<Answer, bool>();

                Question? findedQuestion = _dbSetQuestions.FirstOrDefault(t => t.Id == question.Id);
                if (findedQuestion != null)
                {
                    foreach (var answerQuestion in _dbSetGeneric.Where(t => t.QuestionId == findedQuestion.Id))
                    {
                        if (answerQuestion != null)
                        {
                            Answer? findedAnswer = _dbSetAnswers.FirstOrDefault(t => t.Id == answerQuestion.AnswerId);
                            if (findedAnswer != null)
                            {
                                keyValues.Add(findedAnswer, answerQuestion.IsTrue);
                            }
                        }
                    }
                }

                return keyValues;
            }
            catch
            {
                throw new GetFailedRepositoryException();
            }
        }

        public void AddAnswerToQuestion(Answer answer, Question question, bool is_true)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Answer? findedAnswer = _dbSetAnswers.Find(answer.Id);

                    Question? findedQuestion = _dbSetQuestions.Find(question.Id);

                    if (findedAnswer != null && findedQuestion != null)
                    {
                        AnswerQuestion? answerQuestion = _dbSetGeneric.FirstOrDefault(t => t.AnswerId == findedAnswer.Id && t.QuestionId == findedQuestion.Id);
                        if (answerQuestion == null)
                        {
                            answerQuestion = new();
                            answerQuestion.AnswerId = findedAnswer.Id;
                            answerQuestion.QuestionId = findedQuestion.Id;
                            answerQuestion.IsTrue = is_true;
                            _dbSetGeneric.Add(answerQuestion);
                            _dbContext.SaveChanges();
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _dbContext.ChangeTracker.Clear();
                    throw new AddFailedRepositoryException("Произошла ошибка при добавлении записи", ex);
                }
            }
        }

        public void EditAnswerFromQuestion(Answer answer_old, Answer answer_new, Question question, bool is_true)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Answer? findedAnswer = _dbSetAnswers.Find(answer_old.Id);
                    Question? findedQuestion = _dbSetQuestions.Find(question.Id);

                    if (findedAnswer != null && findedQuestion != null)
                    {
                        AnswerQuestion? answerQuestion = _dbSetGeneric.FirstOrDefault(t => t.AnswerId == findedAnswer.Id || t.QuestionId == findedQuestion.Id);
                        if (answerQuestion != null)
                        {
                            answerQuestion.Answer = answer_new;
                            answerQuestion.AnswerId = answer_new.Id;
                            answerQuestion.Question = findedQuestion;
                            answerQuestion.QuestionId = findedQuestion.Id;
                            answerQuestion.IsTrue = is_true;

                            _dbSetGeneric.Update(answerQuestion);
                            _dbContext.SaveChanges();
                            transaction.Commit();
                        }
                    }
                }
                catch
                {
                    transaction.Rollback();
                    _dbContext.ChangeTracker.Clear();
                    throw new EditFailedRepositoryException();
                }
            }
        }

        public void RemoveAnswerFromQuestion(Answer answer, Question question)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Answer? findedAnswer = _dbSetAnswers.Find(answer.Id);
                    Question? findedQuestion = _dbSetQuestions.Find(question.Id);

                    if (findedAnswer != null && findedQuestion != null)
                    {
                        AnswerQuestion? answerQuestion = _dbSetGeneric.FirstOrDefault(t => t.AnswerId == findedAnswer.Id || t.QuestionId == findedQuestion.Id);
                        if (answerQuestion != null)
                        {
                            _dbSetGeneric.Remove(answerQuestion);
                            _dbContext.SaveChanges();
                            transaction.Commit();
                        }
                    }
                }
                catch
                {
                    transaction.Rollback();
                    _dbContext.ChangeTracker.Clear();
                    throw new RemoveFailedRepositoryException();
                }
            }
        }
    }
}
