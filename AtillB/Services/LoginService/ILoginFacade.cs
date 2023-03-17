using AtillB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.Services.LoginService
{
    internal interface ILoginFacade
    {
        Task<User> Login(string userName, string password);
        Task<bool> Signup(Models.User user);
    }
}
