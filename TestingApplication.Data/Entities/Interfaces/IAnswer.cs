using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Interfaces
{
    public interface IAnswer
    {
        int Id { get; set; }
        string Name { get; set; }
        string? Description { get; set; }

    }
}
