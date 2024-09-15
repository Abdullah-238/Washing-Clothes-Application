
using SheenProviderApp.FlyoutPages;
using SheenProviderApp.LogInPages;
using SheenProviderApp.Orders;
using SheenProviderApp.services;

namespace SheenProviderApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage =  new NavigationPage(new pgIntro());

           
        }


        async void _LoginOption()
        {
            if (Preferences.ContainsKey("Email") && Preferences.ContainsKey("Password"))
            {
                string Email = Preferences.Default.Get("Email", "");
                string Password = Preferences.Default.Get("Password", "");

                clsStore store = await clsStore.FindStoreByEmailAndPassword(Email, Password);

                if (store != null)
                {
                    clsGlobal.CurrentUser = store;
                    Application.Current.MainPage = new AppShell();
                }
                else
                    MainPage = new NavigationPage(new pgIntro());
            }
            else
                MainPage = new NavigationPage(new pgIntro());

        }

    }
}
