using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Common.Common.HttpClients.Sales
{
    public class SalesHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public SalesHttpClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["SalesService:BaseUrl"] ?? string.Empty;
        }

        public async Task SendSaleAsync(SaleRecordRequest sale)
        {
            if (_baseUrl != string.Empty)
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/sales", sale);
                response.EnsureSuccessStatusCode(); // Throw if not 200
            }
            else
            {
                throw new Exception("Sales aren't updated from this purchase!");
            }
        }
    }
}
