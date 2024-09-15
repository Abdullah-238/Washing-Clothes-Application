using System.Net.Http.Json;



public class clsStoreReviews
{
    private static readonly HttpClient httpClient = new HttpClient()
    {
        //BaseAddress = new Uri("http://localhost:5114/api/Review/")

        BaseAddress = new Uri("https://localhost:7001/api/Review/5")

    };

    public string ReviewText { get; set; }
    public byte? OrderRate { get; set; }
    public string CustomerName { get; set; }

    public clsStoreReviews(byte? orderRate, string reviewText, string customerName)
    {
        ReviewText = reviewText;
        OrderRate = orderRate;
        CustomerName = customerName;
    }


    public static async Task<List<clsStoreReviews>> GetAllReviewByStoreId(int? storeID)
    {

        List<clsStoreReviews> allReviews = new List<clsStoreReviews>();

        try
        {
           // var response = await httpClient.GetAsync($"{storeID}");

            var queryString = $"{storeID}";

            var response = await httpClient.GetAsync(queryString);

            if (response.IsSuccessStatusCode)
            {
                allReviews = await response.Content.ReadFromJsonAsync<List<clsStoreReviews>>() ?? new List<clsStoreReviews>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Return an empty list to indicate no reviews were found
                return new List<clsStoreReviews>();
            }
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            // For example, you can log it to a file or monitoring system
            // Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return allReviews;
    }

}
