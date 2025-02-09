using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Interfaces
{
    internal interface IQuestionsType
    {
        Guid Id { get; }
        string Name { get; set; }
    }
}
