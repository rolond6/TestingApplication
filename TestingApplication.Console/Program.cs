using TestingApplication.Data.DataContexts;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Entities.Interfaces;
using TestingApplication.Data.Repositories.DB;
using TestingApplication.Data.Repositories.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        SQLiteDataContext dataContext = new SQLiteDataContext();

        IAnswersRepository answersRepository = new DbAnswersRepository(dataContext);

    }
}