using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Helpers;
using TestingApplication.ViewModels.Pages.Database.Viewers;

namespace TestingApplication.ViewModels.Pages
{
    internal class DatabaseViewModel: ViewModelBase
    {
        private HistoryRouter? _router;

        public ReactiveCommand<string, Unit> OpenPage { get; }

        public DatabaseViewModel()
        {
            OpenPage = ReactiveCommand.Create<string>(ExecuteOpenPage);
        }

        public DatabaseViewModel(HistoryRouter? router) : this()
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
