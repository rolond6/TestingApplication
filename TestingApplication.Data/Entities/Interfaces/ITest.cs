using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Interfaces
{
    public interface ITest : IIdentifiableEntity
    {
        string Name { get; set; }
        string? Description { get; set; }
        int Timer { get; set; }
    }
}
