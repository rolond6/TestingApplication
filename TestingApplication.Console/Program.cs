using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestingApplication.Data.DataContexts;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Entities.Interfaces;
using TestingApplication.Data.Repositories.DB;
using TestingApplication.Data.Repositories.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        {
            Test test;
            Question question;
            using (var dbContext = SQLiteDataContext.Create())
            {
                var testRepository = new DbTestsRepository(dbContext);
                test = new Test() { Name = "Тестирование", Description = "Описание", Timer = 30 };
                testRepository.Add(test);
            }

            using (var dbContext = SQLiteDataContext.Create())
            {
                var questionRepository = new DbQuestionsRepository(dbContext);
                question = new Question()
                {
                    Name = "Вопрос",
                    Description = "Описание",
                    TestId = test.Id,
                    TypeId = QuestionsType.CHOICE_ONE.Id,
                };
                questionRepository.Add(question);
            }

            using (var dbContext = SQLiteDataContext.Create())
            {
                var answerRepository = new DbAnswersRepository(dbContext);
                answerRepository.Add(new Answer() { Name = "Ответ 1", Description = "Описание", QuestionId = question.Id, IsCorrect = true });
                answerRepository.Add(new Answer() { Name = "Ответ 2", Description = "Описание", QuestionId = question.Id });
                answerRepository.Add(new Answer() { Name = "Ответ 3", Description = "Описание", QuestionId = question.Id });
                answerRepository.Add(new Answer() { Name = "Ответ 4", Description = "Описание", QuestionId = question.Id });
            }
        }


        using (var dbContext = SQLiteDataContext.Create())
        {
            var testRepository = new DbTestsRepository(dbContext);
            IEnumerable<Test> testList = testRepository.GetAll();
            Console.WriteLine("Тесты:");
            foreach (Test test in testList)
            {
                Console.WriteLine("Тест: " + test.Name);
                Console.WriteLine("\tВопросы:");
                foreach (Question question in test.Questions)
                {
                    Console.WriteLine("\tВопрос: " + question.Name);
                    Console.WriteLine("\t\tОтветы:");
                    foreach (Answer answer in question.Answers)
                    {
                        Console.WriteLine("\t\tОтвет: " + answer.Name + "- Правильный: " + answer.IsCorrect);
                    }
                }
            }
        }
    }
}