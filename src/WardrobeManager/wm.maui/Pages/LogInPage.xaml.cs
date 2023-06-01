using wm.bll;

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

            if(!UserService.VerifyUser(username, password))
            {
                entryPassword.Margin = new Thickness(0, 0, 0, 20);
                buttonContinue.Margin = new Thickness(0, 20, 0, 0);
                labelError.Text = "Wrong Username or Password";
            }
            else
            {
                Navigation.PushAsync(new MainPage());
            }
        }

        private void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}