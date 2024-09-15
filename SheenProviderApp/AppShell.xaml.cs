using SheenProviderApp.FlyoutPages;
using SheenProviderApp.LogInPages;

namespace SheenProviderApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("Profile", typeof(pgProfile));
            Routing.RegisterRoute("SignIn", typeof(pgSignIn));
            Routing.RegisterRoute("SignUp", typeof(pgSigningUp));


            ShellPage.BindingContext = clsGlobal.CurrentUser;
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            //AppShell.Current.GoToAsync("Profile");
        }
    }
}
