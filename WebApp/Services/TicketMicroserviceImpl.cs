using System.Reflection;
using WebApp.Models.ModelViews;
using System.Text.Json;

namespace WebApp.Services
{
    public class TicketMicroserviceImpl : ITicketMicroservice
    {
        private HttpClient _httpClient { get; set; }
        public TicketMicroserviceImpl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TicketViewModel>> GetTicketsByDateAndPath(DateTime DateStart, String PointStart, String PointEnd)
        {
            var options = $"api/ticket/get/{DateStart:yyyy-MM-dd}/{Uri.EscapeDataString(PointStart)}/{Uri.EscapeDataString(PointEnd)}";
            var response = await _httpClient.GetAsync(options);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<TicketViewModel>>(json);
        }
    }
}
