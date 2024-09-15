using SheenProviderApp.LogInPages;

namespace SheenProviderApp.FlyoutPages;

public partial class pgSetting : ContentPage
{
    public pgSetting()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        Preferences.Default.Remove("Email");
        Preferences.Default.Remove("Password");


        Application.Current.MainPage =  new NavigationPage(new pgIntro());
    }
}