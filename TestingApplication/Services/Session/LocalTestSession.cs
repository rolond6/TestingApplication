using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Repositories.Interfaces;

namespace TestingApplication.Services.Session
{
    internal class LocalTestSession: ITestSession
    {
        // TODO ** Реализовать возможность выбора вариантов ответа и хранения выбранных ответов
        private Test? _test;

        private int _currentQuestionIndex;
        private Question? _currentQuestion;
        private List<Question>? _questions;

        private Mode _mode;

        private IAnswersRepository _answersRepository;
        private IAnswerToQuestionsRepository _answersToQuestionsRepository;
        private IQuestionsRepository _questionsRepository;
        private IQuestionsTypesRepository _questionsTypesRepository;

        public LocalTestSession(IAnswersRepository answersRepository, IAnswerToQuestionsRepository answersToQuestionsRepository, IQuestionsRepository questionsRepository, IQuestionsTypesRepository questionsTypesRepository)
        {
            _answersRepository = answersRepository;
            _answersToQuestionsRepository = answersToQuestionsRepository;
            _questionsRepository = questionsRepository;
            _questionsTypesRepository = questionsTypesRepository;
        }

        public void Start(Test test, bool edit_mode = false)
        {
            _test = test;
            _mode = edit_mode ? Mode.Editing : Mode.Testing;
            
            InitializeTest(test);
        }

        public void NextQuestion()
        {
            if (_questions != null)
            {
                if (_currentQuestionIndex < _questions.Count - 1)
                {
                    _currentQuestion = _questions[++_currentQuestionIndex];
                    GetTestAnswers(_currentQuestion);
                }
            }
        }

        public void PrevQuestion()
        {
            if (_questions != null)
            {
                if (_currentQuestionIndex > 0)
                {
                    _currentQuestion = _questions[--_currentQuestionIndex];
                    GetTestAnswers(_currentQuestion);
                }
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        private void InitializeTest(Test test)
        {
            _questions = GetTestQuestions(test);
        }

        private List<Question> GetTestQuestions(Test test)
        {
            return new(_questionsRepository.GetAll(p => p.TestId == test.Id));
        }
        private List<Answer> GetTestAnswers(Question question)
        {
            // TODO ** Реализовать подгрузку ответов на вопросы
            return new List<Answer>();
        }

        enum Mode
        {
            Testing,
            Editing
        }
    }

}
