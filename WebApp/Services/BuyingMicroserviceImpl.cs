﻿using Newtonsoft.Json;
using TicketMicroservice.Models.ModelDatabase;

namespace WebApp.Services
{
    public class BuyingMicroserviceImpl : IBuyingMicroservice
    {
        private HttpClient _httpClient { get; set; }
        public BuyingMicroserviceImpl(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public async Task<UserTicketModel?> BuyUserTicket(Guid TicketId, Guid UserId)
        {
            var options = $"api/buying/buy/{TicketId}/{UserId}";
            var response = await _httpClient.GetAsync(options);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var userTicket = JsonConvert.DeserializeObject<UserTicketModel>(json);
                return userTicket;
            }
            return null;
        }
    }
}
