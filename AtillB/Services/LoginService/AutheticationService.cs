using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.Services.LoginService
{
    internal class AutheticationService : IAutheticationService
    {
        public async Task<Models.User> Authenticate(string userName, string Password)
        {
            var user = await DatabaseService.Shared().Login(userName, Password);

            return user;
        }
    }
}
