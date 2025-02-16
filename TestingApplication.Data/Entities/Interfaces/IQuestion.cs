using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Entities.Interfaces
{
    public interface IQuestion : IIdentifiableEntity
    {
        string Name { get; set; }
        string Description { get; set; }
        byte[]? TestId { get; set; }
        byte[]? TypeId { get; set; }
    }
}
