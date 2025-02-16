using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Repositories.Exceptions
{
    internal class AddFailedRepositoryException : RepositoryException
    {
        public AddFailedRepositoryException()
        {
        }

        public AddFailedRepositoryException(string? message) : base(message)
        {
        }

        public AddFailedRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
