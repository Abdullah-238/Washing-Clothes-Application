
namespace SheenProviderApp.FlyoutPages;

public partial class pgProfile : ContentPage
{
	public pgProfile()
	{
		InitializeComponent();
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        if (clsGlobal.CurrentUser != null)
        {
            enPhone.Text = clsGlobal.CurrentUser.Phone;
            enEmail.Text = clsGlobal.CurrentUser.Email;
            enName.Text = clsGlobal.CurrentUser.StoreName;
            enCommercialNumber.Text = clsGlobal.CurrentUser.CommercialNumber;
            enLocation.Text = clsGlobal.CurrentUser.Location;
        }
    }

    private async void btCreate_Clicked(object sender, EventArgs e)
    {
        //clsStore Store = clsStore.Find(clsGlobal.CurrentUser.StoreID);



        //if (string.IsNullOrEmpty(enEmail.Text) || string.IsNullOrEmpty(enName.Text) || string.IsNullOrEmpty(enPhone.Text))
        //{
        //    await DisplayAlert("Error", "Fill All fields before continue", "Ok");
        //    return;
        //}

        //if (clsCustomer.IsExistByEmail(enEmail.Text.Trim()) && Store.Email != enEmail.Text)
        //{
        //    await DisplayAlert("Error", "Please enter another email this email is Exist", "Ok");
        //    return;
        //}

        //if (clsCustomer.IsExistByPhone(enPhone.Text.Trim()) && Store.Phone != enPhone.Text)
        //{
        //    await DisplayAlert("Error", "Please enter another phone this phone is Exist", "Ok");
        //    return;
        //}

        //if (enPhone.Text.Trim().Length < 9 || !enPhone.Text.StartsWith("5"))
        //{
        //    await DisplayAlert("Error", "Please enter a valid phone number", "Ok");
        //    return;
        //}


        //if (enPassword.Text.Length < 8)
        //{
        //    await DisplayAlert("Error", "please enter a valid password", "Ok");
        //    return;
        //}

        //if (!ckTerms.IsChecked)
        //{
        //    await DisplayAlert("Error", "Please check on Accept Conditions to continue", "Ok");
        //    return;
        //}





        //if (Store != null)
        //{
        //    Store.Phone = enPhone.Text.Trim();
        //    Store.Email = enEmail.Text.Trim();
        //    Store.StoreName = enName.Text.Trim();
        //    Store.Location = enLocation.Text.Trim();
        //    Store.CommercialNumber = enCommercialNumber.Text.Trim();
        //   // Store.Phone = enPhone.Text.Trim();


        //    if (!string.IsNullOrEmpty(enPassword.Text))
        //    {
        //        if (enPassword.Text.Length < 8)
        //        {
        //            await DisplayAlert("Error", "Please enter a valid password", "Ok");
        //            return;
        //        }
        //        else
        //            Store.Password = clsUtil.ComputeHash(enPassword.Text.Trim());
        //    }
        //}

        //if (Store.Save())
        //{
        //    clsGlobal.CurrentUser = clsStore.Find(Store.StoreID);

        //    await DisplayAlert("Done", "Data Saved Successfully", "Ok");
        //}
        //else
        //{
        //    await DisplayAlert("Error", "Data Saved Failed", "Ok");
        //}

    }

}