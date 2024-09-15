
using System.Net.Http.Json;


namespace SheenProviderApp.services.OrdersServices
{

    public class clsOrders
    {

        private static readonly HttpClient httpClient = new HttpClient
        {
            //BaseAddress = new Uri("http://localhost:5114/api/Orders/")

            BaseAddress = new Uri("https://localhost:7001/api/Orders/")

        };
        public int OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string OrderLocation { get; set; }
        public string OrderItemsList { get; set; }
        public double OrderTotalPrice { get; set; }

        public clsOrders(int orderNumber, string orderStatus, string photo, string name,
            string orderLocation, string orderItemsList, double orderTotalPrice)
        {
            OrderNumber = orderNumber;
            OrderStatus = orderStatus;
            Photo = photo;
            Name = name;
            OrderLocation = orderLocation;
            OrderItemsList = orderItemsList;
            OrderTotalPrice = orderTotalPrice;

        }

        public static async Task<List<clsOrders>> GetAllOrders()
        {
            List<clsOrders> allOrders = new List<clsOrders>();
            try
            {
                var response = await httpClient.GetAsync("AllOrders");

                if (response.IsSuccessStatusCode)
                {

                    allOrders = await response.Content.ReadFromJsonAsync<List<clsOrders>>() ?? new List<clsOrders>();

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Optionally log or handle the case where no orders are found
                    return new List<clsOrders>();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                // Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return allOrders;
        }

        public static async Task<List<clsOrders>> GetAllOrdersByStoreIdAndStatues(int? StoreID, byte? Statues1, byte? Statues2)
        {

            List<clsOrders> allOrders = new List<clsOrders>();
            try
            {
                var queryString = $"{StoreID}/{Statues1}/{Statues2}";

                var response = await httpClient.GetAsync(queryString);

                if (response.IsSuccessStatusCode)
                {

                    allOrders = await response.Content.ReadFromJsonAsync<List<clsOrders>>() ?? new List<clsOrders>();

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Optionally log or handle the case where no orders are found
                    return new List<clsOrders>();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                // Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return allOrders;
        }

        public static async Task<bool> AssignOrderForStore(int ? OrderNumber , int? StoreID)
        {

            try
            {
                var requestUri = $"AssignOrder/{OrderNumber}/{StoreID}";

                var response = await httpClient.PutAsJsonAsync(requestUri,"");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return false;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
               // Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return false;
        }

        public static async Task<bool> SetOrderCancelFromStore(int? OrderNumber)
        {

            try
            {
                var requestUri = $"CancelOrder/{OrderNumber}";

                var response = await httpClient.PutAsJsonAsync(requestUri, "");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return false;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
               // Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return false;
        }

        public static async Task<bool> SetOrderStatusComplete(int? OrderNumber)
        {

            try
            {
                var requestUri = $"CompleteOrder/{OrderNumber}";

                var response = await httpClient.PutAsJsonAsync(requestUri, "");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return false;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
              //  Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return false;
        }

   
    }



}
