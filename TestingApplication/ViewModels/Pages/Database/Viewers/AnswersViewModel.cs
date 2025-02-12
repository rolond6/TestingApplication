using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Models;

namespace TestingApplication.ViewModels.Pages.Database.Viewers
{
    internal class AnswersViewModel : ViewModelBase
    {
        AnswersModel _model;

        public AnswersViewModel(AnswersModel model)
        {
            _model = model;
            _model.TestAdd();
        }
    }
}
