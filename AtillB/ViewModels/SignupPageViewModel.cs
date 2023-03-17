using AtillB.Services.LoginService;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.ViewModels
{
    internal partial class SignupPageViewModel: ObservableObject
    {
        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string surname;

        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;
        LoginFacade loginFacade;

        public SignupPageViewModel() 
        {
            loginFacade = new LoginFacade();
        }

        public async Task<bool> TrySignUp()
        {
            Models.User user = new();
            user.Id = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            user.Username = Username;
            user.Password = Password;
            user.Name = Name;
            user.Surname = Surname;
            var task = await loginFacade.Signup(user);
            return task;
        }
    }
}
