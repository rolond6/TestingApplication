using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Models;

namespace TestingApplication.ViewModels.Pages.Database.Viewers
{
    internal class QuestionsViewModel : ViewModelBase
    {
        private QuestionsModel _model;

        public QuestionsViewModel(QuestionsModel model)
        {
            _model = model;
        }
    }
}
