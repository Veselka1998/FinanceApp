using Newtonsoft.Json;
using RestSharp;

namespace FinanceApp.Components.Services;

public class MarketService
{
    // Zde do proměnné ApiKey napiš svůj API klíč
    private const string ApiKey = "";
    private const string BaseUrl = "https://finnhub.io/api/v1/quote?symbol=";
    public async Task<decimal?> GetStockPrice(string symbol)
    {
        try
        {
            var client = new RestClient($"{BaseUrl}{symbol}&token={ApiKey}");
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<StockData>(response.Content);
                return data?.CurrentPrice;
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Chyba při načítání ceny akcie: {ex.Message}");
            return null;
        }
    }

    private class StockData
    {
        [JsonProperty("c")]
        public decimal CurrentPrice { get; set; }
    }

}
