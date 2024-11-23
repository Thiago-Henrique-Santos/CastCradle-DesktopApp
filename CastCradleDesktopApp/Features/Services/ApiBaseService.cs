using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Web;
using CastCradleDesktopApp.Features.Storage;

namespace CastCradleDesktopApp.Features.Services
{
    public class ApiBaseService()
    {
        protected readonly HttpClient _httpClient = App.HttpClient;
        protected readonly string _apiEndpoint = "http://localhost/api";

        private StringContent Serialize<T>(T obj)
        {
            return new StringContent(
                JsonSerializer.Serialize(obj),
                Encoding.UTF8,
                "application/json"
            );
        }

        private void ConfigHeaders()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            var jwtToken = JWTStore.GetToken();
            if (!string.IsNullOrWhiteSpace(jwtToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }
        }

        private async Task<R?> JSONResultHandle<R>(HttpResponseMessage result)
        {
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<R>();
            }
            else
            {
                var errorContent = await result.Content.ReadAsStringAsync();
                throw new HttpRequestException(
                    $"Erro ao chamar o endpoint '{_apiEndpoint}'. Código: {result.StatusCode}. Conteúdo: {errorContent}"
                );
            }
        }

        public async Task<R?> Get<T, R>(string endpoint, T? query)
        {
            string url;
            if (query != null)
            {
                var queryParams = HttpUtility.ParseQueryString(string.Empty);
                foreach (var property in typeof(T).GetProperties())
                {
                    var value = property.GetValue(query)?.ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        queryParams[property.Name] = value;
                    }
                }
                url = $"{_apiEndpoint}{endpoint}?{queryParams}";
            }
            else
            {
                url = $"{_apiEndpoint}{endpoint}";
            }

            ConfigHeaders();
            var response = await _httpClient.GetAsync(url);
            return await JSONResultHandle<R>(response);
        }

        public async Task<R?> Post<T, R>(string endpoint, T body)
        {
            ConfigHeaders();
            var content = Serialize(body);
            var response = await _httpClient.PostAsync($"{_apiEndpoint}{endpoint}", content);
            return await JSONResultHandle<R>(response);
        }

        public async Task<R?> Put<T, R>(string endpoint, T body)
        {
            ConfigHeaders();
            var content = Serialize(body);
            var response = await _httpClient.PutAsync($"{_apiEndpoint}{endpoint}", content);
            return await JSONResultHandle<R>(response);
        }
        public async Task<R?> Delete<T, R>(string endpoint, int id)
        {
            ConfigHeaders();
            var response = await _httpClient.DeleteAsync($"{_apiEndpoint}{endpoint}/{id}");
            return await JSONResultHandle<R>(response);
        }

    }
}