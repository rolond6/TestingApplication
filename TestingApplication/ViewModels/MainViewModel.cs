using ReactiveUI;
using System;
using System.Reactive;
using TestingApplication.Helpers.Route.Routers;
using TestingApplication.ViewModels.Pages;

namespace TestingApplication.ViewModels;

public class MainViewModel : ViewModelBase
{
    private bool _isPaneOpen;
    private ViewModelBase? _currentPage;
    private HistoryRouter? _router;

    public bool IsPaneOpen
    {
        get => _isPaneOpen;
        set => this.RaiseAndSetIfChanged(ref _isPaneOpen, value);
    }

    public ViewModelBase? CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }
    public ReactiveCommand<Unit, Unit> PaneOpenCloseCommand { get; }
    public ReactiveCommand<string, Unit> OpenPage { get; }

    public MainViewModel()
    {
        PaneOpenCloseCommand = ReactiveCommand.Create(ExecutePaneOpenCloseCommand);
        OpenPage = ReactiveCommand.Create<string>(ExecuteOpenPage);
    }

    public MainViewModel(HistoryRouter? router) : this()
    {
        _router = router;

        if (_router != null)
        {
            _router.CurrentViewModelChanged += (viewModel) => CurrentPage = viewModel;
            _router.GoTo("Home");
        }
    }

    private void ExecuteOpenPage(string pageName)
    {
        if (_router != null)
        {
            _router.GoTo(pageName);
        }
    }

    private void ExecutePaneOpenCloseCommand()
    {
        IsPaneOpen = !_isPaneOpen;
    }
}
