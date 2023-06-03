using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Windows.Input;
using wm.bll;
using wm.dal.Models;
using wm.util;

namespace wm.maui
{
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();

            BindingContext = new RegisterPage();
        }

        private void OnContinueButtonClicked(object sender, EventArgs e)
        {
            string username = entryUsername.Text;
            string password = entryPassword.Text;

            if(username.IsNullOrEmpty())
            {
                entryUsername.Margin = new Thickness(0, 0, 0, 10);
                entryPassword.Margin = new Thickness(0, 10, 0, 0);
                labelUsernameError.Text = "Username can't be empty!";
                return;
            }

            if (!UserService.VerifyUser(username, password))
            {
                entryPassword.Margin = new Thickness(0, 0, 0, 10);
                buttonContinue.Margin = new Thickness(0, 10, 0, 0);
                labelError.Text = "Wrong Username or Password";
            }
            else
            {
                User? loggedUser = UserService.GetUserByUsername(username);
                UserLog.LoggedUser = loggedUser;
                Navigation.PushAsync(new MainPage());
            }
        }

        void RegisterLabelTapped(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}