
using SheenProviderApp.ViewModel;

namespace SheenProviderApp.Orders;

public partial class pgOrder : ContentPage
{


    NewOrderViewModel viewModel = new NewOrderViewModel();
    public pgOrder()
    {
        InitializeComponent();

    }

    private void RefreshView_Refreshing(object sender, EventArgs e)
    {
        viewModel.LoadPreviousOrder();

        refresh.IsRefreshing = false;
    }
}