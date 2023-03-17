using AtillB.Services.LoginService;
using AtillB.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AtillB.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public string username;
        [ObservableProperty]
        public string password;
        [ObservableProperty]
        public string errorMessage;
        LoginFacade loginFacade;
        
        public MainPageViewModel()
        {
            loginFacade= new LoginFacade();
            ErrorMessage = string.Empty;
        }

        public async Task<bool> SignIn()
        {
            var task = Task.Run(() => loginFacade.Login(Username, Password));
            task.Wait();
            SessionData.User = task.Result;
            if (task.Result != null)
            {
                return true;
            } 
            else
            {
                ErrorMessage = "Wrong username or password";
                return false;
            }
        }

    }
}
