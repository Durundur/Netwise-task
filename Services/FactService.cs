using netwise_task.Models;

namespace netwise_task.Services
{
    public class FactService
    {
        private readonly HttpClient _httpClient;

        public FactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FactModel> GetFact()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://catfact.ninja/fact");
                response.EnsureSuccessStatusCode();
                var fact = await response.Content.ReadFromJsonAsync<FactModel>();
                if (fact == null)
                {
                    throw new Exception("An error occurred while parsing the JSON response.");
                }
                return fact;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching the fact.", ex);
            }
        }
    }
}
