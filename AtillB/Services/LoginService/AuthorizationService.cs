﻿using AtillB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.Services.LoginService
{
    internal class AuthorizationService : IAuthorizationService
    {
        public bool IsAuthorized(User user)
        {
            return user.IsAuthorized;
        }
    }
}
