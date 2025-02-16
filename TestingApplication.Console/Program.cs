using TestingApplication.Data.DataContexts;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Entities.Interfaces;
using TestingApplication.Data.Repositories.DB;
using TestingApplication.Data.Repositories.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        
        using (var dataContext = new SQLiteDataContext())
        {
            IAnswersRepository answersRepository = new DbAnswersRepository(dataContext);

            try
            {
                answersRepository.Add(new Answer() { Name = "AnswerOne", Description = "Description Answer One" });
                answersRepository.Add(new Answer() { Name = "AnswerTwo", Description = "Description Answer Two" });
                answersRepository.Add(new Answer() { Name = "AnswerThree", Description = "Description Answer Three" });
                answersRepository.Add(new Answer() { Name = "AnswerFour", Description = "Description Answer Four" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(answersRepository.GetAll());
            Console.WriteLine(answersRepository.GetAll().Count());
        }

        using (var dataContext = new SQLiteDataContext())
        {
            IQuestionsRepository questionsRepository = new DbQuestionsRepository(dataContext);

            try
            {
                questionsRepository.Add(new Question() { Name = "Question", Description = "Description Question" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(questionsRepository.GetAll());
            Console.WriteLine(questionsRepository.GetAll().Count());
        }

        using (var dataContext = new SQLiteDataContext())
        {
            IAnswerQuestionRepository answerQuestionRepository = new DbAnswerQuestionRepository(dataContext);
            IQuestionsRepository questionsRepository = new DbQuestionsRepository(dataContext);
            IAnswersRepository answersRepository = new DbAnswersRepository(dataContext);

            try
            {
                foreach (Question question in questionsRepository.GetAll())
                {
                    int last = 1;
                    foreach (Answer answer in answersRepository.GetAll())
                    {
                        answerQuestionRepository.AddAnswerToQuestion(answer, question, last > 0 ? true : false);
                        if (last > 0)
                            last--;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        using (var dataContext = new SQLiteDataContext())
        {
            IAnswerQuestionRepository answerQuestionRepository = new DbAnswerQuestionRepository(dataContext);
            IQuestionsRepository questionsRepository = new DbQuestionsRepository(dataContext);

            foreach (Question question in questionsRepository.GetAll())
            {
                foreach (var keyPairs in answerQuestionRepository.GetAnswersFromQuestion(question))
                {
                    Console.WriteLine(keyPairs.Key.Name + " | Правильный: " + keyPairs.Value);
                }
            }
            Console.ReadLine();
        }
    }
}