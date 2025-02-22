﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using TestingApplication.Data.Repositories.Interfaces;
using TestingApplication.Data.Repositories.DB;
using TestingApplication.Helpers.Route.Routers;
using TestingApplication.ViewModels;
using TestingApplication.ViewModels.Pages;
using TestingApplication.Views;
using TestingApplication.Models;
using TestingApplication.Services.Session;
using TestingApplication.ViewModels.Pages.Testing;
using Microsoft.Extensions.DependencyInjection;
using TestingApplication.Data.DataContexts;
using Microsoft.EntityFrameworkCore;

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

        // База данных и репозитории
        services.AddScoped<DbContext,SQLiteDataContext>();
        services.AddSingleton<IAnswersRepository, DbAnswersRepository>();
        services.AddSingleton<IAnswerQuestionRepository, DbAnswerQuestionRepository>();
        services.AddSingleton<IQuestionsRepository, DbQuestionsRepository>();
        services.AddSingleton<ITestsRepository, DbTestsRepository>();
        services.AddSingleton<IQuestionsTypesRepository, DbQuestionsTypesRepository>();

        // Сервисы
        services.AddSingleton<ITestSession, LocalTestSession>();

        // Модели
        services.AddSingleton<TestLobbyModel>();

        // Главное окно
        services.AddSingleton<MainViewModel>();

        // Модели предствления
        services.AddTransient<HomeViewModel>();
        services.AddTransient<TestLobbyViewModel>();
        services.AddTransient<TestViewModel>();
        services.AddTransient<QuestionViewModel>();
        services.AddTransient<ResultViewModel>();

        return services.BuildServiceProvider();
    }
 }
