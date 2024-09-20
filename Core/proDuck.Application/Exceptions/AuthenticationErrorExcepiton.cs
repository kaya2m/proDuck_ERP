using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Exceptions
{
   public class AuthenticationErrorExcepiton : Exception
    {
        public AuthenticationErrorExcepiton() : base("Authentication failed")
        {
        }

        public AuthenticationErrorExcepiton(string message) : base(message)
        {
        }

        public AuthenticationErrorExcepiton(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
