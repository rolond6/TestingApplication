using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Repositories.Exceptions
{
    internal class RemoveFailedRepositoryException : RepositoryException
    {
        public RemoveFailedRepositoryException()
        {
        }

        public RemoveFailedRepositoryException(string? message) : base(message)
        {
        }

        public RemoveFailedRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
