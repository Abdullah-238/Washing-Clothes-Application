namespace SheenProviderApp.LogInPages;

public partial class pgIntro : ContentPage
{
	public pgIntro()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new pgSigningUp());

        //await AppShell.Current.GoToAsync("SignUp");

    }

    private async void btLogin_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new pgSignIn());

        //await AppShell.Current.GoToAsync("SignIn");

         //Application.Current.MainPage = new AppShell();

    }
}