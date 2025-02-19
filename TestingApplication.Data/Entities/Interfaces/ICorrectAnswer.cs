using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Interfaces
{
    public interface ICorrectAnswer: IAnswer
    {
        bool IsCorrect { get; set; }
    }
}
