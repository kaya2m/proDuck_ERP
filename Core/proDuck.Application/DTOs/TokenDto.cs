using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.DTOs
{
    public class TokenDto
    {
        public  string AccessToken { get; set; }
        public  DateTime Expiration { get; set; }
    }
}
