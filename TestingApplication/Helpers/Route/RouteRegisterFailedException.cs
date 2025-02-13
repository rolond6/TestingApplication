using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Helpers.Route
{
    internal class RouteRegisterFailedException : Exception
    {
        public RouteRegisterFailedException()
        {
        }

        public RouteRegisterFailedException(string? message) : base(message)
        {
        }

        public RouteRegisterFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
