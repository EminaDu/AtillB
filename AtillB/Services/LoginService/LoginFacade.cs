using AtillB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AtillB.Services.LoginService.LoginFacade;

namespace AtillB.Services.LoginService
{
    internal class LoginFacade : ILoginFacade
    {
         private readonly IValidationService _validationService;
            private readonly IAutheticationService _autheticationService;
            private readonly IAuthorizationService _authorizationService;

            public LoginFacade()
            {
                _validationService = new ValidationService();
                _authorizationService = new AuthorizationService();
                _autheticationService = new AutheticationService();
            }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _autheticationService.Authenticate(userName, password);
            if (user != null
                && _authorizationService.IsAuthorized(user))
            {
                return user;
            }
            return null;
        }

        public async Task<bool> Signup(User user)
        {
            if (_validationService.IsUserValid(user))
            {
                await DatabaseService.Shared().SignUp(user);
                return true;
            }
            return false;
        }
    }
}
