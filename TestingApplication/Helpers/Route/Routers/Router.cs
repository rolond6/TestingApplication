using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.ViewModels;

namespace TestingApplication.Helpers.Route.Routers
{
    public class Router
    {
        private RouteDirectory _routes;
        private ViewModelBase _currentViewModel = default!;
        protected readonly Func<Type, ViewModelBase> CreateViewModel;
        public event Action<ViewModelBase>? CurrentViewModelChanged;

        public Router(Func<Type, ViewModelBase> createViewModel)
        {
            _routes = new RouteDirectory();
            ViewModelRouter.RegisterViewModels(_routes);

            CreateViewModel = createViewModel;
        }

        protected ViewModelBase CurrentViewModel
        {
            set
            {
                if (value == _currentViewModel) return;
                _currentViewModel = value;
                OnCurrentViewModelChanged(value);
            }
        }

        private void OnCurrentViewModelChanged(ViewModelBase viewModel)
        {
            CurrentViewModelChanged?.Invoke(viewModel);
        }

        public virtual ViewModelBase GoTo(Type type)
        {
            var viewModel = InstantiateViewModel(type);
            CurrentViewModel = viewModel;
            return viewModel;
        }

        public virtual ViewModelBase GoTo(string name)
        {
            Type type = _routes.Get(name);
            var viewModel = InstantiateViewModel(type);
            CurrentViewModel = viewModel;
            return viewModel;
        }
        protected ViewModelBase InstantiateViewModel(Type type)
        {
            return (ViewModelBase)Convert.ChangeType(CreateViewModel(type), type);
        }

    }
}
