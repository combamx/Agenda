using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models.Request
{
    public class UserRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
