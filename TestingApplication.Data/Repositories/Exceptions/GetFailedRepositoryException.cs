using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Repositories.Exceptions
{
    internal class GetFailedRepositoryException : RepositoryException
    {
        public GetFailedRepositoryException()
        {
        }

        public GetFailedRepositoryException(string? message) : base(message)
        {
        }

        public GetFailedRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
