﻿using AtillB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.Services.LoginService
{
    internal class ValidationService : IValidationService
    {
        public bool IsUserValid(User user)
        {
            //todo validate user
            return true;
        }
    }
}
