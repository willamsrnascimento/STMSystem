using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMComunication.Dtos
{
    public record UserRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public string NormalizeUserName()
        {
            return Email.Substring(0, Email.IndexOf("@"));
        }

        
    }
}
