using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Exceptions
{
    public class UserCreateFailedExcepiton : Exception
    {
        public UserCreateFailedExcepiton()
        {
            
        }

        public UserCreateFailedExcepiton(string message) : base("Kullanıcı oluşturulurken beklenmeyen bşr hatayla karşılşıldı")
        {
        }

        public UserCreateFailedExcepiton(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
