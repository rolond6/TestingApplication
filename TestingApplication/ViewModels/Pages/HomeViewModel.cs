﻿using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Helpers;

namespace TestingApplication.ViewModels.Pages
{
    internal class HomeViewModel: ViewModelBase
    {
        private HistoryRouter<ViewModelBase>? _router;

        public ReactiveCommand<string, Unit> OpenPage { get; }

        public HomeViewModel()
        {
            OpenPage = ReactiveCommand.Create<string>(ExecuteOpenPage);
        }

        public HomeViewModel(HistoryRouter<ViewModelBase>? router) : this()
        {
            _router = router;
        }

        private void ExecuteOpenPage(string pageName)
        {
            if (_router != null)
            {
                switch (pageName)
                {
                    case "Home":
                        _router.GoTo<HomeViewModel>();
                        break;
                    case "Database":
                        _router.GoTo<DatabaseViewModel>();
                        break;
                }
            }
        }
    }
}
