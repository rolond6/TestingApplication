using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Helpers.Route
{
    internal class RouteUnregisteredException : Exception
    {
        public RouteUnregisteredException()
        {
        }

        public RouteUnregisteredException(string? message) : base(message)
        {
        }

        public RouteUnregisteredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RouteUnregisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
