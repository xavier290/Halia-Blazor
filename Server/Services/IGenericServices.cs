using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NovaLaundryAppWebAdminBlazor.Server.Services
{
    public class IGenericServices
    {
        public async Task<TResponse> SendRequestAsync<TRequest, TResponse>(HttpMethod method, string requestUri, string token, TRequest requestData = default)
        {
            using var _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Utilities.ServerUrl)
            };

            if (!string.IsNullOrEmpty(token))
            {
                // Parse the JSON string to extract the token value
                JArray jsonArray = JArray.Parse(token);
                JObject jsonObject = (JObject)jsonArray[0];
                string bearerToken = jsonObject["value"].ToString();

                // Set the Authorization header with the extracted token value
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            }

            HttpResponseMessage response;

            switch (method.Method.ToUpper())
            {
                case "GET":
                    response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);
                    break;
                case "POST":
                    response = await _httpClient.PostAsJsonAsync(requestUri, requestData).ConfigureAwait(false);
                    break;
                case "PUT":
                    response = await _httpClient.PutAsJsonAsync(requestUri, requestData).ConfigureAwait(false);
                    break;
                case "DELETE":
                    response = await _httpClient.DeleteAsync(requestUri).ConfigureAwait(false);
                    break;
                default:
                    throw new ArgumentException("Unsupported HTTP method.");
            }

                return await response.Content.ReadFromJsonAsync<TResponse>().ConfigureAwait(false);
        }
    }
}
