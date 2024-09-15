using SheenProviderApp.ViewModel;

namespace SheenProviderApp
{
    public partial class MainPage : ContentPage
    {
        NewOrderViewModel viewModel = new NewOrderViewModel();
        public MainPage()
        {
            InitializeComponent();
        }

      
        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            viewModel.LoadNewOrder();

            refresh.IsRefreshing = false;

        }
    }
}
