using Newtonsoft.Json;

namespace WebApp.Models.ModelViews
{
    public class PlaceViewModel
    {
        [JsonProperty("placeName")]
        public String PlaceName { get; set; }

        [JsonProperty("ticketId")]
        public Guid TicketId { get; set; }

        [JsonProperty("cost")]
        public float Cost { get; set; }

        [JsonProperty("isOccupied")]
        public bool IsOccupied{ get; set; }
    }
}
