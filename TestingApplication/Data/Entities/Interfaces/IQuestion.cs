using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Interfaces
{
    internal interface IQuestion
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int? TestId { get; set; }
        int? TypeId { get; set; }
    }
}
