using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Transactions;
using Lab6.Models;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json.Linq;

namespace Lab5.Authentication
{
    public class Lab6API
    {
        private readonly HttpClient _httpClient;
        private readonly Auth0Authentication _auth0Authentication;

        public Lab6API(HttpClient httpClient, Auth0Authentication auth0UserService)
        {
            _httpClient = httpClient;
            _auth0Authentication = auth0UserService;

        }

        private async Task SetAuthorizationHeaderAsync()
        {
            var accessToken = await _auth0Authentication.GetApiTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public async Task<IEnumerable<Addresses>> GetCustomerAddressesAsync()
        {
            await SetAuthorizationHeaderAsync();

            var response = await _httpClient.GetAsync("api/CustomerAddresses");
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<IEnumerable<Addresses>>(responseStream);
        }

        public async Task<Addresses> GetCustomerAddressesAsync(int id)
        {
            await SetAuthorizationHeaderAsync();

            var response = await _httpClient.GetAsync($"api/CustomerAddresses/{id}");
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Addresses>(responseStream);
        }

        public async Task<IEnumerable<Customers>> GetCustomersAsync(string token)
        {
            await SetAuthorizationHeaderAsync();

            var response = await _httpClient.GetAsync("api/Customers");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<Customers>>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Enumerable.Empty<Customers>();
        }

        public async Task<Customers> GetCustomerAsync(int id)
        {
            await SetAuthorizationHeaderAsync();

            var response = await _httpClient.GetAsync($"api/Customers/{id}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Customers>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new Customers();
        }

        public async Task<IEnumerable<CustomerPhoneNumbers>> GetCustomerPhoneNumbersAsync()
        {
            await SetAuthorizationHeaderAsync();

            var response = await _httpClient.GetAsync("api/CustomerPhoneNumbers");
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<CustomerPhoneNumbers>>(responseStream);
        }

        public async Task<CustomerPhoneNumbers> GetCustomerPhoneNumbersAsync(int id)
        {
            await SetAuthorizationHeaderAsync();

            var response = await _httpClient.GetAsync($"api/CustomerPhoneNumbers/{id}");
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<CustomerPhoneNumbers>(responseStream);
        }

        public async Task<IEnumerable<CustomerPhoneNumbers>> SearchCustomerPhoneNumbersAsync(DateTime? date, List<int>? TypeCodes, string? valueStart, string? valueEnd)
        {
            await SetAuthorizationHeaderAsync();

            var query = new List<string>();

            if (date.HasValue)
            {
                query.Add($"date={date.Value:yyyy-MM-dd}");
            }

            if (TypeCodes != null && TypeCodes.Any())
            {
                query.Add($"transactionTypes={string.Join(",", TypeCodes)}");
            }

            if (!string.IsNullOrEmpty(valueStart))
            {
                query.Add($"valueStart={valueStart}");
            }

            if (!string.IsNullOrEmpty(valueEnd))
            {
                query.Add($"valueEnd={valueEnd}");
            }

            var queryString = string.Join("&", query);
            var response = await _httpClient.GetAsync($"api/search?{queryString}");
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<CustomerPhoneNumbers>>(responseStream);
        }

        public async Task<string> ConvertTimeAsync(DateTime utcDateTime)
        {
            await SetAuthorizationHeaderAsync();

            string dateTimeString = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss.fffffff");

            string encodedDateTime = Uri.EscapeDataString(dateTimeString);

            string requestUrl = $"https://192.168.0.105:7225/api/time/convert?utcDateTime={encodedDateTime}";

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception($"Error calling API: {response.StatusCode} - {response.ReasonPhrase}");
        }
    }
}
