

using SheenProviderApp.services;

namespace SheenProviderApp.LogInPages;

public partial class pgSigningUp : ContentPage
{
	public pgSigningUp()
	{
		InitializeComponent();
	}

    private  async void Button_Clicked(object sender, EventArgs e)
    {



        if (string.IsNullOrEmpty(enEmail.Text) || string.IsNullOrEmpty(enPassword.Text) ||
             string.IsNullOrEmpty(enName.Text) || string.IsNullOrEmpty(enPhone.Text) ||
             string.IsNullOrEmpty(EnRePassword.Text))
        {
            await DisplayAlert("Error", "Please fill all fields before continue", "Ok");
            return;
        }

        if (await clsStore.IsStoreExistByEmail(enEmail.Text.Trim().ToLower()))
        {
            await DisplayAlert("Error", "Please enter another email this email is Exist", "Ok");
            return;
        }

        if (await clsStore.IsStoreExistByPhone(enPhone.Text.Trim()))
        {
            await DisplayAlert("Error", "Please enter another phone this phone is Exist", "Ok");
            return;
        }

        if (enPhone.Text.Trim().Length < 9 || !enPhone.Text.StartsWith("5"))
        {
            await DisplayAlert("Error", "Please enter a valid phone number", "Ok");
            return;
        }

        //if (enPhone.Text.Any(char.IsDigit))
        //{
        //    await DisplayAlert("Error", "Please enter a valid phone number", "Ok");
        //    return;
        //}

        if (enPassword.Text.Length < 8)
        {
            await DisplayAlert("Error", "please enter a valid password", "Ok");
            return;
        }

        if (!ckTerms.IsChecked)
        {
            await DisplayAlert("Error", "Please check on Accept Conditions to continue", "Ok");
            return;
        }

        if (enPassword.Text != EnRePassword.Text)
        {
            await DisplayAlert("Error", "Password not matched", "Ok");
            return;
        }

        //Check E-mail exsist
        //Page for success register


        clsStore store = new clsStore(null, enName.Text, enCommercialNumber.Text,
            enLocation.Text, enPhoto.Text, enPhone.Text, enEmail.Text, enPassword.Text, 0, false);

        clsStore NewStore =  await clsStore.AddStore(store);

        if (NewStore != null)
        {
            clsGlobal.CurrentUser = NewStore;

            await DisplayAlert("Done", "your account created successfully", "Ok");

            Preferences.Default.Remove("Email");
            Preferences.Default.Remove("Password");

            Preferences.Default.Set("Email", NewStore.Email);
            Preferences.Default.Set("Password", NewStore.Password);

            await Navigation.PushAsync(new pgSignIn());

            Navigation.RemovePage(this);
        }
        else
        {
            await DisplayAlert("Error", "Can't Sign up this user", "Ok");
            return;
        }


    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new pgSignIn());

        Navigation.RemovePage(this);
    }
}