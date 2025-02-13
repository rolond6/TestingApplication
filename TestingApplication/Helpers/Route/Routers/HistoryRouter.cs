using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.ViewModels;

namespace TestingApplication.Helpers.Route.Routers
{
    public class HistoryRouter : Router
    {

        private int _historyIndex = -1;
        private List<ViewModelBase> _history = new();
        private readonly uint _historyMaxSize = 100;

        public bool HasNext => _history.Count > 0 && _historyIndex < _history.Count - 1;
        public bool HasPrev => _historyIndex > 0;

        public HistoryRouter(Func<Type, ViewModelBase> createViewModel) : base(createViewModel)
        {
        }

        // pushState
        // popState
        // replaceState

        public void Push(ViewModelBase item)
        {
            if (HasNext)
            {
                _history = _history.Take(_historyIndex + 1).ToList();
            }
            _history.Add(item);
            _historyIndex = _history.Count - 1;
            if (_history.Count > _historyMaxSize)
            {
                _history.RemoveAt(0);
            }
        }

        public ViewModelBase? Go(int offset = 0)
        {
            if (offset == 0)
            {
                return default;
            }

            var newIndex = _historyIndex + offset;
            if (newIndex < 0 || newIndex > _history.Count - 1)
            {
                return default;
            }
            _historyIndex = newIndex;
            var viewModel = _history.ElementAt(_historyIndex);
            CurrentViewModel = viewModel;
            return viewModel;
        }

        public ViewModelBase? Back() => HasPrev ? Go(-1) : default;

        public ViewModelBase? Forward() => HasNext ? Go(1) : default;

        public override ViewModelBase GoTo(Type type)
        {
            ViewModelBase viewModel = base.GoTo(type);
            Push(viewModel);
            return viewModel;
        }
        public override ViewModelBase GoTo(string name)
        {
            ViewModelBase viewModel = base.GoTo(name);
            Push(viewModel);
            return viewModel;
        }
    }
}
