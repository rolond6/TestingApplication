using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Data.Entities;
using TestingApplication.Data.Entities.Interfaces;
using TestingApplication.Models;

namespace TestingApplication.ViewModels.Pages
{
    internal class TestLobbyViewModel: ViewModelBase
    {
        private TestLobbyModel _model;
        private ObservableCollection<Test> _tests;

        ObservableCollection<Test> Tests
        {
            get => _tests; 
            set => this.RaiseAndSetIfChanged(ref _tests, value); 
        }

        public ReactiveCommand<Unit, Unit> LoadCommand { get; }
        public ReactiveCommand<Test?, Unit> GoCommand { get; }
        public ReactiveCommand<Unit, Unit> CreateCommand { get; }
        public ReactiveCommand<Test?, Unit> EditCommand { get; }
        public ReactiveCommand<Test?, Unit> DeleteCommand { get; }
        public TestLobbyViewModel()
        {
            _model = new();
            _tests = new();

            LoadCommand = ReactiveCommand.CreateFromTask(ExecuteLoadCommand);
            GoCommand = ReactiveCommand.CreateFromTask<Test?>(ExecuteGoCommand);
            CreateCommand = ReactiveCommand.CreateFromTask(ExecuteCreateCommand);
            EditCommand = ReactiveCommand.CreateFromTask<Test?>(ExecuteEditCommand);
            DeleteCommand = ReactiveCommand.CreateFromTask<Test?>(ExecuteDeleteCommand);
        }

        public TestLobbyViewModel(TestLobbyModel model) : this()
        {
            _model = model;
        }

        private async Task ExecuteLoadCommand()
        {
            Tests = new(await _model.GetTestList());
        }

        private async Task ExecuteGoCommand(Test? test)
        {
            if (test !=null)
                await _model.StartTest(test);
        }

        private async Task ExecuteCreateCommand()
        {
            await _model.CreateTest();
        }

        private async Task ExecuteEditCommand(Test? test)
        {
            if (test != null)
                await _model.EditTest(test);
        }

        private async Task ExecuteDeleteCommand(Test? test)
        {
            if (test != null)
                await _model.DeleteTest(test);
        }
    }
}
