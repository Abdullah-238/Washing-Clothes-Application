
using System.Net.Http.Json;


public class clsStore
{

    static private readonly HttpClient httpClient = new HttpClient()
    {
        //BaseAddress = new Uri("http://localhost:5114/api/Store/")

        BaseAddress = new Uri("https://localhost:7001/api/Store/")

    };

    public int? StoreID { get; set; }
    public string StoreName { get; set; }
    public string CommercialNumber { get; set; }
    public string Location { get; set; }
    public string Photo { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public byte? Rating { get; set; }

    public bool? isActive { get; set; }

    public clsStore(int? storeid, string storename, string commercialnumber,
        string location, string photo, string phone, string email, string password, byte? rating, bool? isActive)
    {
        StoreID = storeid;
        StoreName = storename;
        CommercialNumber = commercialnumber;
        Location = location;
        Photo = photo;
        Phone = phone;
        Email = email;
        Password = password;
        Rating = rating;
        this.isActive = isActive;
    }

    public static async Task<clsStore> FindStoreByEmailAndPassword(string Email, string Password)
    {

        try
        {
            var requestUri = $"{Email}/{Password}";


            var response = await httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var store = await response.Content.ReadFromJsonAsync<clsStore>();

                if (store != null)
                {
                    return store;
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return null;
    }

    public static async Task<bool> IsStoreExistById(int? StoreID)
    {

        try
        {
            var requestUri = $"{StoreID}";

            var response = await httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            //else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //{
            //    return null;
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //    return null;
            //}
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return false;
    }

    public static async Task<clsStore> AddStore(clsStore Store)
    {

        try
        {
            var response = await httpClient.PostAsJsonAsync("Store", Store);

            if (response.IsSuccessStatusCode)
            {
                var addedStore = await response.Content.ReadFromJsonAsync<clsStore>();

                return addedStore;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                //  Console.WriteLine("Bad Request: Invalid student data.");
            }
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return null;
    }

    public static async Task<bool> IsStoreExistByPhone(string Phone)
    {

        try
        {
            var requestUri = $"GetByPhone/{Phone}";

            var response = await httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            //else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //{
            //    return null;
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //    return null;
            //}
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return false;
    }

    public static async Task<bool> IsStoreExistByEmail(string Email)
    {

        try
        {
            var requestUri = $"GetByEmail/{Email}";

            var response = await httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            //else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //{
            //    return null;
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //    return null;
            //}
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return false;
    }
}
