

namespace Sheen.Reviews;

public partial class pgGetAllReviews : ContentPage
{

    public pgGetAllReviews()
	{
		InitializeComponent();

        _Load();
    }

    async void _Load()
    {
        List<clsStoreReviews> Review = new List<clsStoreReviews>();

        Review = await clsStoreReviews.GetAllReviewByStoreId(clsGlobal.CurrentUser.StoreID);

        clvComplain.ItemsSource = Review;
    }
}