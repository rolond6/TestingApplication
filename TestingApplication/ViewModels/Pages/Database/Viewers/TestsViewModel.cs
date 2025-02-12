using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Models;

namespace TestingApplication.ViewModels.Pages.Database.Viewers
{
    internal class TestsViewModel: ViewModelBase
    {
        private TestsModel _model;

        public TestsViewModel(TestsModel model)
        {
            _model = model;
        }
    }
}
