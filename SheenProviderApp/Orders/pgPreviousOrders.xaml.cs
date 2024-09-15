
using SheenProviderApp.ViewModel;

namespace SheenProviderApp.Orders;

public partial class pgPreviousOrders : ContentPage
{

    NewOrderViewModel newOrderView = new NewOrderViewModel();
    public pgPreviousOrders()
	{
		InitializeComponent();

    }
   

    private void refresh_Refreshing(object sender, EventArgs e)
    {

        newOrderView.LoadPreviousOrder();

        refresh.IsRefreshing = false;
    }
}