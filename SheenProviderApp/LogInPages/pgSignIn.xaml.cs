

using SheenProviderApp.services;

namespace SheenProviderApp.LogInPages;

public partial class pgSignIn : ContentPage
{
	public pgSignIn()
	{
		InitializeComponent();

        enEmail_TextChanged(null, null);

    }

   
    private void enEmail_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(enEmail.Text) || string.IsNullOrEmpty(enPassword.Text))
        {
            btLogin.IsEnabled = false;
        }
        else
            btLogin.IsEnabled = true;
    }

    private async void btLogin_Clicked(object sender, EventArgs e)
    {
        if (!clsValidation.ValidateEmail(enEmail.Text))
        {
            await DisplayAlert("Error", "Please enter a valid email", "Ok");
            return;
        }

        if (enPassword.Text.Length < 8)
        {
            await DisplayAlert("Error", "please enter a valid password", "Ok");
            return;
        }

        clsStore store = await  clsStore.FindStoreByEmailAndPassword(enEmail.Text.Trim(), enPassword.Text.Trim());

        if (store != null)
        {
            if (store.isActive.HasValue)
            {
                clsGlobal.CurrentUser = store;


                Preferences.Default.Remove("Email");
                Preferences.Default.Remove("Password");

                Preferences.Default.Set("Email", store.Email);
                Preferences.Default.Set("Password", store.Password);


                Application.Current.MainPage = new AppShell();
            }
            else
                await DisplayAlert("Error", "your account not active please contact with your admin", "Ok");
        }
        else
        {
            await DisplayAlert("Error", "Email or password not correct please check then try again", "Ok");
        }

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new pgSigningUp());

        Navigation.RemovePage(this);

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AppShell();
    }

}