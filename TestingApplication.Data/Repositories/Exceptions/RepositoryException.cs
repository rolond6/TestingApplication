using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Data.Repositories.Exceptions
{
    internal class RepositoryException : Exception
    {
        public RepositoryException()
        {
        }

        public RepositoryException(string? message) : base(message)
        {
        }

        public RepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
