using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using System;
using TestingApplication.Data.Repositories.Interfaces;
using TestingApplication.Data.Repositories.SQLite;
using TestingApplication.Helpers;
using TestingApplication.ViewModels;
using TestingApplication.ViewModels.Pages;
using TestingApplication.ViewModels.Pages.Database.Viewers;
using TestingApplication.Views;

namespace TestingApplication;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        IServiceProvider services = ConfigureServices();
        var mainViewModel = services.GetRequiredService<MainViewModel>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = mainViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<HistoryRouter>(s => new(t => (ViewModelBase)s.GetRequiredService(t)));

        // Репозитории
        services.AddSingleton<IAnswersRepository, SQLiteAnswersRepository>();
        services.AddSingleton<IAnswerToQuestionsRepository, SQLiteAnswerToQuestionsRepository>();
        services.AddSingleton<IQuestionsRepository, SQLiteQuestionsRepository>();
        services.AddSingleton<IQuestionsTypesRepository, SQLiteQuestionsTypesRepository>();

        // Модели


        // Главное окно
        services.AddSingleton<MainViewModel>();

        // Модели предствления
        services.AddTransient<HomeViewModel>();
        services.AddTransient<DatabaseViewModel>();
        services.AddTransient<AnswersViewModel>();
        services.AddTransient<QuestionsViewModel>();
        services.AddTransient<TestsViewModel>();
        services.AddTransient<AnswerToQuestionsViewModel>();

        return services.BuildServiceProvider();
    }
 }
