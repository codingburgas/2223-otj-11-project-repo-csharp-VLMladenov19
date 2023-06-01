namespace wm.maui
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void OnLogInButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LogInPage());
        }

        private void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}