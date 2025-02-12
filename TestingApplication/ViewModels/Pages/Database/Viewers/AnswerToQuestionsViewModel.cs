using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.Models;

namespace TestingApplication.ViewModels.Pages.Database.Viewers
{
    internal class AnswerToQuestionsViewModel:ViewModelBase
    {
        AnswerToQuestionsModel _model;

        public AnswerToQuestionsViewModel(AnswerToQuestionsModel model)
        {
            _model = model;
        }
    }
}
