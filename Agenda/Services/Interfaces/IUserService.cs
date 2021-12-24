using Agenda.Models;
using Agenda.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Services.Interfaces
{
    public interface IUserService
    {
        UserRequest Auth(AuthRequest model);
    }
}
