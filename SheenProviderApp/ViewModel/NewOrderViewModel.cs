
using SheenProviderApp.services.OrdersServices;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SheenProviderApp.ViewModel
{
    public class NewOrderViewModel : INotifyPropertyChanged
    {
        public ICommand AcceptOrder { get; set; }
        public ICommand CancelOrder { get; set; }
        public ICommand Navigate { get; set; }
        public ICommand CompleteOrder { get; set; }
        public ICommand ComplainOnOrder { get; set; }

        private List<clsOrders> _newOrders;
        public List<clsOrders> NewOrders
        {
            get => _newOrders;
            set
            {
                _newOrders = value;
                OnPropertyChanged();
            }
        }

        private List<clsOrders> _currentOrders;
        public List<clsOrders> CurrentOrders
        {
            get => _currentOrders;
            set
            {
                _currentOrders = value;
                OnPropertyChanged();
            }
        }

        private List<clsOrders> _previousOrders;
        public List<clsOrders> PreviousOrders
        {
            get => _previousOrders;
            set
            {
                _previousOrders = value;
                OnPropertyChanged();
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

         public  NewOrderViewModel()
        {
            AcceptOrder = new Command<int?>(_SetOrderAccepted);

            CancelOrder = new Command<int?>(_SetCancelOrder);

            Navigate = new Command<string>(_NavigateToCustomer);

            CompleteOrder = new Command<int?>(_SetCompleteOrder);

            ComplainOnOrder = new Command<int?>(_Complain);

            _LoadOrders();
        }

        void _LoadOrders()
        {
            LoadNewOrder();

            LoadCurrentOrder();

            LoadPreviousOrder();
        }

        public async void LoadNewOrder()
        {
            try
            {
                NewOrders = await clsOrders.GetAllOrders();
            }
            catch 
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load orders", "Ok");
            }
        }

        public async void LoadCurrentOrder()
        {
            try
            {
                CurrentOrders = await clsOrders.GetAllOrdersByStoreIdAndStatues(clsGlobal.CurrentUser.StoreID, 2, 2);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "No Orders to load", "Ok");
            }
        }

        public async void LoadPreviousOrder()
        {
            try
            {
                PreviousOrders = await clsOrders.GetAllOrdersByStoreIdAndStatues(clsGlobal.CurrentUser.StoreID, 3, 4);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "No Orders to load", "Ok");
            }

        }

        async void _SetOrderAccepted(int? OrderNumber)
        {
            Task<bool> ConfirmCancel = Shell.Current.DisplayAlert("Cancel", "Do you want to Accept this order ? ", "Yes", "Cancel");

            IsBusy = true;

            await ConfirmCancel;

            if (ConfirmCancel.Result)
            {
                if (await clsOrders.AssignOrderForStore(OrderNumber, clsGlobal.CurrentUser.StoreID))
                {
                       await Shell.Current.DisplayAlert("Done", "this order Assign for you successfully", "Ok");
                       LoadCurrentOrder();

                }
                else
                await Shell.Current.DisplayAlert("Error", "this order assign for anthor provider", "Ok");
            }

            IsBusy = false;
        }

        async void _SetCancelOrder(int? OrderNumber)
        {
            Task<bool> ConfirmCancel = Shell.Current.DisplayAlert("Cancel", "Do you want to cancel this order ? ", "Yes", "Cancel");

            IsBusy = true;

            await ConfirmCancel;

            if (ConfirmCancel.Result)
            {
                 bool  isCancel = await clsOrders.SetOrderCancelFromStore(OrderNumber);
                if (isCancel)
                {
                    await Shell.Current.DisplayAlert("Done", "this order cancel successfully", "Ok");

                    LoadCurrentOrder();
                }
                else
                    await Shell.Current.DisplayAlert("Error", "this order cancel failed", "Ok");

            }

            IsBusy = false;

        }

        async void _NavigateToCustomer(string OrderLocation)
        {
            double Latitude = 0, Longitude = 0;

            string[] parts = OrderLocation.Split(',');

            if (parts.Length == 2)
            {
                // Trim whitespace and parse latitude and longitude
                if (double.TryParse(parts[0].Trim(), out double latitude) &&
                    double.TryParse(parts[1].Trim(), out double longitude))
                {
                    var location = new Location(latitude, longitude);
                    try
                    {
                        await Map.Default.OpenAsync(location);
                    }
                    catch (Exception ex)
                    {
                        await Shell.Current.DisplayAlert("Error", "Cant Navigate to this location", "Ok");
                    }
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Location not correct", "Ok");
            }
        }

        async void _SetCompleteOrder(int? OrderNumber)
        {
            Task<bool> ConfirmCancel = Shell.Current.DisplayAlert("Cancel", "Do you want to complete this order ? ", "Yes", "Cancel");

            IsBusy = true;

            await ConfirmCancel;

            if (ConfirmCancel.Result)
            {
                bool IsComplete = await clsOrders.SetOrderStatusComplete(OrderNumber);

                if (IsComplete)
                {
                    await Shell.Current.DisplayAlert("Done", "this order complete successfully", "Ok");

                    LoadCurrentOrder();
                }
                else
                    await Shell.Current.DisplayAlert("Error", "this order complete failed", "Ok");

            }

            IsBusy = false;
        }

        async void _Complain(int? OrderNumber)
        {
            IsBusy = true;

            // await AppShell.Current.Navigation.PushAsync(new p(order.OrderNumber));

            IsBusy = false;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
