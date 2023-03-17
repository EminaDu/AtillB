using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.Services.LoginService
{
    internal interface IAuthorizationService
    {
        bool IsAuthorized(Models.User user);
    }
}
