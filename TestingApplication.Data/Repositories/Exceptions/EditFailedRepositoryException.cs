using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Repositories.Exceptions
{
    internal class EditFailedRepositoryException : RepositoryException
    {
        public EditFailedRepositoryException()
        {
        }

        public EditFailedRepositoryException(string? message) : base(message)
        {
        }

        public EditFailedRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
