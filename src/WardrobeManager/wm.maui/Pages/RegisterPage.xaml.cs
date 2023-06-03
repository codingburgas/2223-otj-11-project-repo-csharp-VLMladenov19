using wm.bll;
using wm.dal.Models;
using wm.util;

namespace wm.maui;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
    }

    private void OnContinueButtonClicked(object sender, EventArgs e)
    {
        string username = entryUsername.Text;
        string password = entryPassword.Text;
        string firstName = entryFirstName.Text;
        string lastName = entryLastName.Text;
        string email = entryEmail.Text;


        UserService.RegisterUser(username, password, firstName, lastName, email);

        User? loggedUser = UserService.GetUserByUsername(username);
        UserLog.LoggedUser = loggedUser;
        Navigation.PushAsync(new MainPage());
    }

    void LogInLabelTapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new LogInPage());
    }
}