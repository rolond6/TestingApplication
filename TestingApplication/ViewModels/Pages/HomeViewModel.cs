using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Helpers.Route.Routers;

namespace TestingApplication.ViewModels.Pages
{
    internal class HomeViewModel: ViewModelBase
    {
        private HistoryRouter? _router;

        public ReactiveCommand<string, Unit> OpenPage { get; }

        public HomeViewModel()
        {
            OpenPage = ReactiveCommand.Create<string>(ExecuteOpenPage);
        }

        public HomeViewModel(HistoryRouter? router) : this()
        {
            _router = router;
        }

        private void ExecuteOpenPage(string pageName)
        {
            if (_router != null)
            {
                _router.GoTo(pageName);
            }
        }
    }
}
